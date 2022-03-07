using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class ClientRepository : IClientRepository, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context;

        public ClientRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this.context = context;
        }

        public IEnumerable<CLIENT> FindAll()
        {
            return context.CLIENT.ToList();
        }

        public CLIENT FindById(int id)
        {
            return context.CLIENT.Find(id);
        }

        public void Insert(CLIENT obj)
        {
            context.CLIENT.Add(obj);
        }

        public void Delete(int id)
        {
            context.CLIENT.Remove(context.CLIENT.Find(id));
        }

        public void Update(CLIENT obj)
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

        public IEnumerable<CLIENT> FindWhere(Expression<Func<CLIENT, bool>> predicate)
        {
            return context.CLIENT.Where(predicate);
        }
    }
}
