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
        IEnumerable<RENDEZVOUS> FindWhere(Expression<Func<RENDEZVOUS, bool>> predicate);
        RENDEZVOUS FindById(int id);
        void Insert(RENDEZVOUS obj);
        void Delete(int id);
        void Update(RENDEZVOUS obj);
        void Save();
    }
}
