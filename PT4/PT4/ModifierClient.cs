using Microsoft.Extensions.DependencyInjection;
using PT4.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PT4
{
    public partial class ModifierClient : Form
    {
        /// <summary>
        /// Instance of ClientController
        /// </summary>
        private ClientController _clientController;
        /// <summary>
        /// Instance of AnimalController
        /// </summary>
        private AnimalController _animalController;
        /// <summary>
        /// Instance of ServiceCollection
        /// </summary>
        private ServiceCollection _services;

        //Have to do it to them or else : Entity cannot be tracked by multiple EntityTracker :).
        private int idClient;

        /// <summary>
        /// Instance of CLIENT
        /// </summary>
        private CLIENT client { get => _clientController.ClientById(idClient); }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientController">Instance of ClientController</param>
        /// <param name="animalController">Instance of AnimalController</param>
        /// <param name="services">Instance of ServiceCollection</param>
        /// <param name="estAdmin">boolean admin</param>
        public ModifierClient(ClientController clientController, AnimalController animalController, ServiceCollection services)
        {
            InitializeComponent();
            _clientController = clientController;
            _animalController = animalController;
            _services = services;
            _animalController.SubscribeAnimal(OnChanged);
            _animalController.SubscribeDeleteAnimal(OnDelete);
            this.Closed += (_, __) => { _animalController.UnSubscribeAnimal(OnChanged); _animalController.UnSubscribeDeleteAnimal(OnDelete); };

            if (!Utils.connecteAdmin)
            {
                rajouterUneMaladieToolStripMenuItem.Visible = false;
                rajouterUneMaladieToolStripMenuItem.Enabled = false;

                creerUneOrdonnanceToolStripMenuItem.Visible = false;
                creerUneOrdonnanceToolStripMenuItem.Enabled = false;
            }
        }

        /// <summary>
        /// Set the new informations for a customer
        /// </summary>
        /// <param name="c">Instance of CLIENT</param>
        public void SetClient(CLIENT c)
        {
            this.idClient = c.IDCLIENT;
            nomTextBox.Text = c.NOMCLIENT;
            prenomTextBox.Text = c.PRENOMCLIENT;
            emailTextBox.Text = c.EMAIL;
            numeroTextBox.Text = c.NUMERO;
            ResetGridView();
        }

        /// <summary>
        /// It reset the dataGridView
        /// </summary>
        private void ResetGridView()
        {
            animalGridView.Rows.Clear();
            foreach (var animal in _animalController.AllAnimalsOfCustomer(client))
            {
                AddAnimalToGridView(animal);
            }
        }

        /// <summary>
        /// Add a row with the informations of the new animal
        /// </summary>
        /// <param name="a"></param>
        private void AddAnimalToGridView(ANIMAL a)
        {
            string nom = "N/A";
            if (!(a.NOMANIMAL is null))
            {
                nom = a.NOMANIMAL;
            }
            animalGridView.Rows.Add(a.IDANIMAL, nom, a.NOMESPECE, a.NOMRACE, $"{a.TAILLE}cm", $"{a.POIDS}kg", a.SicknessOfTheMonth.Count());
        }

        /// <summary>
        /// If all the constraints are validated, it validates the modifications
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (CheckRemplissage())
            {
                try
                {
                    string num = null;
                    if (numeroTextBox.Text.Trim().Length > 0)
                    {
                        num = numeroTextBox.Text.Replace(" ", "");
                    }
                    _clientController.ModifierClient(client, nomTextBox.Text, prenomTextBox.Text, num, emailTextBox.Text);
                }
                catch (ArgumentException ex)
                {
                    Utils.ShowError(ex.Message);
                    return;
                }
                MessageBox.Show($"Vous avez bien modifié le client '{client.EMAIL}'!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// If all the constraints are validated, it returns true
        /// </summary>
        /// <returns>returns true if all the constraints are validated</returns>
        private bool CheckRemplissage()
        {
            if (nomTextBox.TextLength == 0)
            {
                Utils.ShowError("ERREUR! Vous devez renseigner un nom!");
                return false;
            }
            if (prenomTextBox.TextLength == 0)
            {
                Utils.ShowError("ERREUR! Vous devez renseigner un prénom!");
                return false;
            }
            if (emailTextBox.TextLength == 0)
            {
                Utils.ShowError("ERREUR! Vous devez renseigner un email!");
                return false;
            }
            try
            {
                var _ = new System.Net.Mail.MailAddress(emailTextBox.Text);
            }
            catch
            {
                Utils.ShowError("ERREUR! L'email est incorrectement formatté!");
                return false;
            }
            if (numeroTextBox.Text.Trim().Length > 0 && !numeroTextBox.MaskCompleted)
            {
                Utils.ShowError("ERREUR! Veuillez soit ne pas mettre de numéro soit le mettre au complet!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Function which is called whenever there is a customer updated or added
        /// </summary>
        /// <param name="animals"></param>
        private void OnChanged(IEnumerable<ANIMAL> animals)
        {
            IEnumerable<ANIMAL> animalsOfClient = animals.Where((a) => a.CLIENT.IDCLIENT == idClient);
            HashSet<ANIMAL> animalsToAdd = new HashSet<ANIMAL>(animalsOfClient);
            foreach (ANIMAL a in animalsOfClient)
            {
                string nom = "N/A";
                if (!(a.NOMANIMAL is null))
                {
                    nom = a.NOMANIMAL;
                }
                foreach (DataGridViewRow row in animalGridView.Rows)
                {
                    if (row.Cells[0].Value.Equals(a.IDANIMAL))
                    {
                        row.Cells["Nom"].Value = nom;
                        row.Cells["Espece"].Value = a.NOMESPECE;
                        row.Cells["Race"].Value = a.NOMRACE;
                        row.Cells["Taille"].Value = $"{a.TAILLE}cm";
                        row.Cells["Poids"].Value = $"{a.POIDS}kg";
                        row.Cells["NbreMaladies"].Value = a.SicknessOfTheMonth.Count();
                        animalsToAdd.Remove(a);
                    }
                }
            }
            foreach (ANIMAL a in animalsToAdd)
            {
                AddAnimalToGridView(a);
            }
        }

        /// <summary>
        /// Function which is called whenever there is a customer which is deleted 
        /// </summary>
        /// <param name="animals"></param>
        private void OnDelete(IEnumerable<ANIMAL> animals)
        {
            HashSet<DataGridViewRow> rowsToDelete = new HashSet<DataGridViewRow>();
            foreach (ANIMAL a in animals)
            {
                foreach (DataGridViewRow row in animalGridView.Rows)
                {
                    if (row.Cells[0].Value.Equals(a.IDANIMAL))
                    {
                        rowsToDelete.Add(row);
                    }
                }
            }
            foreach (DataGridViewRow row in rowsToDelete)
            {
                animalGridView.Rows.Remove(row);
            }
        }

        /// <summary>
        /// It shows the page where you can modify an animal
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ANIMAL a = GetAnimalFromSelection();
            if (!(a is null))
            {
                _services.AddScoped((p) => new ModifierAnimal(p.GetRequiredService<AnimalController>(), p.GetRequiredService<ClientController>(), a));
                using (ServiceProvider provider = _services.BuildServiceProvider())
                {
                    using (IServiceScope serviceScope = provider.CreateScope())
                    {
                        var dlg = serviceScope.ServiceProvider.GetService<ModifierAnimal>();
                        dlg.ShowDialog();
                    }
                }
            }
        }

        /// <summary>
        /// Add a new disease to an animal
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void rajouterUneMaladieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ANIMAL a = GetAnimalFromSelection();
            if (a != null)
            {
                _services.AddScoped((p) => new DeclarerMaladie(p.GetRequiredService<MaladiesController>(), p.GetRequiredService<AnimalController>(), a));
                using (ServiceProvider provider = _services.BuildServiceProvider())
                {
                    var declarerMaladie = provider.GetService<DeclarerMaladie>();
                    declarerMaladie.ShowDialog();
                }
            }
        }

        /// <summary>
        /// it deletes the animals which are dead
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void supprimermortXdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Êtes-vous sûr ? ", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ANIMAL a = GetAnimalFromSelection();
                if (!(a is null))
                {
                    _animalController.DeleteAnimal(a);
                    MessageBox.Show("Vous avez bien supprimé l'animal sélectionné!");
                }
            }
        }

        /// <summary>
        /// It shows the animal you chose
        /// </summary>
        /// <returns> the animal selected</returns>
        private ANIMAL GetAnimalFromSelection()
        {
            if (animalGridView.SelectedRows.Count == 1)
            {
                return _animalController.AnimalByID((short)animalGridView.SelectedRows[0].Cells[0].Value);
            }
            else if (animalGridView.SelectedCells.Count == 1)
            {
                int rowIndex = animalGridView.SelectedCells[0].RowIndex;
                return _animalController.AnimalByID((short)animalGridView.Rows[rowIndex].Cells[0].Value);
            }
            else
            {
                Utils.ShowError("ERREUR! Veuillez sélectionner 1 et une seule colonne/ligne");
                return null;
            }
        }
        /// <summary>
        /// It shows the page where an animal can be added
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void addAnimal_Click(object sender, EventArgs e)
        {
            _services.AddScoped((p) => new AjouterAnimal(p.GetRequiredService<AnimalController>(), p.GetRequiredService<ClientController>(), client));
            using (ServiceProvider provider = _services.BuildServiceProvider())
            {
                using (IServiceScope serviceScope = provider.CreateScope())
                {
                    var dlg = serviceScope.ServiceProvider.GetService<AjouterAnimal>();
                    dlg.ShowDialog();
                }
            }
        }

        private void creerUneOrdonnanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ANIMAL a = GetAnimalFromSelection();
            if (!(a is null))
            {
                _services.AddScoped((p) => new AjouterOrdonnance(p.GetRequiredService<AnimalController>(), p.GetRequiredService<OrdonnanceController>(), p.GetRequiredService<SoinController>(), _services, a));
                using (ServiceProvider provider = _services.BuildServiceProvider())
                {
                    using (IServiceScope serviceScope = provider.CreateScope())
                    {
                        var dlg = serviceScope.ServiceProvider.GetService<AjouterOrdonnance>();
                        dlg.ShowDialog();
                    }
                }
            }

        }
    }
}
