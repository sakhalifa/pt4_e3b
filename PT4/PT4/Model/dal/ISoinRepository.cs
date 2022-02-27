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
        /// <summary>
        /// Gets every care in the database
        /// </summary>
        /// <returns>every care in the database</returns>
        IEnumerable<SOIN> FindAll();
        /// <summary>
        /// Gets every care saved in the database that validates the predicate given
        /// </summary>
        /// <param name="predicate">A function wich takes an care and returns a boolean. 
        /// It returns true if we want the care to be included in the search, else false.</param>
        IEnumerable<SOIN> FindWhere(Expression<Func<SOIN, bool>> predicate);
        /// <summary>
        /// Finds the care that has the specified id or null if not found
        /// </summary>
        /// <param name="id">The id of the care</param>
        /// <returns>The care that has the specified id or null if not found</returns>
        SOIN FindById(int id);
        /// <summary>
        /// Inserts the specified care object to the database
        /// </summary>
        /// <param name="obj">The care object to insert</param>
        void Insert(SOIN obj);
        /// <summary>
        /// Deletes the care that has the specified id
        /// </summary>
        /// <param name="id">The id of the care we want to delete</param>
        void Delete(int id);
        /// <summary>
        /// Tells the database that this care object was updated
        /// </summary>
        /// <param name="obj">The care object to update</param>
        void Update(SOIN obj);
        /// <summary>
        /// Saves all pending changes to the database
        /// </summary>
        void Save();
    }
}
