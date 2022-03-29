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
    public class SalarieRepository : AbstractRepository<SALARIÉ>
    {
        public SalarieRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<SALARIÉ> FindAll()
        {
            return _context.Set<SALARIÉ>().AsQueryable();
        }

        public override SALARIÉ FindById(params object[] id)
        {
            return _context.Set<SALARIÉ>().Find(id);
        }

        public override void Insert(SALARIÉ obj)
        {
            _context.Set<SALARIÉ>().Add(obj);
        }

        public override void Delete(SALARIÉ obj)
        {
            _context.Set<SALARIÉ>().Remove(obj);
        }

        public override void Update(SALARIÉ obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<SALARIÉ> FindWhere(Expression<Func<SALARIÉ, bool>> predicate)
        {
            return _context.Set<SALARIÉ>().Where(predicate);
        }
    }
}
