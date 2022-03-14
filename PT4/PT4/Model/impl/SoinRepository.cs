using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class SoinRepository : AbstractRepository<SOIN>
    {
        public SoinRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context) : base(context)
        {
        }

        public override IEnumerable<SOIN> FindAll()
        {
            return _context.SOIN.ToList();
        }

        public override SOIN FindById(int id)
        {
            return _context.SOIN.Find(id);
        }

        public override void Insert(SOIN obj)
        {
            _context.SOIN.Add(obj);
        }

        public override void Delete(int id)
        {
            _context.SOIN.Remove(_context.SOIN.Find(id));
        }

        public override void Update(SOIN obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IEnumerable<SOIN> FindWhere(Expression<Func<SOIN, bool>> predicate)
        {
            return _context.SOIN.Where(predicate);
        }
    }
}
