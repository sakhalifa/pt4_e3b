using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.dal
{
    public interface IOrdonnanceRepository : IDisposable
    {
        /// <summary>
        /// Gets every prescription in the database
        /// </summary>
        /// <returns>Every prescription in the database</returns>
        IEnumerable<ORDONNANCE> FindAll();
        /// <summary>
        /// Gets every prescription saved in the database that validates the predicate given
        /// </summary>
        /// <param name="predicate">A function wich takes an prescription and returns a boolean. 
        /// It returns true if we want the prescription to be included in the search, else false.</param>
        IEnumerable<ORDONNANCE> FindWhere(Expression<Func<ORDONNANCE, bool>> predicate);
        /// <summary>
        /// Finds the prescription that has the specified id or null if not found
        /// </summary>
        /// <param name="id">The id of the prescription</param>
        /// <returns>The prescription that has the specified id or null if not found</returns>
        ORDONNANCE FindById(int id);
        /// <summary>
        /// Inserts the specified prescription object to the database
        /// </summary>
        /// <param name="obj">The prescription object to insert</param>
        void Insert(ORDONNANCE obj);
        /// <summary>
        /// Deletes the prescription that has the specified id
        /// </summary>
        /// <param name="id">The id of the prescription we want to delete</param>
        void Delete(int id);
        /// <summary>
        /// Tells the database that this prescription object was updated
        /// </summary>
        /// <param name="obj">The prescription object to update</param>
        void Update(ORDONNANCE obj);
        /// <summary>
        /// Saves all pending changes to the database
        /// </summary>
        void Save();
    }
}
