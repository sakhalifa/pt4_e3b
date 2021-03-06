using Microsoft.Extensions.DependencyInjection;
using PT4.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PT4
{
    public partial class AfficherSoin : Form
    {
        /// <summary>
        /// Instance of ServiceCollection
        /// </summary>
        private ServiceCollection _services;

        /// <summary>
        /// Instance of SoinController
        /// </summary>
        private SoinController _soinController;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="soinController">Instance of soinController</param>
        /// <param name="services">Instance of ServiceCollection</param>
        public AfficherSoin(SoinController soinController, ServiceCollection services)
        {
            InitializeComponent();
            this._services = services;
            _soinController = soinController;
            foreach (SOIN s in soinController.FindAll())
            {
                allSoins.Items.Add(s);
            }

            soinController.SubscribeSoins(OnChanged);
            soinController.SubscribeDeleteSoins(OnDelete);

            this.Closed += (_, __) => { soinController.UnSubscribeSoins(OnChanged); soinController.UnSubscribeDeleteSoins(OnDelete); };
        }

        /// <summary>
        /// Function which is called whenever there is a cure updated or added
        /// </summary>
        /// <param name="soins">All the cure which has been added or updated</param>
        private void OnChanged(IEnumerable<SOIN> soins)
        {
            HashSet<SOIN> addedSoins = new HashSet<SOIN>(soins);
            IEnumerable<SOIN> castedItems = allSoins.Items.Cast<SOIN>();
            foreach (SOIN ss in soins)
            {
                int ind = 0;
                foreach (SOIN s in castedItems)
                {
                    if (s.ID == ss.ID)
                    {
                        allSoins.Items[ind] = ss;
                        addedSoins.Remove(ss);
                    }
                    ind++;
                }
            }

            foreach (SOIN s in addedSoins)
            {
                allSoins.Items.Add(s);
            }

        }

        /// <summary>
        /// Function which is called whenever there is a cure which is deleted 
        /// </summary>
        /// <param name="soins">All the cure deleted</param>
        private void OnDelete(IEnumerable<SOIN> soins)
        {
            HashSet<SOIN> careToRemove = new HashSet<SOIN>();
            IEnumerable<SOIN> castedItems = allSoins.Items.Cast<SOIN>();
            foreach (SOIN ss in soins)
            {
                foreach (SOIN s in castedItems)
                {
                    if (s.ID == ss.ID)
                    {
                        careToRemove.Add(s);
                    }
                }
            }

            foreach (SOIN s in careToRemove)
            {
                allSoins.Items.Remove(s);
            }
        }

        /// <summary>
        /// Function which shows the page to add a new cure
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
        /// Function which deletes the cure
        /// </summary>
        /// <param name="sender"> object </param>
        /// <param name="e"> EventArgs </param>
        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allSoins.SelectedItem != null)
            {
                if (MessageBox.Show("Voulez-vous vraiment supprimer ce soin?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        _soinController.RemoveCare((SOIN)allSoins.SelectedItem);
                    }
                    catch (ArgumentException ex)
                    {
                        Utils.ShowError(ex.Message);
                        return;
                    }
                    MessageBox.Show("Vous avez bien supprimé ce soin!");
                }
            }
        }

        /// <summary>
        /// Function which modify the cure chosen
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allSoins.SelectedItem != null)
            {
                _services.AddScoped<ModifierSoin>();
                using (ServiceProvider provider = _services.BuildServiceProvider())
                {
                    using (IServiceScope serviceScope = provider.CreateScope())
                    {
                        var dlg = serviceScope.ServiceProvider.GetService<ModifierSoin>();
                        dlg.SetSoin((SOIN)allSoins.SelectedItem);
                        dlg.ShowDialog();
                    }
                }
            }
        }
    }
}
