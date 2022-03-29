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
    public partial class AjouterFacture : Form
    {
        private FactureController _factureController;
        private FACTURE f;

        public AjouterFacture(FactureController factureController, ClientController clientController)
        {
            InitializeComponent();
            _factureController = factureController;
            foreach(CLIENT c in clientController.ListCustomers())
            {
                clients.Items.Add(c);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }

        private void clients_SelectedIndexChanged(object sender, EventArgs e)
        {
            produits.Rows.Clear();
            montantFacture.Value = 0;
            _factureController.Reset();
            f = _factureController.CreerFacture((CLIENT)clients.SelectedItem);
        }
    }
}
