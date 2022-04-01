using PT4.Controllers;
using PT4.Templates;
using System;
using System.Windows.Forms;

namespace PT4
{
    public partial class AjouterAnimal : TemplateAnimal
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="animalController">Instance of AnimalController</param>
        /// <param name="clientController">Instance of ClientController</param>
        /// <param name="c">Instance of CLIENT</param>
        public AjouterAnimal(AnimalController animalController, ClientController clientController, CLIENT c) : base(animalController, clientController, c, false)
        {
        }

        /// <summary>
        /// It creates the animal if all the constraint are validated
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected override void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (CheckRemplissage())
            {
                string strNom = null;
                if (nom.TextLength > 0)
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
