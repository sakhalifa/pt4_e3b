using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.dal
{
    public interface IRendezVousRepository : IDisposable
    {
        /// <summary>
        /// Gets every appointment in the database
        /// </summary>
        /// <returns>Every appointment in the database</returns>
        IEnumerable<RENDEZVOUS> FindAll();
        /// <summary>
        /// Gets every appointment saved in the database that validates the predicate given
        /// </summary>
        /// <param name="predicate">A function wich takes an appointment and returns a boolean. 
        /// It returns true if we want the appointment to be included in the search, else false.</param>
        IEnumerable<RENDEZVOUS> FindWhere(Expression<Func<RENDEZVOUS, bool>> predicate);
        /// <summary>
        /// Finds the appointment that has the specified id or null if not found
        /// </summary>
        /// <param name="id">The id of the appointment</param>
        /// <returns>The appointment that has the specified id or null if not found</returns>
        RENDEZVOUS FindById(int id);
        /// <summary>
        /// Inserts the specified appointment object to the database
        /// </summary>
        /// <param name="obj">The appointment object to insert</param>
        void Insert(RENDEZVOUS obj);
        /// <summary>
        /// Deletes the appointment that has the specified id
        /// </summary>
        /// <param name="id">The id of the appointment we want to delete</param>
        void Delete(int id);
        /// <summary>
        /// Tells the database that this appointment object was updated
        /// </summary>
        /// <param name="obj">The appointment object to update</param>
        void Update(RENDEZVOUS obj);
        /// <summary>
        /// Saves all pending changes to the database
        /// </summary>
        void Save();
    }
}
