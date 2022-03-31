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
    public partial class AjouterPrescription : PT4.TemplateSoin
    {
        public AjouterPrescription(MaladiesController diseaseController, ProduitController productController, SoinController careController, ServiceCollection service) : base(diseaseController, productController, careController, service)
        {
            InitializeComponent();
        }
    }
}
