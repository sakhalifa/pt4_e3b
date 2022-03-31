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
    public class MaladieRepository : AbstractRepository<MALADIE>
    {
        public MaladieRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<MALADIE> FindAll()
        {
            return _context.Set<MALADIE>().AsQueryable();
        }

        public override MALADIE FindById(params object[] id)
        {
            return _context.Set<MALADIE>().Find(id);
        }

        public override void Insert(MALADIE obj)
        {
            _context.Set<MALADIE>().Add(obj);
        }

        public override void Delete(MALADIE obj)
        {
            _context.Set<MALADIE>().Remove(obj);
        }

        public override void Update(MALADIE obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<MALADIE> FindWhere(Expression<Func<MALADIE, bool>> predicate)
        {
            return _context.Set<MALADIE>().Where(predicate);
        }
    }
}
