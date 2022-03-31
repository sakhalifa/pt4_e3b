using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4
{
    public partial class PRODUIT_VENDU
    {
        public decimal Montant { get => this.PRODUIT.PRIXDEVENTE.Value * this.QUANTITÉ; }
    }
}
