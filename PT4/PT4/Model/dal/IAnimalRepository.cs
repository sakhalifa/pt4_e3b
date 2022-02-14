using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Returns the animal that has the specified Id or null if not found
        /// </summary>
        /// <param name="animalId">The id of the animal we want to get</param>
        /// <returns>the animal that has the specified Id or null if not found</returns>
        ANIMAL FindById(int animalId);
        /// <summary>
        /// Inserts the specified animal object to the database
        /// </summary>
        /// <param name="animal">The animal object to insert</param>
        void Insert(ANIMAL animal);
        /// <summary>
        /// Deletes the animal that has the specified id
        /// </summary>
        /// <param name="animalId">The id of the animal we want to delete</param>
        void Delete(int animalId);
        /// <summary>
        /// Tells the database that this animal object was updated
        /// </summary>
        /// <param name="animal">The animal object to update</param>
        void Update(ANIMAL animal);
        /// <summary>
        /// Saves all pending changes to the database
        /// </summary>
        void Save();
    }
}
