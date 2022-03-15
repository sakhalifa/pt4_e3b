using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    public class ProduitRepository : AbstractRepository<PRODUIT>
    {
        public ProduitRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<PRODUIT> FindAll()
        {
            return _context.Set<PRODUIT>().ToList();
        }

        public override PRODUIT FindById(int id)
        {
            return _context.Set<PRODUIT>().Find(id);
        }

        public override void Insert(PRODUIT obj)
        {
            _context.Set<PRODUIT>().Add(obj);
        }

        public override void Delete(PRODUIT obj)
        {
            _context.Set<PRODUIT>().Remove(obj);
        }

        public override void Update(PRODUIT obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IEnumerable<PRODUIT> FindWhere(Expression<Func<PRODUIT, bool>> predicate)
        {
            return _context.Set<PRODUIT>().Where(predicate);
        }
    }
}
