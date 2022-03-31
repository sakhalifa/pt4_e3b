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
    public partial class AjouterRDV : Form
    {
        // New ClientController
        private ClientController _clientController;

        // Constructor
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

        private void buttonConfirmer_Click(object sender, EventArgs e)
        {
            // If there is no reason written
            if(textBoxRaison.Text == null)
            {
                Utils.ShowError("Veuillez insérer une raison au rendez-vous");
            }
            // If there is no customer chosen
            if(comboBoxClient.SelectedItem == null)
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
