using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PT4.Model.impl
{
    public class HistoriqueMaladieRepository : AbstractRepository<HISTORIQUEMALADIE>
    {
        public HistoriqueMaladieRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<HISTORIQUEMALADIE> FindAll()
        {
            return _context.Set<HISTORIQUEMALADIE>().AsQueryable();
        }

        public override HISTORIQUEMALADIE FindById(params object[] id)
        {
            return _context.Set<HISTORIQUEMALADIE>().Find(id);
        }

        public override void Insert(HISTORIQUEMALADIE obj)
        {
            _context.Set<HISTORIQUEMALADIE>().Add(obj);
        }

        public override void Delete(HISTORIQUEMALADIE obj)
        {
            _context.Set<HISTORIQUEMALADIE>().Remove(obj);
        }

        public override void Update(HISTORIQUEMALADIE obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public override IQueryable<HISTORIQUEMALADIE> FindWhere(Expression<Func<HISTORIQUEMALADIE, bool>> predicate)
        {
            return _context.Set<HISTORIQUEMALADIE>().Where(predicate);
        }
    }
}
