using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class FactureRepository : IFactureRepository, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context;

        public FactureRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this.context = context;
        }

        public IEnumerable<FACTURE> FindAll()
        {
            return context.FACTURE.ToList();
        }

        public FACTURE FindById(int id)
        {
            return context.FACTURE.Find(id);
        }

        public void Insert(FACTURE obj)
        {
            context.FACTURE.Add(obj);
        }

        public void Delete(int id)
        {
            context.FACTURE.Remove(context.FACTURE.Find(id));
        }

        public void Update(FACTURE obj)
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

        public IEnumerable<FACTURE> FindWhere(Expression<Func<FACTURE, bool>> predicate)
        {
            return context.FACTURE.Where(predicate);
        }
    }
}
