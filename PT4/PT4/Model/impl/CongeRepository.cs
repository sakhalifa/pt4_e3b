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
    public class CongeRepository : AbstractRepository<CONGÉ>
    {
        public CongeRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<CONGÉ> FindAll()
        {
            return _context.Set<CONGÉ>().ToList();
        }

        public override CONGÉ FindById(int id)
        {
            return _context.Set<CONGÉ>().Find(id);
        }

        public override void Insert(CONGÉ obj)
        {
            _context.Set<CONGÉ>().Add(obj);
        }

        public override void Delete(CONGÉ obj)
        {
            _context.Set<CONGÉ>().Remove(obj);
        }

        public override void Update(CONGÉ obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IEnumerable<CONGÉ> FindWhere(Expression<Func<CONGÉ, bool>> predicate)
        {
            return _context.Set<CONGÉ>().Where(predicate);
        }
    }
}
