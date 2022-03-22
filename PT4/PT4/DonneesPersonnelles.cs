﻿using PT4.Controllers;
using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT4
{
    public partial class DonneesPersonnelles : Form
    {
        private SalarieController _salarieController;
        private SALARIÉ _salarie;

        public DonneesPersonnelles(SalarieController controller, SALARIÉ s)
        {
            InitializeComponent();
            _salarieController = controller;
            _salarie = s;
        }


        private void buttonConfirmer_Click(object sender, EventArgs e)
        {

            if (textBoxMailDonnees.Text.Length == 0 )
            {
                Utils.ShowError("Veuillez entrer une adresse mail");
            }
            else if (!textBoxMailDonnees.Text.Contains("@"))
            {
                Utils.ShowError("Veuillez entrer une adresse mail valide");
            }
            else if (!Regex.IsMatch(textBoxNumero.Text, @"^[+]\d+$") || !Regex.IsMatch(textBoxNumero.Text, @"^\d +$"))
            {
                    Utils.ShowError("Ce numéro est invalide");
            }
            else if (textBoxNumero.Text.Length >12 )
            {
                Utils.ShowError("Ce numéro est invalide");

            }

            else if (numericUpDownAge.Value <0)
            {
                Utils.ShowError("Sélectionnez un âge valide");
            }

            else if (comboBoxSexe.SelectedItem == null)
            {
                Utils.ShowError("Sélectionnez un sexe valide");
            }

            else
            {

                try
                {
                    _salarieController.DonneesPersoSalarie(_salarie, "Sexe : "+comboBoxSexe.SelectedItem+" Age : "+numericUpDownAge.Value+" Telephone : "+textBoxNumero.Text+" Email : "+textBoxMailDonnees.Text);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex.Message);
                }
            }

        }

 
    }
}