using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Controllers
{
    public class MaladiesController
    {
        private IGenericRepository<MALADIE> _maladieRepo;
        /// <summary>
        /// Constructor of the MaladieController object
        /// </summary>
        /// <param name="maladieRepo">The entity repository of the workers</param>
        public MaladiesController(IGenericRepository<MALADIE> maladieRepo)
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

        /// <summary>
        /// Search a sickness according to certain criterias. If a criteria is null, it is ignored.
        /// </summary>
        /// <param name="nom">The name of the sickness</param>
        /// <param name="estSoignable">Does it have at least 1 care assigned to it?</param>
        /// <param name="aEteContracte">Has it been contracted at least once?</param>
        /// <returns></returns>
        public IEnumerable<MALADIE> RechercherMaladies(string nom = null, bool? estSoignable = null, bool? aEteContracte = null)
        {
            return _maladieRepo.FindWhere(m => (nom == null || m.NOMMALADIE == nom)
            && (estSoignable == null || (estSoignable.Value ? m.SOIN.Count > 0 : m.SOIN.Count == 0))
            && (aEteContracte == null || (aEteContracte.Value ? m.HISTORIQUEMALADIE.Count > 0 : m.HISTORIQUEMALADIE.Count == 0)));
        }
    }
}
