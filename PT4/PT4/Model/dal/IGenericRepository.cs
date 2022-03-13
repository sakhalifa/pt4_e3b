using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.dal
{
    public interface IGenericRepository<T> : IDisposable
    {
        /// <summary>
        /// Gets every <typeparamref name="T"/> in the database
        /// </summary>
        /// <returns>Every <typeparamref name="T"/> in the database</returns>
        IEnumerable<T> FindAll();
        /// <summary>
        /// Gets every <typeparamref name="T"/> saved in the database that validates the predicate given
        /// </summary>
        /// <param name="predicate">A function wich takes an <typeparamref name="T"/> and returns a boolean. 
        /// It returns true if we want the <typeparamref name="T"/> to be included in the search, else false.</param>
        IEnumerable<T> FindWhere(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Finds the <typeparamref name="T"/> that has the specified id or null if not found
        /// </summary>
        /// <param name="id">The id of the <typeparamref name="T"/></param>
        /// <returns>The <typeparamref name="T"/> that has the specified id or null if not found</returns>
        T FindById(int id);
        /// <summary>
        /// Inserts the specified <typeparamref name="T"/> object to the database
        /// </summary>
        /// <param name="obj">The <typeparamref name="T"/> object to insert</param>
        void Insert(T obj);
        /// <summary>
        /// Deletes the <typeparamref name="T"/> that has the specified id
        /// </summary>
        /// <param name="id">The id of the <typeparamref name="T"/> we want to delete</param>
        void Delete(int id);
        /// <summary>
        /// Tells the database that this <typeparamref name="T"/> object was updated
        /// </summary>
        /// <param name="obj">The <typeparamref name="T"/> object to update</param>
        void Update(T obj);
        /// <summary>
        /// Saves all pending changes to the database
        /// </summary>
        void Save();
    }
}
