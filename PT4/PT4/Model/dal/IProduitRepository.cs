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
        IEnumerable<PRODUIT> FindAllDrugs();
        IEnumerable<PRODUIT> FindAllCommercialProducts();
        IEnumerable<PRODUIT> FindWhere(Expression<Func<PRODUIT, bool>> predicate);
        PRODUIT FindById(int id);
        void Insert(PRODUIT obj);
        void Delete(int id);
        void Update(PRODUIT obj);
        void Save();
    }
}
