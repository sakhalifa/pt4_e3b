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
    public partial class AfficherStock : Form
    {
        private ProduitController _produitController;

        public AfficherStock(ProduitController produitController)
        {
            _produitController = produitController;
            _produitController.SubscribeProducts(OnChanged);
            _produitController.SubscribeDeleteProducts(OnDelete);
            InitializeComponent();
            InitDataGridView();
        }

        private void InitDataGridView()
        {
            IEnumerable<PRODUIT> produits = _produitController.RecupererTousProduits();

            foreach(var prod in produits)
            {
                AddProductToDataGrid(prod);
            }
        }

        public void OnChanged(IEnumerable<PRODUIT> prods)
        {
            HashSet<PRODUIT> prodUnique = new HashSet<PRODUIT>(prods);
            foreach(var obj in stocks.Rows)
            {
                DataGridViewRow row = (DataGridViewRow)obj;
                foreach(var prod in prods)
                {
                    if(row.Cells["Nom"].Value == null)
                    {
                        row.Cells["Nom"].Value = prod.NOMPRODUIT;
                        row.Cells["PrixVente"].Value = prod.PRIXDEVENTE;
                        row.Cells["PrixAchat"].Value = prod.PRIXACHAT;
                        row.Cells["Quantite"].Value = prod.QUANTITEENSTOCK;
                        row.Cells["Description"].Value = prod.DESCRIPTION;
                        prodUnique.Remove(prod);
                        continue;
                    }
                    if (row.Cells["Nom"].Value.Equals(prod.NOMPRODUIT))
                    {
                        row.Cells["PrixVente"].Value = prod.PRIXDEVENTE;
                        row.Cells["PrixAchat"].Value = prod.PRIXACHAT;
                        row.Cells["Quantite"].Value = prod.QUANTITEENSTOCK;
                        row.Cells["Description"].Value = prod.DESCRIPTION;
                        prodUnique.Remove(prod);
                    }
                }
            }

            foreach(var prod in prodUnique)
            {
                AddProductToDataGrid(prod);
            }
            
            Console.WriteLine("Nom des produits changés :");
            foreach(var prod in prods)
            {
                Console.WriteLine($"- {prod.NOMPRODUIT}");
            }
        }

        public void OnDelete(IEnumerable<PRODUIT> prods)
        {
            List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
            foreach (var obj in stocks.Rows)
            {
                DataGridViewRow row = (DataGridViewRow)obj;
                foreach (var prod in prods)
                {
                    if (row.Cells["Nom"].Value.Equals(prod.NOMPRODUIT))
                    {
                        rowsToDelete.Add(row);
                    }
                }
            }
            rowsToDelete.ForEach((r) => stocks.Rows.Remove(r));
        }

        private void AddProductToDataGrid(PRODUIT prod)
        {
            stocks.Rows.Add(prod.NOMPRODUIT, prod.PRIXDEVENTE, prod.PRIXACHAT, prod.QUANTITEENSTOCK, prod.DESCRIPTION);
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
                DataGridViewCell cell = stocks.SelectedCells[0];
                if (cell.ColumnIndex == 0)
                {
                    PRODUIT p = _produitController.FindByName((string)cell.Value);
                    AjouterStock ajouterStock = new AjouterStock(_produitController);
                    ajouterStock.SetProduit(p);
                    ajouterStock.ShowDialog();
                }
            }
            else
            {
                Utils.ShowError("ERREUR! Veuillez sélectionner un et un seul produit.");
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
                DataGridViewCell cell = stocks.SelectedCells[0];
                if (cell.ColumnIndex == 0)
                {
                    PRODUIT p = _produitController.FindByName((string)cell.Value);
                    ModifierStock modifStock = new ModifierStock(_produitController);
                    modifStock.SetProduit(p);
                    modifStock.ShowDialog();
                }
            }
            else
            {
                Utils.ShowError("ERREUR! Veuillez sélectionner un et un seul produit.");
            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sur?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (stocks.SelectedRows.Count > 0)
                {
                    foreach(var obj in stocks.SelectedRows)
                    {
                        DataGridViewRow row = (DataGridViewRow)obj;
                        _produitController.RemoveByName((string)row.Cells["Nom"].Value);
                    }
                }else if(stocks.SelectedCells.Count > 0)
                {
                    int cCells = 0;
                    foreach(var obj in stocks.SelectedCells)
                    {
                        DataGridViewCell cell = (DataGridViewCell)obj;
                        if(cell.ColumnIndex == 0)
                        {
                            _produitController.RemoveByName((string)cell.Value);
                            cCells++;
                        }
                    }
                    if(cCells == 0)
                    {
                        Utils.ShowError("ERREUR! Veuillez sélectionner uniquement les noms ou les lignes des produits.");
                    }
                }
                else
                {
                    Utils.ShowError("ERREUR! Veuillez sélectionner au moins un produit.");
                }
            }
        }

        private void rechercheButton_Click(object sender, EventArgs e)
        {
            RechercheStock rechercheStock = new RechercheStock();
            rechercheStock.ShowDialog();

            var generatedPredicate = _produitController.CreateCriteriasFromForm(rechercheStock);
            foreach(PRODUIT p in _produitController.FindByPredicate(generatedPredicate))
            {
                Console.WriteLine(p.NOMPRODUIT);
            }
        }
    }
}
