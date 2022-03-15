using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Controllers
{
    public class SoinController
    {
        private IGenericRepository<SOIN> _soinRepository;

        public SoinController(IGenericRepository<SOIN> soinRepo)
        {
            _soinRepository = soinRepo;
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
