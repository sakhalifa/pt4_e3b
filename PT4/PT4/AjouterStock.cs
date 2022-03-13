﻿using PT4.Controllers;
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

        private bool canEnterAgain = true;

        public AjouterStock(ProduitController prodController)
        {
            InitializeComponent();
            modifier.Visible = false;
            _prodController = prodController;
        }

        private void buttonConfirmer_Click(object sender, EventArgs e)
        {
            if (CheckRemplissage()) { 

                _prodController.CreerOuMaJProduit(nom.Text, prixVente.Value, prixAchat.Value, (int)quantite.Value, description.Text, estMedic.Checked, true);
                MessageBox.Show($"Vous avez bien rajouté {quantite.Value} '{nom.Text}' vendu à {prixVente.Value}€ et acheté à {prixAchat.Value}€");
            }
        }

        private void modifier_Click(object sender, EventArgs e)
        {
            if (CheckRemplissage())
            {

                _prodController.CreerOuMaJProduit(nom.Text, prixVente.Value, prixAchat.Value, (int)quantite.Value, description.Text, estMedic.Checked, false);
                MessageBox.Show($"Vous avez bien modifié le produit '{nom.Text}'. Il y en a {quantite.Value} en stocks vendu à l'unité à {prixVente.Value}€ et acheté à l'unité {prixAchat.Value}€");
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
            if(quantite.Value < 0)
            {
                MessageBox.Show("ERREUR! La quantité ne peut pas être négative!");
                return false;
            }
            if(prixVente.Value <= 0)
            {
                MessageBox.Show("ERREUR! Le prix de vente ne peut pas être nul ou inférieur à 0!");
                return false;
            }
            if(prixAchat.Value <= 0)
            {
                MessageBox.Show("ERREUR! Le prix d'achat ne peut pas être nul ou inférieur à 0!");
                return false;
            }
            if(prixVente.Value < prixAchat.Value)
            {
                MessageBox.Show("ERREUR! Vous ne pouvez vendre à perte!");
                return false;
            }

            return true;
            
        }

        private void nom_KeyDown(object sender, KeyEventArgs e)
        {
            if (canEnterAgain) { 
                if(e.KeyData == Keys.Enter)
                {
                    canEnterAgain = false;
                    UpdateLabelsIfExist();
                    //On attend 1s avant de réautoriser à appuyer sur entrée
                    Task.Delay(1000).ContinueWith((_) => canEnterAgain = true) ;
                }

            }
        }

        private void UpdateLabelsIfExist()
        {
            string name = nom.Text;
            PRODUIT p = _prodController.FindByName(name);
            if(p != null)
            {
                prixAchat.Value = p.PRIXACHAT;
                prixVente.Value = p.PRIXDEVENTE.GetValueOrDefault(-1);
                quantite.Value = p.QUANTITEENSTOCK;
                description.Text = p.DESCRIPTION;
                modifier.Visible = true;
            }
        }

        private void nom_TextChanged(object sender, EventArgs e)
        {
            modifier.Visible = false;
        }

        
    }
}
