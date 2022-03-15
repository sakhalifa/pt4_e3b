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
            InitializeComponent();
            InitDataGridView();
        }

        private void InitDataGridView()
        {
            //TODO
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
            /*
            Console.WriteLine("Nom des produits changés :");
            foreach(var prod in prods)
            {
                Console.WriteLine($"- {prod.NOMPRODUIT}");
            }*/
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
            ajouterStock.Show();
        }

        
    }
}
