using PT4.Controllers;
using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT4
{
    public partial class DonneesPersonnelles : Form
    {
        /// <summary>
        /// Instance of SalarieController
        /// </summary>
        private SalarieController _salarieController;

        /// <summary>
        /// Instance of SALARIE
        /// </summary>
        private SALARIÉ _salarie;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="controller">Instance of SalarieController</param>
        /// <param name="s">Instance of SALARIE</param>
        public DonneesPersonnelles(SalarieController controller, SALARIÉ s)
        {
            InitializeComponent();
            _salarieController = controller;
            _salarie = s;
        }

        /// <summary>
        /// If all the constraints are validated, it creates the new account with the personal data
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void buttonConfirmer_Click(object sender, EventArgs e)
        {

            if (textBoxMailDonnees.Text.Length == 0 )
            {
                Utils.ShowError("Veuillez entrer une adresse mail");
            }
            try
            {
                var _ = new System.Net.Mail.MailAddress(textBoxMailDonnees.Text);
            }
            catch
            {
                Utils.ShowError("ERREUR! Veuillez rentrer un email correctement formaté!");
                return;
            }

            if ((Regex.IsMatch(textBoxNumero.Text, @"^[+]\d+$") && textBoxNumero.Text.Length != 12) 
                || (Regex.IsMatch(textBoxNumero.Text, @"^\d+$") && textBoxNumero.Text.Length != 10)
                || (!Regex.IsMatch(textBoxNumero.Text, @"^\d+$") && !Regex.IsMatch(textBoxNumero.Text, @"^[+]\d+$")))
            {
                    Utils.ShowError("Ce numéro est invalide");
            }
            else if (textBoxNumero.Text.Length >12 )
            {
                Utils.ShowError("Ce numéro est invalide");

            }

            else if (numericUpDownAge.Value < 14)
            {
                Utils.ShowError("Sélectionnez un âge valide");
            }
            else if (comboBoxSexe.SelectedItem == null)
            {
                Utils.ShowError("Sélectionnez un sexe valide");
            }
            else
            {

                try
                {
                    _salarieController.DonneesPersoSalarie(_salarie, $"{comboBoxSexe.SelectedItem};{numericUpDownAge.Value};{textBoxNumero.Text};{textBoxMailDonnees.Text}");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex.Message);
                }
            }
        }

 
    }
}
