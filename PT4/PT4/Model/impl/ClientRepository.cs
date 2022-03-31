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
    public class ClientRepository : AbstractRepository<CLIENT>
    {

        public ClientRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<CLIENT> FindAll()
        {
            return _context.Set<CLIENT>().AsQueryable();
        }

        public override CLIENT FindById(params object[] id)
        {
            return _context.Set<CLIENT>().Find(id);
        }

        public override void Insert(CLIENT obj)
        {
            _context.Set<CLIENT>().Add(obj);
        }

        public override void Delete(CLIENT obj)
        {
            _context.Set<CLIENT>().Remove(obj);
        }

        public override void Update(CLIENT obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<CLIENT> FindWhere(Expression<Func<CLIENT, bool>> predicate)
        {
            return _context.Set<CLIENT>().Where(predicate);
        }
    }
}
