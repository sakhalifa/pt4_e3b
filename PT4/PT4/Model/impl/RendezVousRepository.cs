using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class RendezVousRepository : IRendezVousRepository, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context;

        public RendezVousRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this.context = context;
        }

        public IEnumerable<RENDEZVOUS> FindAll()
        {
            return context.RENDEZVOUS.ToList();
        }

        public RENDEZVOUS FindById(int id)
        {
            return context.RENDEZVOUS.Find(id);
        }

        public void Insert(RENDEZVOUS obj)
        {
            context.RENDEZVOUS.Add(obj);
        }

        public void Delete(int id)
        {
            context.RENDEZVOUS.Remove(context.RENDEZVOUS.Find(id));
        }

        public void Update(RENDEZVOUS obj)
        {
            context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
