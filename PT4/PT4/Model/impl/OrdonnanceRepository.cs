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
    public class OrdonnanceRepository : AbstractRepository<ORDONNANCE>
    {
        public OrdonnanceRepository(DbContext context) : base(context)
        {
            
        }

        public override IEnumerable<ORDONNANCE> FindAll()
        {
            return _context.Set<ORDONNANCE>().ToList();
        }

        public override ORDONNANCE FindById(int id)
        {
            return _context.Set<ORDONNANCE>().Find(id);
        }

        public override void Insert(ORDONNANCE obj)
        {
            _context.Set<ORDONNANCE>().Add(obj);
        }

        public override void Delete(ORDONNANCE obj)
        {
            _context.Set<ORDONNANCE>().Remove(obj);
        }

        public override void Update(ORDONNANCE obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IEnumerable<ORDONNANCE> FindWhere(Expression<Func<ORDONNANCE, bool>> predicate)
        {
            return _context.Set<ORDONNANCE>().Where(predicate);
        }
    }
}
