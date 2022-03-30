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

        public void CreateCare(IEnumerable<MALADIE> diseases, IEnumerable<PRODUIT> products, string description)
        {
            SOIN newCare = new SOIN
            {
                DESCRIPTION = description,
                MALADIE = diseases.ToList(),
                PRODUIT = products.ToList()
            };
            _soinRepository.Insert(newCare);

            _soinRepository.Save();
        }

        /// <summary>
        /// Find all cares in the database
        /// </summary>
        public IQueryable<SOIN> FindAll()
        {
            return _soinRepository.FindAll();
        }
    }
}
