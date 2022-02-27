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
        /// <summary>
        /// Gets every worker in the database
        /// </summary>
        /// <returns>every worker in the database</returns>
        IEnumerable<SALARIÉ> FindAll();
        /// <summary>
        /// Gets every worker saved in the database that validates the predicate given
        /// </summary>
        /// <param name="predicate">A function wich takes an worker and returns a boolean. 
        /// It returns true if we want the worker to be included in the search, else false.</param>
        IEnumerable<SALARIÉ> FindWhere(Expression<Func<SALARIÉ, bool>> predicate);
        /// <summary>
        /// Finds the worker that has the specified id or null if not found
        /// </summary>
        /// <param name="id">The id of the worker</param>
        /// <returns>The worker that has the specified id or null if not found</returns>
        SALARIÉ FindById(int id);
        /// <summary>
        /// Inserts the specified worker object to the database
        /// </summary>
        /// <param name="obj">The worker object to insert</param>
        void Insert(SALARIÉ obj);
        /// <summary>
        /// Deletes the worker that has the specified id
        /// </summary>
        /// <param name="id">The id of the worker we want to delete</param>
        void Delete(int id);
        /// <summary>
        /// Tells the database that this worker object was updated
        /// </summary>
        /// <param name="obj">The worker object to update</param>
        void Update(SALARIÉ obj);
        /// <summary>
        /// Saves all pending changes to the database
        /// </summary>
        void Save();
    }
}
