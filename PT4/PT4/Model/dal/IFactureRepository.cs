using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.dal
{
    public interface IFactureRepository : IDisposable
    {
        /// <summary>
        /// Gets every bill in the database
        /// </summary>
        /// <returns>every bill in the database</returns>
        IEnumerable<FACTURE> FindAll();
        /// <summary>
        /// Gets every bill saved in the database that validates the predicate given
        /// </summary>
        /// <param name="predicate">A function wich takes an bill and returns a boolean. 
        /// It returns true if we want the bill to be included in the search, else false.</param>
        IEnumerable<FACTURE> FindWhere(Expression<Func<FACTURE, bool>> predicate);
        /// <summary>
        /// Finds the bill that has the specified id or null if not found
        /// </summary>
        /// <param name="id">The id of the bill</param>
        /// <returns>The bill that has the specified id or null if not found</returns>
        FACTURE FindById(int id);
        /// <summary>
        /// Inserts the specified bill object to the database
        /// </summary>
        /// <param name="obj">The bill object to insert</param>
        void Insert(FACTURE obj);
        /// <summary>
        /// Deletes the bill that has the specified id
        /// </summary>
        /// <param name="id">The id of the bill we want to delete</param>
        void Delete(int id);
        /// <summary>
        /// Tells the database that this bill object was updated
        /// </summary>
        /// <param name="obj">The bill object to update</param>
        void Update(FACTURE obj);
        /// <summary>
        /// Saves all pending changes to the database
        /// </summary>
        void Save();
    }
}
