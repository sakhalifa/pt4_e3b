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
    public partial class ModifierStock : PT4.TemplateModifierStock
    {

        public ModifierStock(ProduitController produitController) : base(produitController)
        {
            InitializeComponent();
            this.IsAdd = false;
        }

        
        public override void SetProduit(PRODUIT p)
        {
            base.SetProduit(p);
            quantite.Value = p.QUANTITEENSTOCK;
        }
    }
}
