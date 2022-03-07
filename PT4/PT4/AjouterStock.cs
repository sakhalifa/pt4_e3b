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
    public partial class AjouterStock : Form
    {
        private ProduitController _prodController;

        public AjouterStock(ProduitController prodController)
        {
            InitializeComponent();
            _prodController = prodController;
        }

        private void buttonConfirmer_Click(object sender, EventArgs e)
        {
            if (CheckRemplissage()) { 

                _prodController.CreerOuMaJProduit(nom.Text, prixVente.Value, prixAchat.Value, (int)quantite.Value, description.Text, estMedic.Checked, true);
            }
        }

        private bool CheckRemplissage()
        {
            if(nom.Text.Length == 0)
            {
                MessageBox.Show("ERREUR! Veuillez rentrer un nom pour le produit!");
                return false;
            }
            if((quantite.Value % 1) != 0){
                MessageBox.Show("ERREUR! La quantité doit être un nombre entier!");
                return false;
            }

            return true;
            
        }
    }
}
