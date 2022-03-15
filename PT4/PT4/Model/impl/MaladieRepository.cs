using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class MaladieRepository : AbstractRepository<MALADIE>
    {
        public MaladieRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context) : base(context)
        {
        }

        public override IEnumerable<MALADIE> FindAll()
        {
            return _context.MALADIE.ToList();
        }

        public override MALADIE FindById(int id)
        {
            return _context.MALADIE.Find(id);
        }

        public override void Insert(MALADIE obj)
        {
            _context.MALADIE.Add(obj);
        }

        public override void Delete(int id)
        {
            _context.MALADIE.Remove(_context.MALADIE.Find(id));
        }

        public override void Update(MALADIE obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IEnumerable<MALADIE> FindWhere(Expression<Func<MALADIE, bool>> predicate)
        {
            return _context.MALADIE.Where(predicate);
        }
    }
}
