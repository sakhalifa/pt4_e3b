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
    public partial class AjouterClient : Form
    {
        private ClientController _clientController;

        public AjouterClient(ClientController clientController)
        {
            InitializeComponent();
            _clientController = clientController;
        }

        private bool CheckRemplissage()
        {
            if(nom.TextLength == 0)
            {
                Utils.ShowError("ERREUR! Vous devez rentrer un nom!");
                return false;
            }
            if(prenom.TextLength == 0)
            {
                Utils.ShowError("ERREUR! Vous devez rentrer un prénom!");
                return false;
            }if(email.TextLength == 0)
            {
                Utils.ShowError("ERREUR! Vous devez rentrer un email!");
                return false;
            }
            try
            {
                var _ = new System.Net.Mail.MailAddress(email.Text);
            }
            catch
            {
                Utils.ShowError("ERREUR! Veuillez rentrer un email correctement formaté!");
                return false;
            }
            if(numeroTel.Text.Trim().Length > 0 && !numeroTel.MaskCompleted)
            {
                Utils.ShowError("ERREUR! Veuillez soit ne pas mettre de numéro soit le mettre au complet!");
                return false;
            }
            return true;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if (CheckRemplissage())
            {
                string num = null;
                if(numeroTel.TextLength > 0)
                {
                    num = numeroTel.Text.Replace(" ", "");
                }

                try
                {
                    _clientController.CreerClient(nom.Text, prenom.Text, num, email.Text);
                    MessageBox.Show($"Vous avez bien créé le client '{nom.Text} {prenom.Text}'");
                    this.Close();
                }catch (ArgumentException ex){
                    Utils.ShowError(ex.Message);
                }
            }
        }
    }
}
