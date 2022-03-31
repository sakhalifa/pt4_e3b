using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4
{
    public partial class SOIN
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Soin pour les maladies : ");
            foreach(MALADIE m in this.MALADIE)
            {
                sb.Append($"'{m.NOMMALADIE}' ");
            }
            sb.Append("avec les produits : ");
            foreach(PRODUIT p in this.PRODUIT)
            {
                sb.Append($"'{p.NOMPRODUIT}' ");
            }
            sb.RemoveLastCharacter();
            return sb.ToString();
        }
    }
}
