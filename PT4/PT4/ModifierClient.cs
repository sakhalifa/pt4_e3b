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
    public partial class ModifierClient : Form
    {
        private ClientController _clientController;
        private AnimalController _animalController;

        //Have to do it to them or else : Entity cannot be tracked by multiple EntityTracker :).
        private int idClient;
        private CLIENT client { get => _clientController.ClientById(idClient); }

        private ServiceCollection _services;

        public ModifierClient(ServiceCollection services, ClientController clientController, AnimalController animalController)
        {
            InitializeComponent();
            _services = services;
            _clientController = clientController;
            _animalController = animalController;
            _animalController.SubscribeAnimal(OnChanged);
            _animalController.SubscribeDeleteAnimal(OnDelete);
            this.Closed += (_, __) => { _animalController.UnSubscribeAnimal(OnChanged); _animalController.UnSubscribeDeleteAnimal(OnDelete); };
        }

        public void SetClient(CLIENT c)
        {
            this.idClient = c.IDCLIENT;
            nomTextBox.Text = c.NOMCLIENT;
            prenomTextBox.Text = c.PRENOMCLIENT;
            emailTextBox.Text = c.EMAIL;
            numeroTextBox.Text = c.NUMERO;
            ResetGridView();
        }

        //Pas besoin d'un cache et tt vu qu'un client n'aura pas genre 250 animaux quoi.
        //C'est pour cette même raison qu'on ne fait pas de pagination
        private void ResetGridView()
        {
            animalGridView.Rows.Clear();
            foreach (var animal in _animalController.AllAnimalsOfCustomer(client))
            {
                AddAnimalToGridView(animal);
            }
        }

        private void AddAnimalToGridView(ANIMAL a)
        {
            string nom = "N/A";
            if (!(a.NOMANIMAL is null))
            {
                nom = a.NOMANIMAL;
            }
            animalGridView.Rows.Add(a.IDANIMAL, nom, a.NOMESPECE, a.NOMRACE, $"{a.TAILLE}cm", $"{a.POIDS}kg", a.SicknessOfTheMonth.Count());
        }

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

        //I just reset the grid because nobody has like 25 animals or something. So it won't lag that much
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

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ANIMAL a = GetAnimalFromSelection();
            if (!(a is null))
            {
                _services.AddScoped((p) => new ModifierAnimal(p.GetRequiredService<AnimalController>(), p.GetRequiredService<ClientController>(), a));
                using (ServiceProvider provider = _services.BuildServiceProvider())
                {
                    var dlg = provider.GetService<ModifierAnimal>();
                    dlg.ShowDialog();
                }
            }
        }

        private void rajouterUneMaladieToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void supprimermortXdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sur?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ANIMAL a = GetAnimalFromSelection();
                if (!(a is null))
                {
                    _animalController.DeleteAnimal(a);
                    MessageBox.Show("Vous avez bien supprimé l'animal sélectionné!");
                }
            }
        }

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

        private void addAnimal_Click(object sender, EventArgs e)
        {
            AjouterAnimal aj = new AjouterAnimal(_animalController, _clientController, client);
            aj.ShowDialog();
        }

        private void créerUneOrdonnanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ANIMAL a = GetAnimalFromSelection();
            if (!(a is null))
            {
                _services.AddScoped((p) => new AjouterOrdonnance(p.GetRequiredService<AnimalController>(), p.GetRequiredService<OrdonnanceController>(), p.GetRequiredService<SoinController>(), _services, a));
                using(ServiceProvider provider = _services.BuildServiceProvider())
                {
                    var dlg = provider.GetService<AjouterOrdonnance>();
                    dlg.ShowDialog();
                }
            }

        }
    }
}
