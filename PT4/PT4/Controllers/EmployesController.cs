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

        public EmployesController(ISalarieRepository salarieRepo, ICongeRepository congeRepo)
        {
            _salarieRepo = salarieRepo;
            _congeRepo = congeRepo;
        }

        public void creerSalarie(string login, string clearPwd, string donnees_perso)
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

        
        public IEnumerable<CONGÉ> recupCongesPourSalarie(string login)
        {
            SALARIÉ salarie = _salarieRepo.FindWhere(s => s.LOGIN == login).FirstOrDefault();
            if(salarie == null)
            {
                throw new Exception("Il n'y a pas de salariés avec le login spécifié");
            }

            return _congeRepo.FindWhere(c => c.SALARIÉ.Contains(salarie));
        }



        public void positionnerConge(SALARIÉ s, DateTime dateDebut, DateTime dateFin, bool estRegulier = false)
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
