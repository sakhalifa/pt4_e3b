using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.dal
{
    public interface IClientRepository : IDisposable
    {
        /// <summary>
        /// Gets every customer in the database
        /// </summary>
        /// <returns>every customer in the database</returns>
        IEnumerable<CLIENT> FindAll();
        IEnumerable<CLIENT> FindWhere(Expression<Func<CLIENT, bool>> predicate);
        /// <summary>
        /// Finds the customer that has the specified id or null if not found
        /// </summary>
        /// <param name="id">The id of the customer</param>
        /// <returns>The customer that has the specified id or null if not found</returns>
        CLIENT FindById(int id);
        void Insert(CLIENT obj);
        void Delete(int id);
        void Update(CLIENT obj);
        void Save();
    }
}
