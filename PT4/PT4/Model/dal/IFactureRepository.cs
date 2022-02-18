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
        IEnumerable<FACTURE> FindWhere(Expression<Func<FACTURE, bool>> predicate);
        FACTURE FindById(int id);
        void Insert(FACTURE obj);
        void Delete(int id);
        void Update(FACTURE obj);
        void Save();
    }
}
