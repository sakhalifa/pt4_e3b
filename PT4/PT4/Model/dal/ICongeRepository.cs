﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.dal
{
    interface ICongeRepository : IDisposable
    {
        /// <summary>
        /// Gets every holydays in the database
        /// </summary>
        /// <returns>every holydays in the database</returns>
        IEnumerable<CONGÉ> FindAll();
        CONGÉ FindById(int id);
        void Insert(CONGÉ obj);
        void Delete(int id);
        void Update(CONGÉ obj);
        void Save();
    }
}
