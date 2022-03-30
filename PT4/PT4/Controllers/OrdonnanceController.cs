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

        public void DeletePrescription(ORDONNANCE o)
        {
            var allSoin = o.SOIN;
            foreach(SOIN s in allSoin)
            {
                s.ORDONNANCE.Remove(o);
            }
            _ordonnanceRepository.Delete(o);
            _ordonnanceRepository.Save();
        }

        public void SubscribePrescription(OnChanged<ORDONNANCE> onChanged)
        {
            _ordonnanceRepository.Subscribe(onChanged);
        }

        public void UnSubscribePrescription(OnChanged<ORDONNANCE> onChanged)
        {
            _ordonnanceRepository.UnSubscribe(onChanged);
        }

        public void SubscribeDeletePrescription(OnDelete<ORDONNANCE> onDelete)
        {
            _ordonnanceRepository.SubscribeDelete(onDelete);
        }

        public void UnSubscribeDeletePrescription(OnDelete<ORDONNANCE> onDelete)
        {
            _ordonnanceRepository.UnSubscribeDelete(onDelete);
        }
    }
}
