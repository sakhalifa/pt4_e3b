using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class OrdonnanceRepository : AbstractRepository<ORDONNANCE>
    {
        public OrdonnanceRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context) : base(context)
        {
            
        }

        public override IEnumerable<ORDONNANCE> FindAll()
        {
            return _context.ORDONNANCE.ToList();
        }

        public override ORDONNANCE FindById(int id)
        {
            return _context.ORDONNANCE.Find(id);
        }

        public override void Insert(ORDONNANCE obj)
        {
            _context.ORDONNANCE.Add(obj);
        }

        public override void Delete(int id)
        {
            _context.ORDONNANCE.Remove(_context.ORDONNANCE.Find(id));
        }

        public override void Update(ORDONNANCE obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IEnumerable<ORDONNANCE> FindWhere(Expression<Func<ORDONNANCE, bool>> predicate)
        {
            return _context.ORDONNANCE.Where(predicate);
        }
    }
}
