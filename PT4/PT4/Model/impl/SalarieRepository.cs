using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class SalarieRepository : IGenericRepository<SALARIÉ>, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities _context;

        public SalarieRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this._context = context;
        }

        public IEnumerable<SALARIÉ> FindAll()
        {
            return _context.SALARIÉ.ToList();
        }

        public SALARIÉ FindById(int id)
        {
            return _context.SALARIÉ.Find(id);
        }

        public void Insert(SALARIÉ obj)
        {
            _context.SALARIÉ.Add(obj);
        }

        public void Delete(int id)
        {
            _context.SALARIÉ.Remove(_context.SALARIÉ.Find(id));
        }

        public void Update(SALARIÉ obj)
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

        public IEnumerable<SALARIÉ> FindWhere(Expression<Func<SALARIÉ, bool>> predicate)
        {
            return _context.SALARIÉ.Where(predicate);
        }
    }
}
