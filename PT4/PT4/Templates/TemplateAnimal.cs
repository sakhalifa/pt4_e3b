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

namespace PT4.Templates
{
    public partial class TemplateAnimal : Form
    {
        protected AnimalController _animalController;
        protected ClientController _clientController;

        private TemplateAnimal()
        {
            InitializeComponent();
        }

        public TemplateAnimal(AnimalController animalController, ClientController clientController)
        {
            _animalController = animalController;
            _clientController = clientController;
            InitializeComponent();
            foreach (CLIENT c in _clientController.ListCustomers())
            {
                clients.Items.Add(c);
            }
        }

        public TemplateAnimal(AnimalController animalController, ClientController clientController, CLIENT c, bool allowChange)
        {
            _animalController = animalController;
            _clientController = clientController;
            InitializeComponent();
            if (!allowChange) { 
                clients.Items.Add(c);
                clients.SelectedIndex = 0;
            }
            else
            {
                foreach (CLIENT cc in _clientController.ListCustomers())
                {
                    clients.Items.Add(cc);
                }

                clients.SelectedItem = c;
            }
        }

        protected bool CheckRemplissage()
        {
            if (espece.TextLength == 0)
            {
                Utils.ShowError("ERREUR! Vous devez spécifier une espèce!");
                return false;
            }
            if (race.TextLength == 0)
            {
                Utils.ShowError("ERREUR! Vous devez spécifier une race!");
                return false;
            }
            if (dateNaissance.Value > DateTime.Now)
            {
                Utils.ShowError("ERREUR! Vous ne pouvez pas prédire la date de naissance!");
                return false;
            }
            if (taille.Value == 0)
            {
                Utils.ShowError("ERREUR! Il est très peu probable qu'un animal fasse 0cm...");
                return false;
            }
            if (poids.Value == 0)
            {
                Utils.ShowError("ERREUR! Il est très peu probable qu'un animal fasse 0kg...");
                return false;
            }

            return true;
        }

        protected virtual void buttonConfirm_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
