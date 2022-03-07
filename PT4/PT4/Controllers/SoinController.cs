using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Controllers
{
    internal class SoinController
    {
        private ISoinRepository _soinRepository;

        public SoinController(ISoinRepository soinRepo)
        {
            soinRepo = _soinRepository;
        }





        public void CreerSoin(string description)
        {
            _soinRepository.Insert(new SOIN
            {
                DESCRIPTION = description
            });
        }








    }
}
