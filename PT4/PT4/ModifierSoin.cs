using Microsoft.Extensions.DependencyInjection;
using PT4.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PT4
{
    public partial class ModifierSoin : PT4.TemplateSoin
    {
        public ModifierSoin(MaladiesController diseaseController, ProduitController productController, SoinController careController, ServiceCollection service) : base(diseaseController, productController, careController, service)
        {
            InitializeComponent();
        }

        private void ModifierSoin_Load(object sender, EventArgs e)
        {
            if(soin is null)
            {
                throw new ArgumentException("ERREUR CRITIQUE! Form lancé sans soin correspondant!");
            }
        }
    }
}
