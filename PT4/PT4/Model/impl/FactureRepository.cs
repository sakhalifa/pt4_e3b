using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PT4.Model.impl
{
    public class FactureRepository : AbstractRepository<FACTURE>
    {
        public FactureRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<FACTURE> FindAll()
        {
            return _context.Set<FACTURE>().AsQueryable();
        }

        public override FACTURE FindById(params object[] id)
        {
            return _context.Set<FACTURE>().Find(id);
        }

        public override void Insert(FACTURE obj)
        {
            _context.Set<FACTURE>().Add(obj);
        }

        public override void Delete(FACTURE obj)
        {
            _context.Set<FACTURE>().Remove(obj);
        }

        public override void Update(FACTURE obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<FACTURE> FindWhere(Expression<Func<FACTURE, bool>> predicate)
        {
            return _context.Set<FACTURE>().Where(predicate);
        }
    }
}
