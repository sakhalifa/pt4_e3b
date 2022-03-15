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
    public class SoinRepository : AbstractRepository<SOIN>
    {
        public SoinRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<SOIN> FindAll()
        {
            return _context.Set<SOIN>().ToList();
        }

        public override SOIN FindById(int id)
        {
            return _context.Set<SOIN>().Find(id);
        }

        public override void Insert(SOIN obj)
        {
            _context.Set<SOIN>().Add(obj);
        }

        public override void Delete(SOIN obj)
        {
            _context.Set<SOIN>().Remove(obj);
        }

        public override void Update(SOIN obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IEnumerable<SOIN> FindWhere(Expression<Func<SOIN, bool>> predicate)
        {
            return _context.Set<SOIN>().Where(predicate);
        }
    }
}
