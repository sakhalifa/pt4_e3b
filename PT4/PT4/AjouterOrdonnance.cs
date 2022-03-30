using Microsoft.Extensions.DependencyInjection;
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
    public partial class AjouterOrdonnance : Form
    {
        private OrdonnanceController _ordonnanceController;
        private AnimalController _animalController;
        private ServiceCollection _services;
        private ANIMAL _animal;

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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _services.AddScoped<TemplateSoin>();
            using(ServiceProvider provider = _services.BuildServiceProvider())
            {
                using (IServiceScope serviceScope = provider.CreateScope())
                {
                    var dlg = serviceScope.ServiceProvider.GetService<TemplateSoin>();
                    dlg.ShowDialog();
                }
            }
        }

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

            foreach(SOIN s in addedSoins)
            {
                soinsDispo.Items.Add(s);
            }
            
        }

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

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if(soinsDispo.SelectedItems is null || soinsDispo.SelectedItems.Count == 0)
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
