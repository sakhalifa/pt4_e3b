using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4
{
    partial class CLIENT
    {
        public IQueryable<RENDEZVOUS> AppointmentOfTheMonth { get => this.RENDEZVOUS.AsQueryable().Where((r) => r.DATEHEURERDV.Month == DateTime.Now.Month); }
        public int NumberOfAnimals { get => this.ANIMAL.Count; }

        public override string ToString()
        {
            return this.EMAIL;
        }

        
    }
}
