using PT4.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT4
{
    public partial class ModifierMdp : Form
    {
        private SALARIÉ _salarie;
        private SalarieController _salarieController;

        public ModifierMdp(SalarieController contr, int salarieId)
        {
            InitializeComponent();
            _salarie = contr.GetSalarieFromId(salarieId);
            _salarieController = contr;
        }

        private void textBoxNewMdp_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxConfirmerMdp_TextChanged(object sender, EventArgs e)
        {

        }

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
                }catch (ArgumentException ex)
                {
                    Utils.ShowError(ex.Message);
                }
            }

        }
    }
}
