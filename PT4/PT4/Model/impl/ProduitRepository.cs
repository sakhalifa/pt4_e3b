using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class ProduitRepository : IProduitRepository, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context;

        public ProduitRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this.context = context;
        }

        public IEnumerable<PRODUIT> FindAll()
        {
            return context.PRODUIT.ToList();
        }

        public IEnumerable<PRODUIT> FindAllDrugs()
        {
            return context.PRODUIT.Where(p => p.MEDICAMENT).ToList();
        }

        public IEnumerable<PRODUIT> FindAllCommercialProducts()
        {
            return context.PRODUIT.Where(p => !p.MEDICAMENT).ToList();
        }

        public PRODUIT FindById(int id)
        {
            return context.PRODUIT.Find(id);
        }

        public void Insert(PRODUIT obj)
        {
            context.PRODUIT.Add(obj);
        }

        public void Delete(int id)
        {
            context.PRODUIT.Remove(context.PRODUIT.Find(id));
        }

        public void Update(PRODUIT obj)
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

        public IEnumerable<PRODUIT> FindWhere(Expression<Func<PRODUIT, bool>> predicate)
        {
            return context.PRODUIT.Where(predicate);
        }
    }
}
