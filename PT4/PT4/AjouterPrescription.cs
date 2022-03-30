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
    public partial class AjouterPrescription : Form
    {
        private MaladiesController _diseaseController;
        private ProduitController _productController;
        private SoinController _careController;
        private ServiceCollection _services;

        public AjouterPrescription(MaladiesController diseaseController, ProduitController productController, SoinController careController, ServiceCollection service)
        {
            InitializeComponent();
            _diseaseController = diseaseController;
            _productController = productController;
            _careController = careController;
            _services = service;
            InitializeProduct();
            InitializeDisease();

            _productController.SubscribeProducts(OnChangeProduct);
            _productController.SubscribeDeleteProducts(OnDeleteProduct);


            this.Closed += (_, __) =>
            {
                _productController.UnSubscribeProducts(OnChangeProduct);
                _productController.UnSubscribeDeleteProducts(OnDeleteProduct);
            };
        }

        public void InitializeDisease()
        {
            IEnumerable<MALADIE> diseases = _diseaseController.ListerMaladies();
            foreach (MALADIE d in diseases)
            {
                maladiesListBox.Items.Add(d);
            }
        }

        public void InitializeProduct()
        {
            IEnumerable<PRODUIT> products = _productController.RecupererTousProduits();
            foreach (PRODUIT p in products)
            {
                produitListBox.Items.Add(p);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((maladiesListBox.SelectedItems != null && maladiesListBox.SelectedItems.Count != 0) && (produitListBox.SelectedItems != null && produitListBox.SelectedItems.Count != 0))
            {
                IEnumerable<MALADIE> castedMaladie = maladiesListBox.SelectedItems.Cast<MALADIE>();
                IEnumerable<PRODUIT> castedProduits = produitListBox.SelectedItems.Cast<PRODUIT>();
                _careController.CreateCare(castedMaladie, castedProduits, textBoxDescription.Text);
                StringBuilder sb = new StringBuilder("Vous avez bien rajouté un soin pour la/les maladies ");
                foreach(MALADIE m in castedMaladie)
                {
                    sb.Append($"'{m.NOMMALADIE}' ");
                }
                sb.Append("avec ces produits : ");
                foreach (PRODUIT p in castedProduits)
                {
                    sb.Append($"'{p.NOMPRODUIT}' ");
                }
                sb.RemoveLastCharacter();
                MessageBox.Show(sb.ToString());
                this.Close();
            }
            else
            {
                Utils.ShowError("ERREUR! Vous devez sélectionner au moins 1 produit et au moins 1 maladie!");
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            //We can do this because we can only access this window if we're admin
            _services.AddScoped((p) => new AjouterStock(p.GetRequiredService<ProduitController>(), true));
            using(ServiceProvider provider = _services.BuildServiceProvider())
            {
                using (IServiceScope serviceScope = provider.CreateScope())
                {
                    var ajouterStock = serviceScope.ServiceProvider.GetService<AjouterStock>();
                    ajouterStock.ShowDialog();
                }
            }
        }

        private void buttonAddSickness_Click(object sender, EventArgs e)
        {

        }

        private void OnChangeProduct(IEnumerable<PRODUIT> produits)
        {
            HashSet<PRODUIT> addedSoins = new HashSet<PRODUIT>(produits);
            IEnumerable<PRODUIT> castedItems = produitListBox.Items.Cast<PRODUIT>();
            foreach (PRODUIT pp in produits)
            {
                int ind = 0;
                foreach (PRODUIT p in castedItems)
                {
                    if (p.IDPRODUIT == pp.IDPRODUIT)
                    {
                        produitListBox.Items[ind] = pp;
                        addedSoins.Remove(pp);
                    }
                    ind++;
                }
            }

            foreach (PRODUIT p in addedSoins)
            {
                produitListBox.Items.Add(p);
            }
        }

        private void OnDeleteProduct(IEnumerable<PRODUIT> produits)
        {
            var casted = produitListBox.Items.Cast<PRODUIT>();

            foreach (PRODUIT p in produits)
            {
                foreach(PRODUIT prod in casted)
                {
                    if(p.IDPRODUIT == prod.IDPRODUIT)
                    {
                        produitListBox.Items.Remove(prod);
                    }
                }
            }
        }
    }
}
