using Microsoft.Extensions.DependencyInjection;
using PT4.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT4
{
    public partial class AfficherStock : MenuHamberger
    {
        /// <summary>
        /// Instance of ProduitController
        /// </summary>
        private ProduitController _produitController;

        /// <summary>
        /// List of products
        /// </summary>
        private List<PRODUIT> cachedProducts;

        /// <summary>
        /// Number of max elements per page
        /// </summary>
        private static readonly int ELEMENTS_PER_PAGE = 20;

        /// <summary>
        /// Number of the current page
        /// </summary>
        private int CurrentPage = 0;

        /// <summary>
        /// returns the number of products in cachedProducts
        /// </summary>
        private int ElementCount { get => cachedProducts.Count; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="produitController"> Instance of ProduitController</param>
        /// <param name="services">Instance of ServiceCollection</param>
        /// <param name="salarieId">a salary</param>
        /// <param name="estAdmin">bool admin</param>
        public AfficherStock(ProduitController produitController, ServiceCollection services, int salarieId, bool estAdmin) : base(services, salarieId, estAdmin)
        {
            _produitController = produitController;
            _produitController.SubscribeProducts(OnChanged);
            _produitController.SubscribeDeleteProducts(OnDelete);
            this.Closed += (_, __) => { _produitController.UnSubscribeProducts(OnChanged); _produitController.UnSubscribeDeleteProducts(OnDelete); };
            cachedProducts = new List<PRODUIT>();
            InitializeComponent();
            InitDataGridView();
            stocks.SendToBack();
            buttonHamburger.BringToFront();

            backwards.Visible = false;
            forward.Visible = ElementCount > (CurrentPage + 1) * ELEMENTS_PER_PAGE;

        }

        /// <summary>
        /// Function which inits the DataGridView
        /// </summary>
        private void InitDataGridView()
        {
            IEnumerable<PRODUIT> produits = _produitController.RecupererTousProduits();
            int cpt = 0;
            foreach (var prod in produits)
            {
                if (cpt++ < ELEMENTS_PER_PAGE)
                {
                    AddProductToDataGrid(prod);
                }
                cachedProducts.Add(prod);

            }
        }

        /// <summary>
        /// Function which resets the DataGridView
        /// </summary>
        private void ResetDataGridViewFromCache()
        {
            stocks.Rows.Clear();
            foreach (var prod in Utils.GetRangeAndCut(cachedProducts, CurrentPage * ELEMENTS_PER_PAGE, ELEMENTS_PER_PAGE))
            {
                AddProductToDataGrid(prod);
            }

            backwards.Visible = CurrentPage > 0;
            forward.Visible = ElementCount > (CurrentPage + 1) * ELEMENTS_PER_PAGE;
        }

        /// <summary>
        /// Function which is called whenever there is a stock updated or added
        /// </summary>
        /// <param name="prods">All the stock which has been added or updated</param>
        public void OnChanged(IEnumerable<PRODUIT> prods)
        {
            cachedProducts.RemoveAll((p) => prods.Any((pp) => p.IDPRODUIT == pp.IDPRODUIT));
            cachedProducts.AddRange(prods);
            ResetDataGridViewFromCache();
        }

        /// <summary>
        /// Fybctuib which is called whenever there is a stock deleted
        /// </summary>
        /// <param name="prods">All the stock deleted</param>
        public void OnDelete(IEnumerable<PRODUIT> prods)
        {
            cachedProducts.RemoveAll((p) => prods.Any((pp) => p.IDPRODUIT == pp.IDPRODUIT));
            ResetDataGridViewFromCache();
        }

        /// <summary>
        /// Add a new row to the dataGridView
        /// </summary>
        /// <param name="prod"></param>
        private void AddProductToDataGrid(PRODUIT prod)
        {
            string prixVente = "N/A";
            if (prod.PRIXDEVENTE.HasValue)
            {
                prixVente = prod.PRIXDEVENTE.ToString();
            }
            if (estAdmin || !prod.MEDICAMENT)
            {
                stocks.Rows.Add(prod.NOMPRODUIT, prixVente, prod.PRIXACHAT, prod.QUANTITEENSTOCK, prod.DESCRIPTION, prod.PRIXDEVENTE.HasValue, prod.MEDICAMENT);
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AjouterStock ajouterStock = new AjouterStock(_produitController, estAdmin);
            ajouterStock.ShowDialog();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (stocks.SelectedRows.Count == 1)
            {
                DataGridViewRow row = stocks.SelectedRows[0];
                PRODUIT p = _produitController.FindByName((string)row.Cells["Nom"].Value);
                AjouterStock ajouterStock = new AjouterStock(_produitController, estAdmin);
                ajouterStock.SetProduit(p);
                ajouterStock.ShowDialog();
            }
            else if (stocks.SelectedCells.Count == 1)
            {
                DataGridViewCell selectedCell = stocks.SelectedCells[0];
                DataGridViewCell cell = stocks.Rows[selectedCell.RowIndex].Cells["Nom"];

                PRODUIT p = _produitController.FindByName((string)cell.Value);
                AjouterStock ajouterStock = new AjouterStock(_produitController, estAdmin);
                ajouterStock.SetProduit(p);
                ajouterStock.ShowDialog();
            }
            else
            {
                Utils.ShowError("ERREUR! Veuillez sélectionner un et un seul produit.");
                return;
            }
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (stocks.SelectedRows.Count == 1)
            {
                DataGridViewRow row = stocks.SelectedRows[0];
                PRODUIT p = _produitController.FindByName((string)row.Cells["Nom"].Value);
                ModifierStock modifStock = new ModifierStock(_produitController, estAdmin);
                modifStock.SetProduit(p);
                modifStock.ShowDialog();
            }
            else if (stocks.SelectedCells.Count == 1)
            {
                DataGridViewCell selectedCell = stocks.SelectedCells[0];
                DataGridViewCell cell = stocks.Rows[selectedCell.RowIndex].Cells["Nom"];

                PRODUIT p = _produitController.FindByName((string)cell.Value);
                ModifierStock modifierStock = new ModifierStock(_produitController, estAdmin);
                modifierStock.SetProduit(p);
                modifierStock.ShowDialog();
            }
            else
            {
                Utils.ShowError("ERREUR! Veuillez sélectionner un et un seul produit.");
                return;
            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sur?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (stocks.SelectedRows.Count > 0)
                {
                    foreach (var obj in stocks.SelectedRows)
                    {
                        DataGridViewRow row = (DataGridViewRow)obj;
                        _produitController.RemoveByName((string)row.Cells["Nom"].Value);
                        MessageBox.Show($"Vous avez bien supprimé le produit '{row.Cells["Nom"].Value}'");
                    }
                }
                else if (stocks.SelectedCells.Count > 0)
                {
                    DataGridViewCell selectedCell = stocks.SelectedCells[0];
                    DataGridViewCell cell = stocks.Rows[selectedCell.RowIndex].Cells["Nom"];

                    _produitController.RemoveByName((string)cell.Value);
                }
                else
                {
                    Utils.ShowError("ERREUR! Veuillez sélectionner au moins un produit.");
                    return;
                }
            }
        }

        private void rechercheButton_Click(object sender, EventArgs e)
        {
            RechercheStock rechercheStock = new RechercheStock();
            if (rechercheStock.ShowDialog() == DialogResult.OK)
            {
                reset.Visible = true;

                var generatedPredicate = _produitController.CreateCriteriasFromForm(rechercheStock);
                Predicate<PRODUIT> funcAsPredicate = new Predicate<PRODUIT>(generatedPredicate.Compile());
                stocks.Rows.Clear();
                foreach (PRODUIT p in cachedProducts.FindAll(funcAsPredicate))
                {
                    AddProductToDataGrid(p);
                }
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            this.CurrentPage = 0;
            ResetDataGridViewFromCache();
            reset.Visible = false;
        }

        private void forward_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            ResetDataGridViewFromCache();
        }

        private void backwards_Click(object sender, EventArgs e)
        {
            CurrentPage--;
            ResetDataGridViewFromCache();
        }
    }
}
