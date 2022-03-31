﻿using PT4.Controllers;
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
    public partial class AjouterMaladie : Form
    {
        private MaladiesController _maladieController;

        // Constructor
        public AjouterMaladie(MaladiesController maladiesController)
        {
            InitializeComponent();
            _maladieController = maladiesController;
        }
        
        private void buttonConfirmer_Click(object sender, EventArgs e)
        {
            // If there is no test in the textbox, it tells you that you have to write
            if(textBoxMaladie.Text == null)
            {
                Utils.ShowError("Veuillez inscrire le nom d'une maladie");
            }
            else
            {
                // If everything's ok, it creates the new disease
                try
                {
                    _maladieController.CreerMaladie(textBoxMaladie.Text);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                // if not, it shows the error
                catch (Exception ex)
                {
                    Utils.ShowError(ex.Message);
                    return;
                }
            }
        }
    }
}