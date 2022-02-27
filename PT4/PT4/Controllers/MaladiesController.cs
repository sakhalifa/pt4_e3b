using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Controllers
{
    internal class MaladiesController
    {
        private IMaladieRepository _maladieRepo;
        /// <summary>
        /// Constructor of the MaladieController object
        /// </summary>
        /// <param name="maladieRepo">The entity repository of the workers</param>
        public MaladiesController(IMaladieRepository maladieRepo)
        {
            _maladieRepo = maladieRepo;
        }

        /// <summary>
        /// Creates a sickness if it doesn't exist
        /// </summary>
        /// <param name="nomMaladie">The name of the sickness</param>
        public void CreerMaladie(string nomMaladie)
        {
            MALADIE maladie = _maladieRepo.FindWhere(m => m.NOMMALADIE == nomMaladie).FirstOrDefault();
            if (maladie != null)
            {
                throw new Exception("Une maladie porte déjà ce nom");
            }
            maladie = new MALADIE
            {
                NOMMALADIE = nomMaladie
            };

            _maladieRepo.Insert(maladie);
            _maladieRepo.Save();
        }

        /// <summary>
        /// Gets all sicknesses in the database
        /// </summary>
        /// <returns>All the sicknesses in the database</returns>
        public IEnumerable<MALADIE> ListerMaladies()
        {
            return _maladieRepo.FindAll();
        }
    }
}
