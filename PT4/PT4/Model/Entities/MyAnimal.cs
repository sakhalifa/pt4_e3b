using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4
{
    public partial class ANIMAL
    {
        public IQueryable<HISTORIQUEMALADIE> SicknessOfTheMonth { get => this.HISTORIQUEMALADIE.AsQueryable().Where((h) => h.DATEDEBUT.Month == DateTime.Now.Month); }

        public override string ToString()
        {
            return NOMANIMAL;
        }
    }
}
