using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class RendezVousRepository : IGenericRepository<RENDEZVOUS>, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities _context;

        public RendezVousRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this._context = context;
        }

        public IEnumerable<RENDEZVOUS> FindAll()
        {
            return _context.RENDEZVOUS.ToList();
        }

        public RENDEZVOUS FindById(int id)
        {
            return _context.RENDEZVOUS.Find(id);
        }

        public void Insert(RENDEZVOUS obj)
        {
            _context.RENDEZVOUS.Add(obj);
        }

        public void Delete(int id)
        {
            _context.RENDEZVOUS.Remove(_context.RENDEZVOUS.Find(id));
        }

        public void Update(RENDEZVOUS obj)
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

        public IEnumerable<RENDEZVOUS> FindWhere(Expression<Func<RENDEZVOUS, bool>> predicate)
        {
            return _context.RENDEZVOUS.Where(predicate);
        }
    }
}
