using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.dal
{
    public interface IAnimalRepository : IDisposable
    {
        /// <summary>
        /// Gets every animal saved in the database
        /// </summary>
        /// <returns>every animal saved in the database</returns>
        IEnumerable<ANIMAL> FindAll();
        /// <summary>
        /// Gets every animal saved in the database that validates the predicate given
        /// </summary>
        /// <param name="predicate">A function wich takes an animal and returns a boolean. 
        /// It returns true if we want the animal to be included in the search, else false.</param>
        /// <returns>Every animal saved in the database that validates the predicate given</returns>
        IEnumerable<ANIMAL> FindWhere(Expression<Func<ANIMAL, bool>> predicate);
        /// <summary>
        /// Returns the animal that has the specified Id or null if not found
        /// </summary>
        /// <param name="id">The id of the animal we want to get</param>
        /// <returns>the animal that has the specified Id or null if not found</returns>
        ANIMAL FindById(int id);
        /// <summary>
        /// Inserts the specified animal object to the database
        /// </summary>
        /// <param name="obj">The animal object to insert</param>
        void Insert(ANIMAL obj);
        /// <summary>
        /// Deletes the animal that has the specified id
        /// </summary>
        /// <param name="id">The id of the animal we want to delete</param>
        void Delete(int id);
        /// <summary>
        /// Tells the database that this animal object was updated
        /// </summary>
        /// <param name="obj">The animal object to update</param>
        void Update(ANIMAL obj);
        /// <summary>
        /// Saves all pending changes to the database
        /// </summary>
        void Save();
    }
}
