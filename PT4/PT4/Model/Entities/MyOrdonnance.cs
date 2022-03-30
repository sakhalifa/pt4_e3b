using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4
{
    public partial class ORDONNANCE
    {
        public override string ToString()
        {
            if(ANIMAL != null) { 
                return $"Ordonnance n°{ID} pour l'animal '{ANIMAL.NOMANIMAL}'";
            }
            else
            {
                return "";
            }
        }
    }
}
