using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class ProduitVenduRepository : AbstractRepository<PRODUIT_VENDU>
    {
        public ProduitVenduRepository(DbContext context) : base(context)
        {
        }

        public override void Delete(PRODUIT_VENDU obj)
        {
            _context.Set<PRODUIT_VENDU>().Remove(obj);
        }

        public override IQueryable<PRODUIT_VENDU> FindAll()
        {
            return _context.Set<PRODUIT_VENDU>().AsQueryable();
        }

        public override PRODUIT_VENDU FindById(int id)
        {
            throw new NotSupportedException("ERREUR! Ce n'est pas à récupérer via un id.");
        }

        public override IQueryable<PRODUIT_VENDU> FindWhere(Expression<Func<PRODUIT_VENDU, bool>> predicate)
        {
            return _context.Set<PRODUIT_VENDU>().Where(predicate);
        }

        public override void Insert(PRODUIT_VENDU obj)
        {
            _context.Set<PRODUIT_VENDU>().Add(obj);
        }

        public override void Update(PRODUIT_VENDU obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
