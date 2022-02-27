using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.dal
{
    public interface IProduitRepository : IDisposable
    {
        /// <summary>
        /// Gets every product in the database
        /// </summary>
        /// <returns>Every product in the database</returns>
        IEnumerable<PRODUIT> FindAll();
        /// <summary>
        /// Gets every product saved in the database that validates the predicate given
        /// </summary>
        /// <param name="predicate">A function wich takes an product and returns a boolean. 
        /// It returns true if we want the product to be included in the search, else false.</param>
        IEnumerable<PRODUIT> FindWhere(Expression<Func<PRODUIT, bool>> predicate);
        /// <summary>
        /// Finds the product that has the specified id or null if not found
        /// </summary>
        /// <param name="id">The id of the product</param>
        /// <returns>The product that has the specified id or null if not found</returns>
        PRODUIT FindById(int id);
        /// <summary>
        /// Inserts the specified product object to the database
        /// </summary>
        /// <param name="obj">The product object to insert</param>
        void Insert(PRODUIT obj);
        /// <summary>
        /// Deletes the product that has the specified id
        /// </summary>
        /// <param name="id">The id of the product we want to delete</param>
        void Delete(int id);
        /// <summary>
        /// Tells the database that this product object was updated
        /// </summary>
        /// <param name="obj">The product object to update</param>
        void Update(PRODUIT obj);
        /// <summary>
        /// Saves all pending changes to the database
        /// </summary>
        void Save();
    }
}
