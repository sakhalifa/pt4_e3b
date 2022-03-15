using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class ClientRepository : AbstractRepository<CLIENT>
    {

        public ClientRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context) : base(context)
        {
        }

        public override IEnumerable<CLIENT> FindAll()
        {
            return _context.CLIENT.ToList();
        }

        public override CLIENT FindById(int id)
        {
            return _context.CLIENT.Find(id);
        }

        public override void Insert(CLIENT obj)
        {
            _context.CLIENT.Add(obj);
        }

        public override void Delete(int id)
        {
            _context.CLIENT.Remove(_context.CLIENT.Find(id));
        }

        public override void Update(CLIENT obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public override IEnumerable<CLIENT> FindWhere(Expression<Func<CLIENT, bool>> predicate)
        {
            return _context.CLIENT.Where(predicate);
        }
    }
}
