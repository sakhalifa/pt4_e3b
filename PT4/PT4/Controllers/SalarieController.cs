using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PT4.Controllers
{
    public class SalarieController
    {
        private IGenericRepository<SALARIÉ> _salarieRepo;
        private IGenericRepository<CONGÉ> _congeRepo;



        /// <summary>
        /// Constructor of the EmployesController object
        /// </summary>
        /// <param name="salarieRepo">The entity repository of the workers</param>
        /// <param name="congeRepo">The entity repository of the holidays</param>
        public SalarieController(IGenericRepository<SALARIÉ> salarieRepo, IGenericRepository<CONGÉ> congeRepo)
        {
            _salarieRepo = salarieRepo;
            _congeRepo = congeRepo;
        }

        public SALARIÉ GetSalarieFromId(int id)
        {
            return _salarieRepo.FindById(id);
        }

        public IQueryable<SALARIÉ> FindAllNotAdmin()
        {
            return _salarieRepo.FindWhere((s) => !s.estAdmin);
        }

        /// <summary>
        /// Creates a worker iif there's no worker with the specified login.
        /// The password is encrypted with SHA256
        /// </summary>
        /// <param name="login">The login of the worker we want to create</param>
        /// <param name="clearPwd">The password in clear text of the worker we want to creatre</param>
        /// <param name="donnees_perso">The personal data of the worker</param>
        public SALARIÉ CreerSalarie(string login, string clearPwd)
        {
            SALARIÉ salarie = _salarieRepo.FindWhere(s => s.LOGIN == login).FirstOrDefault();
            if (salarie != null)
            {
                throw new ArgumentException("Il y a déjà un salarié avec ce login");
            }
            var hash = SHA256.Create().ComputeHash(new UTF8Encoding().GetBytes(clearPwd));
            salarie = new SALARIÉ
            {
                LOGIN = login,
                MDP = Utils.Hash(clearPwd),
                estAdmin = false
            };

            _salarieRepo.Insert(salarie);
            _salarieRepo.Save();
            return salarie;
        }

        public void ChangerMotDePasse(SALARIÉ s, string clearPwd)
        {
            var hashed = Utils.Hash(clearPwd);
            if (s.MDP.SequenceEqual(hashed))
            {
                throw new ArgumentException("ERREUR! Vous ne pouvez pas avoir le même mot de passe que celui que vous avez actuellement!");
            }
            s.MDP = Utils.Hash(clearPwd);
            _salarieRepo.Update(s);
            _salarieRepo.Save();
        }

        public void Delete(SALARIÉ s)
        {
            _salarieRepo.Delete(s);
            _salarieRepo.Save();
        }

        public void DeleteBulk(IEnumerable<SALARIÉ> salaries)
        {
            foreach (SALARIÉ s in salaries)
            {
                _salarieRepo.Delete(s);
            }
            _salarieRepo.Save();
        }

        public void DonneesPersoSalarie(SALARIÉ s, string donnees_perso)
        {
            s.DONNEES_PERSONNELLES = donnees_perso;
            _salarieRepo.Update(s);
            _salarieRepo.Save();
        }

        /// <summary>
        /// Allows to get the [<see cref="SALARIÉ"/>] object that has the corresponding credentials.
        /// Returns null if the credentials are not valid
        /// </summary>
        /// <param name="login">The worker's login</param>
        /// <param name="clearPwd">The worker's password in clear text</param>
        /// <returns></returns>
        public virtual SALARIÉ Connexion(string login, string clearPwd)
        {
            byte[] hashedPwd = SHA256.Create().ComputeHash(new UTF8Encoding().GetBytes(clearPwd));
            SALARIÉ salarie = _salarieRepo.FindWhere(s => s.LOGIN == login && s.MDP == hashedPwd).FirstOrDefault();
            return salarie;
        }

        /// <summary>
        /// Gets all the holidays of the worker with the specified login
        /// </summary>
        /// <param name="login">The login of the worker which we want their holidays</param>
        /// <returns>all the holidays of the worker with the specified login</returns>
        public IEnumerable<CONGÉ> RecupCongesPourSalarie(string login)
        {
            SALARIÉ salarie = _salarieRepo.FindWhere(s => s.LOGIN == login).FirstOrDefault();
            if (salarie == null)
            {
                throw new ArgumentException("Il n'y a pas de salariés avec le login spécifié");
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
        public void PositionnerConge(int salarieId, DateTime dateDebut, DateTime dateFin, bool ignoreEstRegulier, bool estRegulier = false)
        {
            SALARIÉ s = _salarieRepo.FindById(salarieId);
            if (s == null)
            {
                throw new ArgumentException("ERREUR CRITIQUE! Salarié introuvable !");
            }
            CONGÉ conge = _congeRepo.FindWhere(c => c.DATEFIN == dateFin && c.DATEDEBUT == dateDebut).FirstOrDefault();
            if (conge == null)
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


            if (conge.SALARIÉ.Contains(s))
            {
                throw new ArgumentException("Erreur ! Ce congé existe déjà");
            }

            if (conge.ESTREGULIER != estRegulier && !ignoreEstRegulier)
            {
                DataMisalignedException ex = new DataMisalignedException();
                ex.Data.Add("canModify", s.estAdmin);
                throw ex;
            }


            conge.SALARIÉ.Add(s);
            conge.ESTREGULIER = estRegulier;
            _congeRepo.Update(conge);
            _congeRepo.Save();
        }

        public void SubscribeEmployee(OnChanged<SALARIÉ> onChanged)
        {
            _salarieRepo.Subscribe(onChanged);
        }

        public void SubscribeDeleteEmployee(OnDelete<SALARIÉ> onDelete)
        {
            _salarieRepo.SubscribeDelete(onDelete);
        }

        public void UnSubscribeEmployee(OnChanged<SALARIÉ> onChanged)
        {
            _salarieRepo.UnSubscribe(onChanged);
        }

        public void UnSubscribeDeleteEmployee(OnDelete<SALARIÉ> onDelete)
        {
            _salarieRepo.UnSubscribeDelete(onDelete);
        }
    }
}
