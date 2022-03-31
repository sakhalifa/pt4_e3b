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
    public partial class AjouterStock : TemplateModifierStock
    {
        public AjouterStock(ProduitController produitController) : base(produitController)
        {
            InitializeComponent();
        }
    }
}
