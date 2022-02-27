using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.dal
{
    interface ICongeRepository : IDisposable
    {
        /// <summary>
        /// Gets every holidays in the database
        /// </summary>
        /// <returns>every holidays in the database</returns>
        IEnumerable<CONGÉ> FindAll();
        /// <summary>
        /// Gets every holidays saved in the database that validates the predicate given
        /// </summary>
        /// <param name="predicate">A function wich takes an holidays and returns a boolean. 
        /// It returns true if we want the holidays to be included in the search, else false.</param>
        /// <returns>Every holidays saved in the database that validates the predicate given</returns>
        IEnumerable<CONGÉ> FindWhere(Expression<Func<CONGÉ, bool>> predicate);
        /// <summary>
        /// Finds the holidays that has the specified id or null if not found
        /// </summary>
        /// <param name="id">The id of the holidays</param>
        /// <returns>The holidays that has the specified id or null if not found</returns>
        CONGÉ FindById(int id);
        /// <summary>
        /// Inserts the specified holidays object to the database
        /// </summary>
        /// <param name="obj">The holidays object to insert</param>
        void Insert(CONGÉ obj);
        /// <summary>
        /// Deletes the holidays that has the specified id
        /// </summary>
        /// <param name="id">The id of the holidays we want to delete</param>
        void Delete(int id);
        /// <summary>
        /// Tells the database that this holidays object was updated
        /// </summary>
        /// <param name="obj">The holidays object to update</param>
        void Update(CONGÉ obj);
        /// <summary>
        /// Saves all pending changes to the database
        /// </summary>
        void Save();
    }
}
