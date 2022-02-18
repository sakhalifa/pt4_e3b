using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.dal
{
    interface ISoinRepository : IDisposable
    {
        IEnumerable<SOIN> FindAll();
        IEnumerable<SOIN> FindWhere(Expression<Func<SOIN, bool>> predicate);
        SOIN FindById(int id);
        void Insert(SOIN obj);
        void Delete(int id);
        void Update(SOIN obj);
        void Save();
    }
}
