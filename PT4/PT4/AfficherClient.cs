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
        /// <summary>
        /// Instance of ClientController
        /// </summary>
        private ClientController _clientController;

        /// <summary>
        /// A list of the customers
        /// </summary>
        private List<CLIENT> cachedCustomers;
        
        /// <summary>
        /// Instance which limits the number of elements per page 
        /// </summary>
        private static readonly int ELEMENTS_PER_PAGE = 20;

        /// <summary>
        /// Instance which defines the current page
        /// </summary>
        private int CurrentPage = 0;

        /// <summary>
        /// To get the number of elements in the cachedCustomers list
        /// </summary>
        private int ElementCount { get => cachedCustomers.Count; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientController"> Instance of ClientController</param>
        /// <param name="services"> Instance of ServiceCollection </param>
        /// <param name="salarieId"> id of the salary </param>
        /// <param name="estAdmin"> boolean which defines if the person is an admin or not </param>
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

        /// <summary>
        /// Function which init all the board where customers will be
        /// </summary>
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


        /// <summary>
        /// it resets the dataGridView and fills it with the data in cachedCustomers
        /// </summary>
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

        /// <summary>
        /// Modify the modified elements of the client
        /// </summary>
        /// <param name="clients">List of CLIENT changed</param>
        public void OnChanged(IEnumerable<CLIENT> clients)
        {
            cachedCustomers.RemoveAll((c) => clients.Any((cc) => c.IDCLIENT == cc.IDCLIENT));
            cachedCustomers.AddRange(clients);
            ResetDataGridViewFromCache();
        }

        /// <summary>
        /// Delete the row of the client you delete
        /// </summary>
        /// <param name="clients">List of CLIENT deleted</param>
        public void OnDelete(IEnumerable<CLIENT> clients)
        {
            cachedCustomers.RemoveAll((c) => clients.Any((cc) => c.IDCLIENT == cc.IDCLIENT));
            ResetDataGridViewFromCache();
        }

        /// <summary>
        /// It adds the new customer to the datagrid (new row)
        /// </summary>
        /// <param name="client"> Instance of CLIENT </param>
        private void AddCustomerToDataGrid(CLIENT client)
        {
            clients.Rows.Add(client.NOMCLIENT, client.PRENOMCLIENT, client.EMAIL, client.NUMERO, client.NumberOfAnimals, client.AppointmentOfTheMonth.Count());
        }

        /// <summary>
        /// Function to modify a customer with the right click
        /// </summary>
        /// <param name="sender"> object </param>
        /// <param name="e"> EventArgs </param>
        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
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
            _services.AddScoped<ModifierClient>();
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

        /// <summary>
        /// Function to delete a customer
        /// </summary>
        /// <param name="sender"> object </param>
        /// <param name="e"> EventArgs </param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Function to research a customer
        /// </summary>
        /// <param name="sender"> object </param>
        /// <param name="e"> EventArgs</param>
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

        /// <summary>
        /// Function which reset the dataGridView 
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void reset_Click(object sender, EventArgs e)
        {
            this.CurrentPage = 0;
            ResetDataGridViewFromCache();
            reset.Visible = false;
        }

        /// <summary>
        /// Function which changes pages
        /// </summary>
        /// <param name="sender"> object </param>
        /// <param name="e"> EventArgs </param>
        private void forward_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            ResetDataGridViewFromCache();
        }

        /// <summary>
        /// Function which changes pages
        /// </summary>
        /// <param name="sender"> object </param>
        /// <param name="e"> EventArgs </param>
        private void backwards_Click(object sender, EventArgs e)
        {
            CurrentPage--;
            ResetDataGridViewFromCache();
        }

        /// <summary>
        /// Function which adds the new Customer in the database
        /// </summary>
        /// <param name="sender"> object </param>
        /// <param name="e"> EventArgs </param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var dlg = new AjouterClient(_clientController);
            dlg.ShowDialog();
        }
    }
}
