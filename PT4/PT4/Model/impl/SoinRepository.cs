using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class SoinRepository : IGenericRepository<SOIN>, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities _context;

        public SoinRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this._context = context;
        }

        public IEnumerable<SOIN> FindAll()
        {
            return _context.SOIN.ToList();
        }

        public SOIN FindById(int id)
        {
            return _context.SOIN.Find(id);
        }

        public void Insert(SOIN obj)
        {
            _context.SOIN.Add(obj);
        }

        public void Delete(int id)
        {
            _context.SOIN.Remove(_context.SOIN.Find(id));
        }

        public void Update(SOIN obj)
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

        public IEnumerable<SOIN> FindWhere(Expression<Func<SOIN, bool>> predicate)
        {
            return _context.SOIN.Where(predicate);
        }
    }
}
