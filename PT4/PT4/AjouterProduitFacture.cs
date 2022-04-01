using PT4.Controllers;
using System.Windows.Forms;

namespace PT4
{
    public partial class AjouterProduitFacture : Form
    {
        /// <summary>
        /// Instance of PRODUIT
        /// </summary>
        public PRODUIT prodSelected { get; private set; }

        /// <summary>
        /// Quantity of product
        /// </summary>
        public short quantiteProd { get => (short)quantite.Value; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="produitController">Instance of ProduitController</param>
        public AjouterProduitFacture(ProduitController produitController)
        {
            InitializeComponent();
            var listProd = produitController.GetAllSellableProducts();
            foreach (var prod in listProd)
            {
                listBox1.Items.Add(prod);
            }
        }

        /// <summary>
        /// List of  all products
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                this.prodSelected = (PRODUIT)listBox1.Items[index];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
