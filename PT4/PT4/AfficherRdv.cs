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
    public partial class AfficherRdv : Form
    {
        private ClientController _clientController;
        private RendezVousController _rendezVousController;
        private ServiceCollection _services;

        public AfficherRdv(ClientController clientController, RendezVousController rdvController, ServiceCollection services)
        {
            InitializeComponent();
            _clientController = clientController;
            _rendezVousController = rdvController;
            _services = services;

            foreach (CLIENT c in _clientController.FindAll())
            {
                clients.Items.Add(c);
            }

            rdvController.SubscribeAppointments(OnChanged);
            rdvController.SubscribeDeleteAppointments(OnDelete);

            this.Closed += (_, __) => { rdvController.UnSubscribeAppointments(OnChanged); rdvController.UnSubscribeDeleteAppointments(OnDelete); };
        }

        private void OnDelete(IEnumerable<RENDEZVOUS> args)
        {
            if (clients.SelectedItem != null)
            {
                CLIENT c = (CLIENT)clients.SelectedItem;
                foreach (RENDEZVOUS rdv in args.Where(r => r.IDCLIENT == c.IDCLIENT))
                {
                    rendezVous.Items.Remove(rdv);
                }
            }
        }

        private void OnChanged(IEnumerable<RENDEZVOUS> args)
        {
            if (clients.SelectedItem != null)
            {
                CLIENT c = (CLIENT)clients.SelectedItem;
                foreach (RENDEZVOUS rdv in args.Where(r => r.CLIENT == c))
                {
                    rendezVous.Items.Remove(rdv);
                    rendezVous.Items.Add(rdv);

                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (clients.SelectedItem is null)
            {
                _services.AddScoped<ajouterRDV>();
                using (ServiceProvider provider = _services.BuildServiceProvider())
                {
                    using (IServiceScope scope = provider.CreateScope())
                    {
                        scope.ServiceProvider.GetService<ajouterRDV>().ShowDialog();
                    }
                }
            }
            else
            {
                CLIENT c = (CLIENT)clients.SelectedItem;
                _services.AddScoped<ajouterRDV>();
                using (ServiceProvider provider = _services.BuildServiceProvider())
                {
                    using (IServiceScope scope = provider.CreateScope())
                    {
                        var dlg = scope.ServiceProvider.GetService<ajouterRDV>();
                        dlg.SetClient(c);
                        dlg.ShowDialog();
                    }
                }
            }
        }

        private void clients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clients.SelectedItem != null)
            {
                rendezVous.Items.Clear();
                CLIENT c = (CLIENT)clients.SelectedItem;
                foreach (RENDEZVOUS rdv in c.RENDEZVOUS)
                {
                    rendezVous.Items.Add(rdv);
                }
            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ces rendez-vous?", "Confirmer", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (rendezVous.SelectedItems.Count > 0)
                {
                    IEnumerable<RENDEZVOUS> casted = rendezVous.SelectedItems.Cast<RENDEZVOUS>();
                    _rendezVousController.DeleteBulk(casted);
                    MessageBox.Show("Vous avez bien supprimé les rendez-vous!");
                }
                else
                {
                    Utils.ShowError("ERREUR! Veuillez sélectionner au moins 1 rendez-vous!");
                }
            }
        }
    }
}
