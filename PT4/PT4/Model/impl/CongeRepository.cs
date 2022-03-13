﻿using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class CongeRepository : IGenericRepository<CONGÉ>, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities _context;

        public CongeRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this._context = context;
        }

        public IEnumerable<CONGÉ> FindAll()
        {
            return _context.CONGÉ.ToList();
        }

        public CONGÉ FindById(int id)
        {
            return _context.CONGÉ.Find(id);
        }

        public void Insert(CONGÉ obj)
        {
            _context.CONGÉ.Add(obj);
        }

        public void Delete(int id)
        {
            _context.CONGÉ.Remove(_context.CONGÉ.Find(id));
        }

        public void Update(CONGÉ obj)
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

        public IEnumerable<CONGÉ> FindWhere(Expression<Func<CONGÉ, bool>> predicate)
        {
            return _context.CONGÉ.Where(predicate);
        }
    }
}
