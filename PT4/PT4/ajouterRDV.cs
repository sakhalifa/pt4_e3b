using PT4.Controllers;
using System;
using System.Windows.Forms;

namespace PT4
{
    public partial class AjouterRDV : Form
    {
        /// <summary>
        /// Instance of ClientController
        /// </summary>
        private ClientController _clientController;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientController">Instance of ClientController</param>
        public AjouterRDV(ClientController clientController)
        {
            InitializeComponent();
            _clientController = clientController;
            // It insert the customers of the database in the combobox
            foreach (var c in clientController.ListCustomers())
            {
                comboBoxClient.Items.Add(c);
            }
        }


        public void SetClient(CLIENT c)
        {
            comboBoxClient.Items.Clear();
            comboBoxClient.Items.Add(c);
            comboBoxClient.SelectedItem = c;
        }

        /// <summary>
        /// If the constraints are validated, it creates the new appointment
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>

        private void buttonConfirmer_Click(object sender, EventArgs e)
        {
            // If there is no reason written
            if (textBoxRaison.Text == null)
            {
                Utils.ShowError("Veuillez insérer une raison au rendez-vous");
            }
            // If there is no customer chosen
            if (comboBoxClient.SelectedItem == null)
            {
                Utils.ShowError("Veuillez sélectionner un client");
            }
            // If the date / hour chosen for the appointment are already passed
            else if (dateTimePicker1.Value < DateTime.Now)
            {
                Utils.ShowError("Veuillez insérer une date valide");
            }

            else
            {

                // If everything's ok, it creates the new appointment
                try
                {
                    _clientController.CreerRendezVous((CLIENT)comboBoxClient.SelectedItem, dateTimePicker1.Value, textBoxRaison.Text, dateTimePicker1.Value.AddHours(1));
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Le rendez-vous a bien été créé pour le " + dateTimePicker1.Value);
                    this.Close();
                }
                // if not, it shows the error
                catch (ArgumentException ex)
                {
                    Utils.ShowError(ex.Message);
                    return;
                }
            }

        }
    }
}
