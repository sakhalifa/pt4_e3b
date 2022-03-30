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

        /// <summary>
        /// Constructor of the OrdonnanceController object
        /// </summary>
        /// <param name="ordonnanceRepository">The entity repository of the orders</param>
        public OrdonnanceController(IGenericRepository<ORDONNANCE> ordonnanceRepository)
        {
            _ordonnanceRepository = ordonnanceRepository;
        }

        public void CreerOrdonnance(ANIMAL animal, IEnumerable<SOIN> soins)
        {

            _ordonnanceRepository.Insert(new ORDONNANCE()
            {
                ANIMAL = animal,
                SOIN = soins.ToList(),
                DATEORDO = DateTime.Now
            });
            _ordonnanceRepository.Save();
        }
    }
}
