using PT4.Controllers;
using PT4.Templates;
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
    public partial class AjouterAnimal : TemplateAnimal
    {

        public AjouterAnimal(AnimalController animalController, ClientController clientController) : base(animalController, clientController)
        {
        }

        public AjouterAnimal(AnimalController animalController, ClientController clientController,CLIENT c) : base(animalController, clientController, c, false)
        {
        }
        
        protected override void buttonConfirm_Click(object sender, EventArgs e)
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
    }
}
