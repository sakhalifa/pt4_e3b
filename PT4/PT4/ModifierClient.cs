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
    public partial class ModifierClient : Form
    {
        private ClientController _clientController;
        private AnimalController _animalController;
        private CLIENT client;

        public ModifierClient(ClientController clientController, AnimalController animalController)
        {
            InitializeComponent();
            _clientController = clientController;
            _animalController = animalController;
        }

        public void SetClient(CLIENT c)
        {
            this.client = c;
            nomTextBox.Text = c.NOMCLIENT;
            prenomTextBox.Text = c.PRENOMCLIENT;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {

        }
    }
}
