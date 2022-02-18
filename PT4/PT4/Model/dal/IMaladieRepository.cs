using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.dal
{
    public interface IMaladieRepository : IDisposable
    {
        /// <summary>
        /// Gets every sickness in the database
        /// </summary>
        /// <returns>Every sickness in the database</returns>
        IEnumerable<MALADIE> FindAll();
        IEnumerable<MALADIE> FindWhere(Expression<Func<MALADIE, bool>> predicate);
        MALADIE FindById(int id);
        void Insert(MALADIE obj);
        void Delete(int id);
        void Update(MALADIE obj);
        void Save();
    }
}
