using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class MaladieRepository : IGenericRepository<MALADIE>, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities _context;

        public MaladieRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this._context = context;
        }

        public IEnumerable<MALADIE> FindAll()
        {
            return _context.MALADIE.ToList();
        }

        public MALADIE FindById(int id)
        {
            return _context.MALADIE.Find(id);
        }

        public void Insert(MALADIE obj)
        {
            _context.MALADIE.Add(obj);
        }

        public void Delete(int id)
        {
            _context.MALADIE.Remove(_context.MALADIE.Find(id));
        }

        public void Update(MALADIE obj)
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

        public IEnumerable<MALADIE> FindWhere(Expression<Func<MALADIE, bool>> predicate)
        {
            return _context.MALADIE.Where(predicate);
        }
    }
}
