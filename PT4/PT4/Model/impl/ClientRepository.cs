using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class ClientRepository : IGenericRepository<CLIENT>, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities _context;

        public ClientRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this._context = context;
        }

        public IEnumerable<CLIENT> FindAll()
        {
            return _context.CLIENT.ToList();
        }

        public CLIENT FindById(int id)
        {
            return _context.CLIENT.Find(id);
        }

        public void Insert(CLIENT obj)
        {
            _context.CLIENT.Add(obj);
        }

        public void Delete(int id)
        {
            _context.CLIENT.Remove(_context.CLIENT.Find(id));
        }

        public void Update(CLIENT obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
            return _context.CLIENT.Where(predicate);
        }
    }
}
