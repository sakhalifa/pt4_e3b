using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.dal
{
    interface ISalarieRepository : IDisposable
    {
        IEnumerable<SALARIÉ> FindAll();
        IEnumerable<SALARIÉ> FindWhere(Expression<Func<SALARIÉ, bool>> predicate);
        SALARIÉ FindById(int id);
        void Insert(SALARIÉ obj);
        void Delete(int id);
        void Update(SALARIÉ obj);
        void Save();
    }
}
