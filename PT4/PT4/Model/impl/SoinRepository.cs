using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class SoinRepository : ISoinRepository, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context;

        public SoinRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this.context = context;
        }

        public IEnumerable<SOIN> FindAll()
        {
            return context.SOIN.ToList();
        }

        public SOIN FindById(int id)
        {
            return context.SOIN.Find(id);
        }

        public void Insert(SOIN obj)
        {
            context.SOIN.Add(obj);
        }

        public void Delete(int id)
        {
            context.SOIN.Remove(context.SOIN.Find(id));
        }

        public void Update(SOIN obj)
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

        public IEnumerable<SOIN> FindWhere(Expression<Func<SOIN, bool>> predicate)
        {
            return context.SOIN.Where(predicate);
        }
    }
}
