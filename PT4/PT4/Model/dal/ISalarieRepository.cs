using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.dal
{
    interface ISalarieRepository : IDisposable
    {
        IEnumerable<SALARIÉ> FindAll();
        SALARIÉ FindById(int id);
        void Insert(SALARIÉ obj);
        void Delete(int id);
        void Update(SALARIÉ obj);
        void Save();
    }
}
