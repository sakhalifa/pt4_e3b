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
    public partial class AfficherClient : MenuHamberger
    {
        private ClientController _clientController;

        private List<CLIENT> cachedCustomers;

        private static readonly int ELEMENTS_PER_PAGE = 20;

        private int CurrentPage = 0;

        private int ElementCount { get => cachedCustomers.Count; }

        public AfficherClient(ClientController clientController, ServiceCollection services, int salarieId, bool estAdmin) : base(services, salarieId, estAdmin)
        {
            _clientController = clientController;
            _clientController.SubscribeCustomers(OnChanged);
            _clientController.SubscribeDeleteCustomers(OnDelete);
            this.Closed += UnSubscribe;
            cachedCustomers = new List<CLIENT>();
            InitializeComponent();
            InitDataGridView();
            clients.SendToBack();

            backwards.Visible = false;
            forward.Visible = ElementCount > (CurrentPage + 1) * ELEMENTS_PER_PAGE;

        }

        private void UnSubscribe(object sender, EventArgs e)
        {
            _clientController.UnSubscribeCustomers(OnChanged);
            _clientController.UnSubscribeDeleteCustomers(OnDelete);
        }

        private void InitDataGridView()
        {
            IEnumerable<CLIENT> clients = _clientController.ListCustomers();
            int cpt = 0;
            foreach (var client in clients)
            {
                if (cpt++ < ELEMENTS_PER_PAGE)
                {
                    AddCustomerToDataGrid(client);
                }
                cachedCustomers.Add(client);

            }
        }

        private void ResetDataGridViewFromCache()
        {
            clients.Rows.Clear();
            foreach (var client in Utils.GetRangeAndCut(cachedCustomers, CurrentPage * ELEMENTS_PER_PAGE, ELEMENTS_PER_PAGE))
            {
                AddCustomerToDataGrid(client);
            }

            backwards.Visible = CurrentPage > 0;
            forward.Visible = ElementCount > (CurrentPage + 1) * ELEMENTS_PER_PAGE;
        }

        public void OnChanged(IEnumerable<CLIENT> clients)
        {
            cachedCustomers.RemoveAll((c) => clients.Any((cc) => c.IDCLIENT == cc.IDCLIENT));
            cachedCustomers.AddRange(clients);
            ResetDataGridViewFromCache();
        }

        public void OnDelete(IEnumerable<CLIENT> clients)
        {
            cachedCustomers.RemoveAll((c) => clients.Any((cc) => c.IDCLIENT == cc.IDCLIENT));
            ResetDataGridViewFromCache();
        }

        private void AddCustomerToDataGrid(CLIENT client)
        {
            clients.Rows.Add(client.NOMCLIENT, client.PRENOMCLIENT, client.EMAIL, client.NUMERO, client.NumberOfAnimals, client.AppointmentOfTheMonth.Count());
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CLIENT c;
            if (clients.SelectedRows.Count == 1)
            {
                DataGridViewRow row = clients.SelectedRows[0];
                c = _clientController.FindByEmail((string)row.Cells["Email"].Value);

            }
            else if (clients.SelectedCells.Count == 1)
            {
                DataGridViewCell selectedCell = clients.SelectedCells[0];
                DataGridViewCell cell = clients.Rows[selectedCell.RowIndex].Cells["Email"];
                c = _clientController.FindByEmail((string)cell.Value);
            }
            else
            {
                Utils.ShowError("ERREUR! Veuillez sélectionner une seule cellule ou une seule ligne!");
                return;
            }
            _services.AddScoped((p) => new ModifierClient(p.GetRequiredService<ClientController>(), p.GetRequiredService<AnimalController>(), _services, estAdmin));
            using (ServiceProvider provider = _services.BuildServiceProvider())
            {
                using (IServiceScope serviceScope = provider.CreateScope())
                {
                    var modifierClient = serviceScope.ServiceProvider.GetService<ModifierClient>();
                    modifierClient.SetClient(c);
                    modifierClient.ShowDialog();
                }
            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sur?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clients.SelectedRows.Count > 0)
                {
                    foreach (var obj in clients.SelectedRows)
                    {
                        DataGridViewRow row = (DataGridViewRow)obj;
                        _clientController.RemoveByEmail((string)row.Cells["Email"].Value);
                        MessageBox.Show($"Vous avez bien supprimé le client '{row.Cells["Email"].Value}'");
                    }
                }
                else if (clients.SelectedCells.Count > 0)
                {
                    HashSet<int> visitedRows = new HashSet<int>();
                    foreach (DataGridViewCell selectedCell in clients.SelectedCells)
                    {
                        if (!visitedRows.Contains(selectedCell.RowIndex))
                        {
                            DataGridViewCell cell = clients.Rows[selectedCell.RowIndex].Cells["Email"];
                            _clientController.RemoveByEmail((string)cell.Value);
                            visitedRows.Add(selectedCell.RowIndex);
                        }
                    }

                }
                else
                {
                    Utils.ShowError("ERREUR! Veuillez sélectionner au moins un client.");
                    return;
                }
            }
        }

        private void rechercheButton_Click(object sender, EventArgs e)
        {
            RechercheClient rechercheClient = new RechercheClient();
            if (rechercheClient.ShowDialog() == DialogResult.OK)
            {
                reset.Visible = true;

                var generatedPredicate = _clientController.CreateCriteriasFromForm(rechercheClient);
                Predicate<CLIENT> funcAsPredicate = new Predicate<CLIENT>(generatedPredicate.Compile());
                clients.Rows.Clear();
                foreach (CLIENT c in cachedCustomers.FindAll(funcAsPredicate))
                {
                    AddCustomerToDataGrid(c);
                }
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            this.CurrentPage = 0;
            ResetDataGridViewFromCache();
            reset.Visible = false;
        }

        private void forward_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            ResetDataGridViewFromCache();
        }

        private void backwards_Click(object sender, EventArgs e)
        {
            CurrentPage--;
            ResetDataGridViewFromCache();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var dlg = new AjouterClient(_clientController);
            dlg.ShowDialog();
        }
    }
}
