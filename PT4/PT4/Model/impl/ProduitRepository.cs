using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class ProduitRepository : AbstractRepository<PRODUIT>
    {
        public ProduitRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context) : base(context)
        {
        }

        public override IEnumerable<PRODUIT> FindAll()
        {
            return _context.PRODUIT.ToList();
        }

        public override PRODUIT FindById(int id)
        {
            return _context.PRODUIT.Find(id);
        }

        public override void Insert(PRODUIT obj)
        {
            _context.PRODUIT.Add(obj);
        }

        public override void Delete(int id)
        {
            _context.PRODUIT.Remove(_context.PRODUIT.Find(id));
        }

        public override void Update(PRODUIT obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IEnumerable<PRODUIT> FindWhere(Expression<Func<PRODUIT, bool>> predicate)
        {
            return _context.PRODUIT.Where(predicate);
        }
    }
}
