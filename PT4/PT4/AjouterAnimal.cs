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
    public partial class AjouterAnimal : Form
    {
        private AnimalController _animalController;
        private ClientController _clientController;

        public AjouterAnimal(AnimalController animalController, ClientController clientController)
        {
            _animalController = animalController;
            _clientController = clientController;
            InitializeComponent();
            foreach(CLIENT c in _clientController.ListCustomers())
            {
                clients.Items.Add(c);
            }
        }

        public AjouterAnimal(AnimalController animalController, ClientController clientController,CLIENT c)
        {
            _animalController = animalController;
            _clientController = clientController;
            InitializeComponent();
            clients.Items.Add(c);
            clients.SelectedIndex = 0;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (CheckRemplissage())
            {
                string strNom = null;
                if(nom.TextLength > 0)
                {
                    strNom = nom.Text;
                }
                _animalController.CreerAnimal((CLIENT)clients.SelectedItem, espece.Text, race.Text, strNom, dateNaissance.Value, (short)taille.Value, poids.Value);
                MessageBox.Show($"Vous avez bien créé l'animal '{nom.Text}' pour le client '{clients.SelectedItem}'");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool CheckRemplissage()
        {
            if(espece.TextLength == 0)
            {
                Utils.ShowError("ERREUR! Vous devez spécifier une espèce!");
                return false;
            }
            if(race.TextLength == 0)
            {
                Utils.ShowError("ERREUR! Vous devez spécifier une race!");
                return false;
            }
            if(dateNaissance.Value > DateTime.Now)
            {
                Utils.ShowError("ERREUR! Vous ne pouvez pas prédire la date de naissance!");
                return false;
            }
            if(taille.Value == 0)
            {
                Utils.ShowError("ERREUR! Il est très peu probable qu'un animal fasse 0cm...");
                return false;
            }
            if(poids.Value == 0)
            {
                Utils.ShowError("ERREUR! Il est très peu probable qu'un animal fasse 0kg...");
                return false;
            }

            return true;
        }
    }
}
