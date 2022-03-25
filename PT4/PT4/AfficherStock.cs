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
        private ProduitController _produitController;

        private List<PRODUIT> cachedProducts;

        private static readonly int ELEMENTS_PER_PAGE = 20;

        private int CurrentPage = 0;

        private int ElementCount { get => cachedProducts.Count; }

        public AfficherStock(ProduitController produitController, ServiceCollection services, int salarieId, bool estAdmin) : base(services, salarieId, estAdmin)
        {
            _produitController = produitController;
            _produitController.SubscribeProducts(OnChanged);
            _produitController.SubscribeDeleteProducts(OnDelete);
            cachedProducts = new List<PRODUIT>();
            InitializeComponent();
            InitDataGridView();
            stocks.SendToBack();

            backwards.Visible = false;
            forward.Visible = ElementCount > (CurrentPage + 1) * ELEMENTS_PER_PAGE;

        }

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

        public void OnChanged(IEnumerable<PRODUIT> prods)
        {
            cachedProducts.RemoveAll((p) => prods.Any((pp) => p.IDPRODUIT == pp.IDPRODUIT));
            cachedProducts.AddRange(prods);
            ResetDataGridViewFromCache();
        }

        public void OnDelete(IEnumerable<PRODUIT> prods)
        {
            cachedProducts.RemoveAll((p) => prods.Any((pp) => p.IDPRODUIT == pp.IDPRODUIT));
            ResetDataGridViewFromCache();
        }

        private void AddProductToDataGrid(PRODUIT prod)
        {
            string prixVente = "N/A";
            if (prod.PRIXDEVENTE.HasValue)
            {
                prixVente = prod.PRIXDEVENTE.ToString();
            }
            if (estAdmin || !prod.MEDICAMENT) { 
                stocks.Rows.Add(prod.NOMPRODUIT, prixVente, prod.PRIXACHAT, prod.QUANTITEENSTOCK, prod.DESCRIPTION, prod.PRIXDEVENTE.HasValue, prod.MEDICAMENT);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AjouterStock ajouterStock = new AjouterStock(_produitController);
            ajouterStock.ShowDialog();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (stocks.SelectedRows.Count == 1)
            {
                DataGridViewRow row = stocks.SelectedRows[0];
                PRODUIT p = _produitController.FindByName((string)row.Cells["Nom"].Value);
                AjouterStock ajouterStock = new AjouterStock(_produitController);
                ajouterStock.SetProduit(p);
                ajouterStock.ShowDialog();
            }
            else if (stocks.SelectedCells.Count == 1)
            {
                DataGridViewCell selectedCell = stocks.SelectedCells[0];
                DataGridViewCell cell = stocks.Rows[selectedCell.RowIndex].Cells["Nom"];

                PRODUIT p = _produitController.FindByName((string)cell.Value);
                AjouterStock ajouterStock = new AjouterStock(_produitController);
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
                ModifierStock modifStock = new ModifierStock(_produitController);
                modifStock.SetProduit(p);
                modifStock.ShowDialog();
            }
            else if (stocks.SelectedCells.Count == 1)
            {
                DataGridViewCell selectedCell = stocks.SelectedCells[0];
                DataGridViewCell cell = stocks.Rows[selectedCell.RowIndex].Cells["Nom"];

                PRODUIT p = _produitController.FindByName((string)cell.Value);
                ModifierStock modifierStock = new ModifierStock(_produitController);
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
                    int cCells = 0;
                    foreach (var obj in stocks.SelectedCells)
                    {
                        DataGridViewCell cell = (DataGridViewCell)obj;
                        if (cell.ColumnIndex == 0)
                        {
                            _produitController.RemoveByName((string)cell.Value);
                            cCells++;
                        }
                    }
                    if (cCells == 0)
                    {
                        Utils.ShowError("ERREUR! Veuillez sélectionner uniquement les noms ou les lignes des produits.");
                    }
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
