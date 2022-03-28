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
    public partial class CreerPrescription : Form
    {
        private OrdonnanceController _orderController;
        private ClientController _customerController;
        private AnimalController _animalController;
        private SoinController _careController;

        public CreerPrescription(OrdonnanceController orderController, ClientController customerController, AnimalController animalController, SoinController careController)
        {
            _orderController = orderController;
            _customerController = customerController;
            _animalController = animalController;
            _careController = careController;
            InitializeComboBoxCares();
            InitializeComboBoxCustomers();
            InitializeComboBoxAnimals();
            InitializeComponent();
        }

        /// <summary>
        /// Add a new order in the database if conditions are checked
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxAnimal.SelectedItem != null && numericUpDownPrix.Value != 0 && comboBoxProduit.SelectedItem != null)
            {
                _orderController.CreerOrdonnance(DateTime.Now, (ANIMAL) comboBoxAnimal.SelectedItem, (SOIN) comboBoxProduit.SelectedItem);
            }
        }

        /// <summary>
        /// Initialize the customer combo box
        /// </summary>
        private void InitializeComboBoxCustomers()
        {
            IQueryable<CLIENT> customers = _customerController.FindAll();
            foreach (CLIENT customer in customers) {
                comboBoxClient.Items.Add(customer);
            }
        }

        /// <summary>
        /// Initialize the animal combo box
        /// </summary>
        private void InitializeComboBoxAnimals()
        {
            IQueryable<ANIMAL> animals = _animalController.FindAll();
            foreach (ANIMAL animal in animals)
            {
                comboBoxAnimal.Items.Add(animal);
            }
        }

        /// <summary>
        /// Initialize the animal combo box
        /// </summary>
        private void InitializeComboBoxCares()
        {
            IQueryable<SOIN> cares = _careController.FindAll();
            foreach (SOIN care in cares)
            {
                comboBoxProduit.Items.Add(care);
            }
        }

        private void comboBoxProduit_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxDescription.Text += comboBoxProduit.SelectedItem.ToString();
        }
    }
}
