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
    public partial class DeclarerMaladie : Form
    {
        private MaladiesController _maladieController;
        private ANIMAL _animal;
        public DeclarerMaladie(MaladiesController maladiesController, ANIMAL animal)
        {
            InitializeComponent();
            _maladieController = maladiesController;
            _animal = animal;
        }

        private void buttonConfirmer_Click(object sender, EventArgs e)
        {
            if(comboBoxMaladie.SelectedItem == null )
            {
                Utils.ShowError("Veuillez sélectionner une maladie");
            }
            else if(dateTimePickerDebut.Value >= DateTime.Now)
            {
                Utils.ShowError("Veuillez sélectionner une date valide");
            }


            else
            {

            }
        }
    }
}
