using PT4.Controllers;
using System;
using System.Windows.Forms;

namespace PT4
{
    public partial class ModifierMdp : Form
    {
        /// <summary>
        /// Instance of SALARIE
        /// </summary>
        private SALARIÉ _salarie;

        /// <summary>
        /// Instance of SalarieController
        /// </summary>
        private SalarieController _salarieController;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="contr">Instance of SalarieController</param>
        /// <param name="salarieId">salarieId</param>
        public ModifierMdp(SalarieController contr, int salarieId)
        {
            InitializeComponent();
            _salarie = contr.GetSalarieFromId(salarieId);
            _salarieController = contr;
        }

        /// <summary>
        /// If all the constraints are validated, it changes the password
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void buttonConfirmation_Click(object sender, EventArgs e)
        {
            if (textBoxNewMdp.TextLength == 0)
            {
                Utils.ShowError("ERREUR! Veuillez mettre un nouveau mdp");
                return;
            }
            if (textBoxConfirmerMdp.TextLength == 0)
            {
                Utils.ShowError("ERREUR! Veuillez confirmer le mdp rentré");
                return;
            }
            if (textBoxConfirmerMdp.Text != textBoxNewMdp.Text)
            {
                Utils.ShowError("ERREUR! Le mot de passe et celui de confirmation ne correspondent pas!");
                return;
            }

            if (MessageBox.Show("Êtes-vous sur?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    _salarieController.ChangerMotDePasse(_salarie, textBoxConfirmerMdp.Text);
                    this.Close();
                }
                catch (ArgumentException ex)
                {
                    Utils.ShowError(ex.Message);
                }
            }

        }
    }
}
