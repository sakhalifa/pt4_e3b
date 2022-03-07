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
        /// <summary>
        /// Gets every sickness saved in the database that validates the predicate given
        /// </summary>
        /// <param name="predicate">A function wich takes an sickness and returns a boolean. 
        /// It returns true if we want the sickness to be included in the search, else false.</param>
        IEnumerable<MALADIE> FindWhere(Expression<Func<MALADIE, bool>> predicate);
        /// <summary>
        /// Finds the sickness that has the specified id or null if not found
        /// </summary>
        /// <param name="id">The id of the sickness</param>
        /// <returns>The sickness that has the specified id or null if not found</returns>
        MALADIE FindById(int id);
        /// <summary>
        /// Inserts the specified sickness object to the database
        /// </summary>
        /// <param name="obj">The sickness object to insert</param>
        void Insert(MALADIE obj);
        /// <summary>
        /// Deletes the sickness that has the specified id
        /// </summary>
        /// <param name="id">The id of the sickness we want to delete</param>
        void Delete(int id);
        /// <summary>
        /// Tells the database that this sickness object was updated
        /// </summary>
        /// <param name="obj">The sickness object to update</param>
        void Update(MALADIE obj);
        /// <summary>
        /// Saves all pending changes to the database
        /// </summary>
        void Save();
    }
}
