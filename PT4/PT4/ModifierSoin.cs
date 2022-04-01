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
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="diseaseController">Instance of MaladieController</param>
        /// <param name="productController">Instance of ProduitController</param>
        /// <param name="careController"> Instance of SoinController </param>
        /// <param name="service"> Instance of ServiceCollection</param>
        public ModifierSoin(MaladiesController diseaseController, ProduitController productController, SoinController careController, ServiceCollection service) : base(diseaseController, productController, careController, service)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Function which is called when the forms is showed
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        /// <exception cref="ArgumentException">Arguments if the form is launched without cure </exception>
        private void ModifierSoin_Load(object sender, EventArgs e)
        {
            if(soin is null)
            {
                throw new ArgumentException("ERREUR CRITIQUE! Form lancé sans soin correspondant!");
            }
        }
    }
}
