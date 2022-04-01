using PT4.Controllers;
using System;
using System.Windows.Forms;

namespace PT4
{
    public partial class AjouterMaladie : Form
    {
        private MaladiesController _maladieController;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maladiesController"> an instance of a maladieController</param>
        public AjouterMaladie(MaladiesController maladiesController)
        {
            InitializeComponent();
            _maladieController = maladiesController;
        }

        /// <summary>
        /// The button which fills the database with the informations given
        /// </summary>
        /// <param name="sender"> object </param>
        /// <param name="e"> EventArgs  </param>
        private void buttonConfirmer_Click(object sender, EventArgs e)
        {
            // If there is no test in the textbox, it tells you that you have to write
            if (textBoxMaladie.Text == null)
            {
                Utils.ShowError("Veuillez inscrire le nom d'une maladie");
            }
            else
            {
                // If everything's ok, it creates the new disease
                try
                {
                    _maladieController.CreerMaladie(textBoxMaladie.Text);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                // if not, it shows the error
                catch (Exception ex)
                {
                    Utils.ShowError(ex.Message);
                    return;
                }
            }
        }
    }
}
