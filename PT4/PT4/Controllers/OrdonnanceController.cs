using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Controllers
{
    public class OrdonnanceController
    {
        private IGenericRepository<ORDONNANCE> _ordonnanceRepository;

        public OrdonnanceController(IGenericRepository<ORDONNANCE> ordonnanceRepository)
        {
            _ordonnanceRepository = ordonnanceRepository;
        }

        public void CreerOrdonnance(DateTime dateOrdonnance)
        {
            _ordonnanceRepository.Insert(new ORDONNANCE
            {
                DATEORDO = dateOrdonnance
            });
        }

    }
}
