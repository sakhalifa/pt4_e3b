using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.dal
{
    interface ISoinRepository : IDisposable
    {
        IEnumerable<SOIN> FindAll();
        SOIN FindById(int id);
        void Insert(SOIN obj);
        void Delete(int id);
        void Update(SOIN obj);
        void Save();
    }
}
