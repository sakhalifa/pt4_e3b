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
    public partial class AjouterFacture : Form
    {
        private ServiceCollection _services;
        private FactureController _factureController;
        private FACTURE facture;

        public AjouterFacture(FactureController factureController, ClientController clientController, ServiceCollection services)
        {
            InitializeComponent();
            _factureController = factureController;
            _services = services;
            foreach (CLIENT c in clientController.ListCustomers())
            {
                clients.Items.Add(c);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _services.AddScoped<AjouterProduitFacture>();
            using (ServiceProvider provider = _services.BuildServiceProvider())
            {
                var dlg = provider.GetService<AjouterProduitFacture>();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    PRODUIT p = dlg.prodSelected;
                    short quantite = dlg.quantiteProd;
                    try
                    {
                        _factureController.AddProductToReceipt(facture, p, quantite);
                        ResetGridView();
                    }
                    catch (ArgumentException ex)
                    {
                        Utils.ShowError(ex.Message);
                    }
                }
            }
        }

        private void ResetGridView()
        {
            _factureController.UpdateMontant(facture);
            montantFacture.Text = $"{facture.MONTANT}€";
            produits.Rows.Clear();
            foreach (PRODUIT_VENDU p in facture.PRODUIT_VENDU)
            {
                AddProduitVenduToGrid(p);
            }
        }

        private void AddProduitVenduToGrid(PRODUIT_VENDU p)
        {
            produits.Rows.Add(p, p.PRODUIT.NOMPRODUIT, p.QUANTITÉ, $"{p.PRODUIT.PRIXDEVENTE}€", $"{p.Montant}€");
        }

        private void clients_SelectedIndexChanged(object sender, EventArgs e)
        {
            produits.Rows.Clear();
            montantFacture.Text = "0€";
            _factureController.Reset();
            facture = _factureController.CreerFacture((CLIENT)clients.SelectedItem);
        }

        private PRODUIT_VENDU GetProduitVenduFromSelection()
        {
            if (produits.SelectedRows.Count == 1)
            {
                var row = produits.SelectedRows[0];
                PRODUIT_VENDU p = (PRODUIT_VENDU)row.Cells["RefProduitVendu"].Value;
                if (p != null)
                {
                    return p;
                }
                else
                {
                    Utils.ShowError("ERREUR CRITIQUE! Inconsistence entre l'IHM et le métier!");
                    return null;
                }

            }
            else
            {
                Utils.ShowError("ERREUR! Veuillez sélectionner au moins une ligne!");
                return null;
            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PRODUIT_VENDU selected = GetProduitVenduFromSelection();
            if (!(selected is null))
            {

                SingleNumericUpDown dlg = new SingleNumericUpDown("Quantité à retirer?", 1, selected.QUANTITÉ);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (MessageBox.Show($"Êtes-vous sur de vouloir retirer {dlg.Value} '{selected.PRODUIT.NOMPRODUIT}' de la vente?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        _factureController.RemoveProductFromReceipt(facture, selected.PRODUIT, (short)dlg.Value);
                        MessageBox.Show($"Vous avez bien retiré {(short)dlg.Value} '{selected.PRODUIT}' de la facture!");
                        ResetGridView();
                    }
                }

            }
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PRODUIT_VENDU selected = GetProduitVenduFromSelection();
            if (!(selected is null))
            {
                SingleNumericUpDown dlg = new SingleNumericUpDown("Nouvelle quantité?", 1, selected.QUANTITÉ);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (MessageBox.Show($"Êtes-vous sur de vouloir passer de {selected.QUANTITÉ} '{selected.PRODUIT.NOMPRODUIT}' vendus à {dlg.Value} vendus?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        _factureController.RemoveProductFromReceipt(facture, selected.PRODUIT, selected.QUANTITÉ);
                        _factureController.AddProductToReceipt(facture, selected.PRODUIT, (short)dlg.Value);
                        MessageBox.Show($"Vous avez bien changé la quantité de '{selected.PRODUIT.NOMPRODUIT}' vendus à {(short)dlg.Value}");
                        ResetGridView();
                    }
                }

            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (CheckRemplissage())
            {
                _factureController.SaveReceipt(facture);
                MessageBox.Show("Vous avez bien sauvegardé cette facture!");
                this.Close();
            }
        }

        private bool CheckRemplissage()
        {
            if (clients.SelectedItem == null)
            {
                Utils.ShowError("ERREUR! Vous n'avez pas sélectionné de client!");
                return false;
            }
            if (facture.PRODUIT_VENDU.Count == 0)
            {
                Utils.ShowError("ERREUR! Vous ne pouvez pas créer une facture avec 0 produits vendus!");
                return false;
            }
            

            return true;

        }
    }
}
