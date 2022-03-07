using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class SalarieRepository : ISalarieRepository, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context;

        public SalarieRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this.context = context;
        }

        public IEnumerable<SALARIÉ> FindAll()
        {
            return context.SALARIÉ.ToList();
        }

        public SALARIÉ FindById(int id)
        {
            return context.SALARIÉ.Find(id);
        }

        public void Insert(SALARIÉ obj)
        {
            context.SALARIÉ.Add(obj);
        }

        public void Delete(int id)
        {
            context.SALARIÉ.Remove(context.SALARIÉ.Find(id));
        }

        public void Update(SALARIÉ obj)
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

        public IEnumerable<SALARIÉ> FindWhere(Expression<Func<SALARIÉ, bool>> predicate)
        {
            return context.SALARIÉ.Where(predicate);
        }
    }
}
