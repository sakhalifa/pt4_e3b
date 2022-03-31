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
    public class RendezVousRepository : AbstractRepository<RENDEZVOUS>
    {
        public RendezVousRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<RENDEZVOUS> FindAll()
        {
            return _context.Set<RENDEZVOUS>().AsQueryable();
        }

        public override RENDEZVOUS FindById(params object[] id)
        {
            return _context.Set<RENDEZVOUS>().Find(id);
        }

        public override void Insert(RENDEZVOUS obj)
        {
            _context.Set<RENDEZVOUS>().Add(obj);
        }

        public override void Delete(RENDEZVOUS obj)
        {
            _context.Set<RENDEZVOUS>().Remove(obj);
        }

        public override void Update(RENDEZVOUS obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<RENDEZVOUS> FindWhere(Expression<Func<RENDEZVOUS, bool>> predicate)
        {
            return _context.Set<RENDEZVOUS>().Where(predicate);
        }
    }
}
