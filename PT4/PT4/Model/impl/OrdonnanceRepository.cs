using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class OrdonnanceRepository : IGenericRepository<ORDONNANCE>, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities _context;

        public OrdonnanceRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this._context = context;
        }

        public IEnumerable<ORDONNANCE> FindAll()
        {
            return _context.ORDONNANCE.ToList();
        }

        public ORDONNANCE FindById(int id)
        {
            return _context.ORDONNANCE.Find(id);
        }

        public void Insert(ORDONNANCE obj)
        {
            _context.ORDONNANCE.Add(obj);
        }

        public void Delete(int id)
        {
            _context.ORDONNANCE.Remove(_context.ORDONNANCE.Find(id));
        }

        public void Update(ORDONNANCE obj)
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

        public IEnumerable<ORDONNANCE> FindWhere(Expression<Func<ORDONNANCE, bool>> predicate)
        {
            return _context.ORDONNANCE.Where(predicate);
        }
    }
}
