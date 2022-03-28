﻿using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Controllers
{
    public class EmployesController
    {
        private IGenericRepository<SALARIÉ> _salarieRepo;
        private IGenericRepository<CONGÉ> _congeRepo;

        /// <summary>
        /// Constructor of the EmployesController object
        /// </summary>
        /// <param name="salarieRepo">The entity repository of the workers</param>
        /// <param name="congeRepo">The entity repository of the holidays</param>
        public EmployesController(IGenericRepository<SALARIÉ> salarieRepo, IGenericRepository<CONGÉ> congeRepo)
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
            var hash = SHA256.Create().ComputeHash(new UTF8Encoding().GetBytes(clearPwd));
            salarie = new SALARIÉ {
                LOGIN = login,
                MDP = hash,
                DONNEES_PERSONNELLES=donnees_perso,
                estAdmin = false
            };

            _salarieRepo.Insert(salarie);
            _salarieRepo.Save();
        }

        /// <summary>
        /// Allows to get the [<see cref="SALARIÉ"/>] object that has the corresponding credentials.
        /// Returns null if the credentials are not valid
        /// </summary>
        /// <param name="login">The worker's login</param>
        /// <param name="clearPwd">The worker's password in clear text</param>
        /// <returns></returns>
        public SALARIÉ Connexion(string login, string clearPwd)
        {
            byte[] hashedPwd = SHA256.Create().ComputeHash(new UTF8Encoding().GetBytes(clearPwd));
            SALARIÉ salarie = _salarieRepo.FindWhere(s => s.LOGIN == login && s.MDP.SequenceEqual(hashedPwd)).FirstOrDefault();
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
