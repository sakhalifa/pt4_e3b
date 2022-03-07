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
        /// <summary>
        /// Gets every customer saved in the database that validates the predicate given
        /// </summary>
        /// <param name="predicate">A function wich takes a customer and returns a boolean. 
        /// It returns true if we want the customer to be included in the search, else false.</param>
        /// <returns>Every customer saved in the database that validates the predicate given</returns>
        IEnumerable<CLIENT> FindWhere(Expression<Func<CLIENT, bool>> predicate);
        /// <summary>
        /// Finds the customer that has the specified id or null if not found
        /// </summary>
        /// <param name="id">The id of the customer</param>
        /// <returns>The customer that has the specified id or null if not found</returns>
        CLIENT FindById(int id);
        /// <summary>
        /// Inserts the specified customer object to the database
        /// </summary>
        /// <param name="obj">The customer object to insert</param>
        void Insert(CLIENT obj);
        /// <summary>
        /// Deletes the customer that has the specified id
        /// </summary>
        /// <param name="id">The id of the customer we want to delete</param>
        void Delete(int id);
        /// <summary>
        /// Tells the database that this customer object was updated
        /// </summary>
        /// <param name="obj">The customer object to update</param>
        void Update(CLIENT obj);
        /// <summary>
        /// Saves all pending changes to the database
        /// </summary>
        void Save();
    }
}
