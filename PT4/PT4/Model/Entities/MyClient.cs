using System;
using System.Linq;

namespace PT4
{
    public partial class CLIENT
    {
        public IQueryable<RENDEZVOUS> AppointmentOfTheMonth { get => this.RENDEZVOUS.AsQueryable().Where((r) => r.DATEHEURERDV.Month == DateTime.Now.Month); }
        public int NumberOfAnimals { get => this.ANIMAL.Count; }

        public override string ToString()
        {
            return this.EMAIL;
        }


    }
}
