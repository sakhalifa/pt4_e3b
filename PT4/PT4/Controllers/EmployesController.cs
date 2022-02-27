using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Controllers
{
    internal class EmployesController
    {
        private ISalarieRepository _salarieRepo;
        private ICongeRepository _congeRepo;

        /// <summary>
        /// Constructor of the EmployesController object
        /// </summary>
        /// <param name="salarieRepo">The entity repository of the workers</param>
        /// <param name="congeRepo">The entity repository of the holidays</param>
        public EmployesController(ISalarieRepository salarieRepo, ICongeRepository congeRepo)
        {
            _salarieRepo = salarieRepo;
            _congeRepo = congeRepo;
        }

        /// <summary>
        /// Creates a worker iif there's no worker with the specified login.
        /// The password is encrypted with SHA256
        /// </summary>
        /// <param name="login">The login of the worker we want to create</param>
        /// <param name="clearPwd">The password in clear text of the worker we want to creatre</param>
        /// <param name="donnees_perso">The personal data of the worker</param>
        public void CreerSalarie(string login, string clearPwd, string donnees_perso)
        {
            SALARIÉ salarie = _salarieRepo.FindWhere(s => s.LOGIN == login).FirstOrDefault();
            if (salarie != null)
            {
                throw new Exception("Il y a déjà un salarié avec ce login");
            }
            salarie = new SALARIÉ {
                LOGIN = login,
                MDP = SHA256.Create(clearPwd).ComputeHash(new UTF8Encoding().GetBytes(clearPwd)),
                DONNEES_PERSONNELLES=donnees_perso,
                estAdmin = false
            };

            _salarieRepo.Insert(salarie);
            _salarieRepo.Save();
        }

        /// <summary>
        /// Gets all the holidays of the worker with the specified login
        /// </summary>
        /// <param name="login">The login of the worker which we want their holidays</param>
        /// <returns>all the holidays of the worker with the specified login</returns>
        public IEnumerable<CONGÉ> RecupCongesPourSalarie(string login)
        {
            SALARIÉ salarie = _salarieRepo.FindWhere(s => s.LOGIN == login).FirstOrDefault();
            if(salarie == null)
            {
                throw new Exception("Il n'y a pas de salariés avec le login spécifié");
            }

            return _congeRepo.FindWhere(c => c.SALARIÉ.Contains(salarie));
        }

        /// <summary>
        /// Creates a holiday for the specified worker
        /// </summary>
        /// <param name="s">The worker</param>
        /// <param name="dateDebut">The starting date of the holiday</param>
        /// <param name="dateFin">The last date of the holiday</param>
        /// <param name="estRegulier">Tells if this holiday is regular (every year) or not</param>
        public void PositionnerConge(SALARIÉ s, DateTime dateDebut, DateTime dateFin, bool estRegulier = false)
        {
            CONGÉ conge = _congeRepo.FindWhere(c => c.DATEFIN == dateFin && c.DATEDEBUT == dateDebut).FirstOrDefault();
            if(conge == null)
            {
                conge = new CONGÉ
                {
                    SALARIÉ = new List<SALARIÉ>(),
                    DATEDEBUT = dateDebut,
                    ESTREGULIER = estRegulier,
                    DATEFIN = dateFin
                };
                conge.SALARIÉ.Add(s);
                _congeRepo.Insert(conge);
                _congeRepo.Save();
                return;
            }
            conge.SALARIÉ.Add(s);
            _congeRepo.Update(conge);
            _congeRepo.Save();
        }
    }
}
