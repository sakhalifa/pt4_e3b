using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class CongeRepository : AbstractRepository<CONGÉ>
    {
        public CongeRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context) : base(context)
        {
        }

        public override IEnumerable<CONGÉ> FindAll()
        {
            return _context.CONGÉ.ToList();
        }

        public override CONGÉ FindById(int id)
        {
            return _context.CONGÉ.Find(id);
        }

        public override void Insert(CONGÉ obj)
        {
            _context.CONGÉ.Add(obj);
        }

        public override void Delete(int id)
        {
            _context.CONGÉ.Remove(_context.CONGÉ.Find(id));
        }

        public override void Update(CONGÉ obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IEnumerable<CONGÉ> FindWhere(Expression<Func<CONGÉ, bool>> predicate)
        {
            return _context.CONGÉ.Where(predicate);
        }
    }
}
