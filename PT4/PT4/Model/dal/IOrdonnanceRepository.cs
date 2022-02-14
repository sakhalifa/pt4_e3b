using System;
using System.Collections.Generic;
using System.Linq;
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
        ORDONNANCE FindById(int id);
        void Insert(ORDONNANCE obj);
        void Delete(int id);
        void Update(ORDONNANCE obj);
        void Save();
    }
}
