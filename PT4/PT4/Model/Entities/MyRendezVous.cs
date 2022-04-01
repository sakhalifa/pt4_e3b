using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4
{
    public partial class RENDEZVOUS
    {

        public override string ToString()
        {
            return $"RDV du {DATEHEURERDV} au {HEUREFINRDV} pour le client {CLIENT}";
        }
    }
}
