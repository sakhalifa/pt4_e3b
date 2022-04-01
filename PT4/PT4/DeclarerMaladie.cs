using PT4.Controllers;
using System;
using System.Windows.Forms;

namespace PT4
{
    public partial class DeclarerMaladie : Form
    {
        /// <summary>
        /// Instance of AnimalController
        /// </summary>
        private AnimalController _animalController;

        /// <summary>
        /// Instance of ANIMAL
        /// </summary>
        private ANIMAL _animal;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maladiesController">Instance of MaladieController</param>
        /// <param name="animalController">Instance of AnimalController</param>
        /// <param name="animal">Instance of ANIMAL</param>
        public DeclarerMaladie(MaladiesController maladiesController, AnimalController animalController, ANIMAL animal)
        {
            InitializeComponent();
            _animalController = animalController;
            _animal = animal;
            // it fills the combobox which contains the diseases
            foreach (var c in maladiesController.ListerMaladies())
            {
                comboBoxMaladie.Items.Add(c);
            }

        }

        /// <summary>
        /// If all the constraints are validated, it creates the new disease
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void buttonConfirmer_Click(object sender, EventArgs e)
        {
            // If there is no disease selected
            if (comboBoxMaladie.SelectedItem == null)
            {
                Utils.ShowError("Veuillez sélectionner une maladie");

            }

            // If the date chosen is impossible (foresight)
            else if (dateTimePickerDebut.Value.Date > DateTime.Now.Date)
            {
                Utils.ShowError("Veuillez sélectionner une date valide");
            }


            else
            {
                // If everything is ok, the database is filled, the animal gets its disease.
                try
                {
                    _animalController.AddSickness(_animal, (MALADIE)comboBoxMaladie.SelectedItem, dateTimePickerDebut.Value.Date);
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
