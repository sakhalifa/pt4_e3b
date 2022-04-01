using PT4.Controllers;
using PT4.Model.dal;
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
    public partial class AjouterCompte : Form
    {
        /// <summary>
        /// Instance of SalarieController
        /// </summary>
        private SalarieController _salarieController;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="salarieController">Instance of SalarieController</param>
        public AjouterCompte(SalarieController salarieController)
        {
            InitializeComponent();
            _salarieController = salarieController;
        }

        /// <summary>
        /// Function which shows the window to fill personnal datas of the new salary
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            SALARIÉ s = null;
            if (textBoxCompte.Text.Length == 0)
            {
                Utils.ShowError("Veuillez saisir un nom de compte.");
            }

            else if (textBoxMdp.Text.Length == 0)
            {
                Utils.ShowError("Veuillez saisir un mot de passe. ");

            }

            else if (textBoxMdp.Text.Length <= 5)
            {
                Utils.ShowError("Mot de passe trop court.");
            }

            else if (textBoxMdp.Text != confirmerMotDePasse.Text)
            {
                Utils.ShowError("Les mots de passes ne sont pas les mêmes");
            }

            else if (textBoxMdp.Text == textBoxCompte.Text)
            {
                Utils.ShowError("Le mot de passe doit être différent du login");
            }

            else
            {

                try
                {
                    s = _salarieController.CreerSalarie(textBoxCompte.Text, textBoxMdp.Text);
                    DonneesPersonnelles donnees = new DonneesPersonnelles(_salarieController, s);

                    donnees.ShowDialog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex.Message);
                    return;
                }
            }







        }
    }
}
