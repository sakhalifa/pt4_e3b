using Microsoft.Extensions.DependencyInjection;
using PT4.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PT4
{
    public partial class AjouterOrdonnance : Form
    {
        /// <summary>
        /// Instance of ordonnanceController
        /// </summary>
        private OrdonnanceController _ordonnanceController;
        /// <summary>
        /// Instance of animalController
        /// </summary>
        private AnimalController _animalController;
        /// <summary>
        /// Instance of ServiceCollection
        /// </summary>
        private ServiceCollection _services;
        /// <summary>
        /// Instance of ANIMAL
        /// </summary>
        private ANIMAL _animal;

        /// <summary>
        /// Constructior
        /// </summary>
        /// <param name="animalController">Instance of animalController</param>
        /// <param name="ordonnanceController">Instance of ordonnanceController</param>
        /// <param name="soinController">Instance of soinController</param>
        /// <param name="services">Instance of ServiceCollection</param>
        /// <param name="animal">Instance of ANIMAL</param>
        public AjouterOrdonnance(AnimalController animalController, OrdonnanceController ordonnanceController, SoinController soinController, ServiceCollection services, ANIMAL animal)
        {
            InitializeComponent();
            _ordonnanceController = ordonnanceController;
            _animalController = animalController;
            _services = services;
            labelAnimal.Text = animal.NOMANIMAL;
            _animal = animal;

            foreach (SOIN s in soinController.FindAll())
            {
                soinsDispo.Items.Add(s);
            }

            soinController.SubscribeSoins(OnChanged);
            soinController.SubscribeDeleteSoins(OnDelete);

            this.Closed += (_, __) => { soinController.UnSubscribeSoins(OnChanged); soinController.UnSubscribeDeleteSoins(OnDelete); };
        }

        /// <summary>
        /// It shows the window where you can create a prescription
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _services.AddScoped<TemplateSoin>();
            using (ServiceProvider provider = _services.BuildServiceProvider())
            {
                using (IServiceScope serviceScope = provider.CreateScope())
                {
                    var dlg = serviceScope.ServiceProvider.GetService<TemplateSoin>();
                    dlg.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Function which is called whenever there is an order updated or added
        /// </summary>
        /// <param name="soins">All the cure which has been added or updated</param>
        private void OnChanged(IEnumerable<SOIN> soins)
        {
            HashSet<SOIN> addedSoins = new HashSet<SOIN>(soins);
            IEnumerable<SOIN> castedItems = soinsDispo.Items.Cast<SOIN>();
            foreach (SOIN ss in soins)
            {
                int ind = 0;
                foreach (SOIN s in castedItems)
                {
                    if (s.ID == ss.ID)
                    {
                        soinsDispo.Items[ind] = ss;
                        addedSoins.Remove(ss);
                    }
                    ind++;
                }
            }

            foreach (SOIN s in addedSoins)
            {
                soinsDispo.Items.Add(s);
            }

        }
        /// <summary>
        /// Function which is called whenever there is an order which is deleted 
        /// </summary>
        /// <param name="soins">All the cure which has been deleted</param>
        private void OnDelete(IEnumerable<SOIN> soins)
        {
            IEnumerable<SOIN> castedItems = soinsDispo.Items.Cast<SOIN>();
            foreach (SOIN ss in soins)
            {
                foreach (SOIN s in castedItems)
                {
                    if (s.ID == ss.ID)
                    {
                        soinsDispo.Items.Remove(s);

                    }
                }
            }
        }

        /// <summary>
        /// Add a cure to an animal
        /// </summary>
        /// <param name="sender"> object </param>
        /// <param name="e"> EventArgs </param>
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (soinsDispo.SelectedItems is null || soinsDispo.SelectedItems.Count == 0)
            {
                Utils.ShowError("ERREUR! Veuillez sélectionner au moins un soin!");
                return;
            }
            _ordonnanceController.CreerOrdonnance(_animal, soinsDispo.SelectedItems.Cast<SOIN>());
            MessageBox.Show($"Vous avez bien créé l'ordonnance pour l'animal {_animal.NOMANIMAL}");
            this.Close();
        }
    }
}
