using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class SalarieRepository : AbstractRepository<SALARIÉ>
    {
        public SalarieRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context) : base(context)
        {
        }

        public override IEnumerable<SALARIÉ> FindAll()
        {
            return _context.SALARIÉ.ToList();
        }

        public override SALARIÉ FindById(int id)
        {
            return _context.SALARIÉ.Find(id);
        }

        public override void Insert(SALARIÉ obj)
        {
            _context.SALARIÉ.Add(obj);
        }

        public override void Delete(int id)
        {
            _context.SALARIÉ.Remove(_context.SALARIÉ.Find(id));
        }

        public override void Update(SALARIÉ obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IEnumerable<SALARIÉ> FindWhere(Expression<Func<SALARIÉ, bool>> predicate)
        {
            return _context.SALARIÉ.Where(predicate);
        }
    }
}
