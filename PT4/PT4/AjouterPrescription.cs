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
    public partial class AjouterPrescription : Form
    {
        private MaladiesController _diseaseController;
        private ProduitController _productController;
        private SoinController _careController;

        public AjouterPrescription(MaladiesController diseaseController, ProduitController productController, SoinController careController)
        {
            InitializeComponent();
            _diseaseController = diseaseController;
            _productController = productController;
            _careController = careController;
            InitializeProduct();
            InitializeDisease();
        }

        public void InitializeDisease()
        {
            IEnumerable<MALADIE> diseases = _diseaseController.ListerMaladies();
            foreach (MALADIE d in diseases)
            {
                listBox1.Items.Add(d);
            }
        }

        public void InitializeProduct()
        {
            IEnumerable<PRODUIT> products = _productController.RecupererTousProduits();
            foreach (PRODUIT p in products)
            {
                listBox2.Items.Add(p);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems != null && listBox2.SelectedItems != null)
            {
                _careController.CreateCare(listBox1.SelectedItems.Cast<MALADIE>(), listBox2.SelectedItems.Cast<PRODUIT>(), textBoxDescription.Text);
            } else
            {
                Utils.ShowError("ERROR! You needs to selected at least one disease and one product.");
            }
        }
    }

}
