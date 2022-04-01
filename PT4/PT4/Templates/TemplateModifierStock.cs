using PT4.Controllers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PT4
{
    public partial class TemplateModifierStock : Form
    {
        protected ProduitController _prodController;

        protected virtual bool IsAdd { get; set; } = true;

        //I am forced to do this because Visual Studio NEEDS a blank constructor to show the inherited components.
        //Stupid.
        private TemplateModifierStock()
        {
            InitializeComponent();
        }

        public TemplateModifierStock(ProduitController prodController)
        {
            InitializeComponent();
            _prodController = prodController;

            if (!Utils.connecteAdmin)
            {
                estMedic.Visible = false;
            }
        }

        private void buttonConfirmer_Click(object sender, EventArgs e)
        {
            if (CheckRemplissage())
            {
                decimal? prixDeVente = null;
                if (vendable.Checked)
                {
                    prixDeVente = prixVente.Value;
                }
                _prodController.CreerOuMaJProduit(nom.Text, prixDeVente, prixAchat.Value, (int)quantite.Value, description.Text, estMedic.Checked, IsAdd);
                if (prixVente is null)
                {
                    MessageBox.Show($"Vous avez bien rajouté {quantite.Value} '{nom.Text}' invendable et acheté à {prixAchat.Value}€");
                }
                else
                {
                    MessageBox.Show($"Vous avez bien rajouté {quantite.Value} '{nom.Text}' vendu à {prixVente.Value}€ et acheté à {prixAchat.Value}€");
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        protected bool CheckRemplissage()
        {
            if (nom.Text.Length == 0)
            {
                Utils.ShowError("ERREUR! Veuillez rentrer un nom pour le produit!");
                return false;
            }
            if ((quantite.Value % 1) != 0)
            {
                Utils.ShowError("ERREUR! La quantité doit être un nombre entier!");
                return false;
            }
            if (quantite.Value < 0)
            {
                Utils.ShowError("ERREUR! La quantité ne peut pas être négative!");
                return false;
            }
            if (prixAchat.Value <= 0)
            {
                Utils.ShowError("ERREUR! Le prix d'achat ne peut pas être nul ou inférieur à 0!");
                return false;
            }
            if (prixVente.Enabled && prixVente.Value <= 0)
            {
                Utils.ShowError("ERREUR! Le prix de vente ne peut pas être nul ou inférieur à 0!");
                return false;
            }
            if (prixAchat.Value < prixAchat.Value)
            {
                Utils.ShowError("ERREUR! Vous ne pouvez vendre à perte!");
                return false;
            }

            if (nom.Enabled && _prodController.FindByName(nom.Text) != null)
            {
                Utils.ShowError("ERREUR! Ce produit est déjà dans la base de données. Merci de le modifier via le menu contextuel!");
                return false;
            }

            return true;

        }

        public virtual void SetProduit(PRODUIT p)
        {
            nom.Text = p.NOMPRODUIT;
            nom.Enabled = false;
            nom.BackColor = Color.LightGray;
            prixVente.Value = p.PRIXDEVENTE.GetValueOrDefault(0);
            prixAchat.Value = p.PRIXACHAT;
            description.Text = p.DESCRIPTION;
            estMedic.Checked = p.MEDICAMENT;
            vendable.Checked = p.PRIXDEVENTE.HasValue;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            prixVente.Enabled = vendable.Checked;
            if (!prixVente.Enabled)
            {
                prixVente.BackColor = Color.LightGray;
            }
            else
            {
                prixVente.BackColor = Color.White;
            }
        }
    }
}
