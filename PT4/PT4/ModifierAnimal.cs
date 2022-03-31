using PT4.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PT4
{
    public partial class ModifierAnimal : PT4.Templates.TemplateAnimal
    {
        private ANIMAL _animal;

        public ModifierAnimal(AnimalController animalController, ClientController clientController, ANIMAL animal) : base(animalController, clientController, animal.CLIENT, true)
        {
            InitializeComponent();
            if (animal.DATENAISSANCE.HasValue)
            {
                this.dateNaissance.Value = animal.DATENAISSANCE.Value;
            }
            nom.Text = animal.NOMANIMAL;
            espece.Text = animal.NOMESPECE;
            race.Text = animal.NOMRACE;
            taille.Value = animal.TAILLE;
            poids.Value = animal.POIDS;
            this._animal = animal;

        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (CheckRemplissage())
            {
                string strNom = null;
                if (nom.TextLength > 0)
                {
                    strNom = nom.Text;
                }
                _animalController.ModifierAnimal(_animal, (CLIENT)clients.SelectedItem, espece.Text, race.Text, strNom, dateNaissance.Value, (short)taille.Value, poids.Value);
                MessageBox.Show($"Vous avez bien modifié l'animal!");
                this.Close();
            }
        }
    }
}
