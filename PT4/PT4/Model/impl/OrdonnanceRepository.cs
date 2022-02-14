using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class OrdonnanceRepository : IOrdonnanceRepository, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context;

        public OrdonnanceRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this.context = context;
        }

        public IEnumerable<ORDONNANCE> FindAll()
        {
            return context.ORDONNANCE.ToList();
        }

        public ORDONNANCE FindById(int id)
        {
            return context.ORDONNANCE.Find(id);
        }

        public void Insert(ORDONNANCE obj)
        {
            context.ORDONNANCE.Add(obj);
        }

        public void Delete(int id)
        {
            context.ORDONNANCE.Remove(context.ORDONNANCE.Find(id));
        }

        public void Update(ORDONNANCE obj)
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
