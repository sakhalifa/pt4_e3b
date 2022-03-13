using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class FactureRepository : IGenericRepository<FACTURE>, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities _context;

        public FactureRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this._context = context;
        }

        public IEnumerable<FACTURE> FindAll()
        {
            return _context.FACTURE.ToList();
        }

        public FACTURE FindById(int id)
        {
            return _context.FACTURE.Find(id);
        }

        public void Insert(FACTURE obj)
        {
            _context.FACTURE.Add(obj);
        }

        public void Delete(int id)
        {
            _context.FACTURE.Remove(_context.FACTURE.Find(id));
        }

        public void Update(FACTURE obj)
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

        public IEnumerable<FACTURE> FindWhere(Expression<Func<FACTURE, bool>> predicate)
        {
            return _context.FACTURE.Where(predicate);
        }
    }
}
