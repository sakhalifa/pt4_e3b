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
    public partial class AfficherOrdonnance : Form
    {
        /// <summary>
        /// Instance of OrdonnanceController
        /// </summary>
        private OrdonnanceController _ordonnanceController;

        /// <summary>
        /// Instance of ServiceCollection
        /// </summary>
        private ServiceCollection _services;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ordonnanceController"> Instance of OrdonnanceController</param>
        /// <param name="clientController"> Instance of ClientController</param>
        /// <param name="service"> Instance of ServiceCollection</param>
        public AfficherOrdonnance(OrdonnanceController ordonnanceController, ClientController clientController, ServiceCollection service)
        {
            InitializeComponent();
            _ordonnanceController = ordonnanceController;
            _services = service;

            foreach (CLIENT c in clientController.FindAll())
            {
                clientComboBox.Items.Add(c);
            }

            _ordonnanceController.SubscribePrescription(OnChanged);
            _ordonnanceController.SubscribeDeletePrescription(OnDelete);

            this.Closed += (_, __) => { _ordonnanceController.UnSubscribePrescription(OnChanged); _ordonnanceController.UnSubscribeDeletePrescription(OnDelete); };
        }

        /// <summary>
        /// Function which is called whenever there is an ordonnance which is deleted 
        /// </summary>
        /// <param name="args"> The ordonnance which were delete</param>
        private void OnDelete(IEnumerable<ORDONNANCE> args)
        {
            HashSet<ORDONNANCE> careToRemove = new HashSet<ORDONNANCE>();
            IEnumerable<ORDONNANCE> castedItems = allOrdo.Items.Cast<ORDONNANCE>();
            foreach (ORDONNANCE oo in args)
            {
                foreach (ORDONNANCE o in castedItems)
                {
                    if (o.ID == oo.ID)
                    {
                        careToRemove.Add(o);
                    }
                }
            }

            foreach (ORDONNANCE o in careToRemove)
            {
                allOrdo.Items.Remove(o);
            }

        }

        /// <summary>
        /// Function which is called whenever there is an ordonnance updated or added
        /// </summary>
        /// <param name="args"> All the ordonnance which has been added or updated</param>
        private void OnChanged(IEnumerable<ORDONNANCE> args)
        {
            if (animalComboBox.SelectedItem != null)
            {
                //We can directly do this because a prescription will NEVER be modified.
                IEnumerable<ORDONNANCE> forSelectedAnimal = args.Where((o) => o.ANIMAL == (ANIMAL)animalComboBox.SelectedItem);
                foreach (ORDONNANCE s in forSelectedAnimal)
                {
                    allOrdo.Items.Add(s);
                }
            }
        }
        

        /// <summary>
        /// Function which deletes the cure chosen
        /// </summary>
        /// <param name="sender"> object </param>
        /// <param name="e"> EventArgs </param>
        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allOrdo.SelectedItem != null)
            {
                if (MessageBox.Show("Voulez-vous vraiment supprimer ce soin?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _ordonnanceController.DeletePrescription((ORDONNANCE)allOrdo.SelectedItem);
                    MessageBox.Show("Vous avez bien supprimé ce soin!");
                }
            }
        }

        /// <summary>
        /// Function which shows the window where you could add the ordonnance
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (animalComboBox.SelectedItem != null)
            {
                ANIMAL a = (ANIMAL)animalComboBox.SelectedItem;
                _services.AddScoped((p) => new AjouterOrdonnance(p.GetRequiredService<AnimalController>(),
                    p.GetRequiredService<OrdonnanceController>(), p.GetRequiredService<SoinController>(), _services, a));
                using (ServiceProvider provider = _services.BuildServiceProvider())
                {
                    using (IServiceScope serviceScope = provider.CreateScope())
                    {
                        var dlg = serviceScope.ServiceProvider.GetService<AjouterOrdonnance>();
                        dlg.ShowDialog();
                    }
                }
            }
            else
            {
                Utils.ShowError("ERREUR! Veuillez sélectionner un animal!");
            }
        }

        /// <summary>
        /// Function which is called whenever the selected index of the clientComboBox is changed
        /// </summary>
        /// <param name="sender"> object </param>
        /// <param name="e"> EventArgs</param>
        private void clientComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            animalComboBox.Items.Clear();
            animalComboBox.SelectedItem = null;
            allOrdo.Items.Clear();
            CLIENT c = (CLIENT)clientComboBox.SelectedItem;
            foreach (ANIMAL a in c.ANIMAL)
            {
                animalComboBox.Items.Add(a);
            }
        }

        /// <summary>
        /// Function which is called whenever the selected index of the animalComboBox is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void animalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            allOrdo.Items.Clear();

            ANIMAL a = (ANIMAL)animalComboBox.SelectedItem;
            var allOrdoForAnimal = a.ORDONNANCE;
            foreach (ORDONNANCE o in allOrdoForAnimal)
            {
                allOrdo.Items.Add(o);
            }
        }
    }
}
