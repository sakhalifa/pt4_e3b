using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class FactureRepository : AbstractRepository<FACTURE>
    {
        public FactureRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context) : base(context)
        {
        }

        public override IEnumerable<FACTURE> FindAll()
        {
            return _context.FACTURE.ToList();
        }

        public override FACTURE FindById(int id)
        {
            return _context.FACTURE.Find(id);
        }

        public override void Insert(FACTURE obj)
        {
            _context.FACTURE.Add(obj);
        }

        public override void Delete(int id)
        {
            _context.FACTURE.Remove(_context.FACTURE.Find(id));
        }

        public override void Update(FACTURE obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IEnumerable<FACTURE> FindWhere(Expression<Func<FACTURE, bool>> predicate)
        {
            return _context.FACTURE.Where(predicate);
        }
    }
}
