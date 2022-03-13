﻿using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class ProduitRepository : IGenericRepository<PRODUIT>, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities _context;

        public ProduitRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this._context = context;
        }

        public IEnumerable<PRODUIT> FindAll()
        {
            return _context.PRODUIT.ToList();
        }

        public IEnumerable<PRODUIT> FindAllDrugs()
        {
            return _context.PRODUIT.Where(p => p.MEDICAMENT).ToList();
        }

        public IEnumerable<PRODUIT> FindAllCommercialProducts()
        {
            return _context.PRODUIT.Where(p => !p.MEDICAMENT).ToList();
        }

        public PRODUIT FindById(int id)
        {
            return _context.PRODUIT.Find(id);
        }

        public void Insert(PRODUIT obj)
        {
            _context.PRODUIT.Add(obj);
        }

        public void Delete(int id)
        {
            _context.PRODUIT.Remove(_context.PRODUIT.Find(id));
        }

        public void Update(PRODUIT obj)
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

        public IEnumerable<PRODUIT> FindWhere(Expression<Func<PRODUIT, bool>> predicate)
        {
            return _context.PRODUIT.Where(predicate);
        }
    }
}
