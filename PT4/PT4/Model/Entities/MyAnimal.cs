using System;
using System.Linq;

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
