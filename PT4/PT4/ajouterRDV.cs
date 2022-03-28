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
    public partial class ajouterRDV : Form
    {

        private ClientController _clientController;
        private CLIENT _client;
        public ajouterRDV(CLIENT client, ClientController clientController)
        {
            InitializeComponent();
            _client = client;
            _clientController = clientController;
        }


        private void buttonConfirmer_Click(object sender, EventArgs e)
        {
            if(textBoxRaison.Text == null)
            {
                Utils.ShowError("Veuillez insérer une raison au rendez-vous");
            }
            else if (textBoxNomClient == null)
            {
                Utils.ShowError("Veuillez insérer un nom valide");
            }
            else if (dateTimePicker1.Value.Date < DateTime.Today)
            {
                Utils.ShowError("Veuillez insérer une date valide");
            }

            else
            {
                try
                {
                  //  _clientController.CreerRendezVous(dateTimePicker1.Value.Date, textBoxRaison.Text, dateTimePicker1.Value.Date.AddHours(1));
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
