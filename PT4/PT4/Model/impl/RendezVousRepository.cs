using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class RendezVousRepository : AbstractRepository<RENDEZVOUS>
    {
        public RendezVousRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context) : base(context)
        {
        }

        public override IEnumerable<RENDEZVOUS> FindAll()
        {
            return _context.RENDEZVOUS.ToList();
        }

        public override RENDEZVOUS FindById(int id)
        {
            return _context.RENDEZVOUS.Find(id);
        }

        public override void Insert(RENDEZVOUS obj)
        {
            _context.RENDEZVOUS.Add(obj);
        }

        public override void Delete(int id)
        {
            _context.RENDEZVOUS.Remove(_context.RENDEZVOUS.Find(id));
        }

        public override void Update(RENDEZVOUS obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IEnumerable<RENDEZVOUS> FindWhere(Expression<Func<RENDEZVOUS, bool>> predicate)
        {
            return _context.RENDEZVOUS.Where(predicate);
        }
    }
}
