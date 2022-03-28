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

        /// <summary>
        /// Creates a new order 
        /// </summary>
        /// <param name="orderDate">The date when the order is created</param>
        /// <param name="animal">The animal for whom is intended the order</param>
        /// <param name="care">The care that need the animal</param>
        public void CreerOrdonnance(DateTime orderDate, ANIMAL animal, SOIN care)
        {   
            ORDONNANCE order = new ORDONNANCE
            {
                DATEORDO = orderDate,
                ANIMAL = animal,
                SOIN = care,
<<<<<<< HEAD
<<<<<<< HEAD
=======
                
>>>>>>> 02c2c72 (Creation ordonnance)
=======
>>>>>>> ab736e5 (fix la fenetre de prescription)
            };

            _ordonnanceRepository.Insert(order);
            _ordonnanceRepository.Save();
        }
    }
}
