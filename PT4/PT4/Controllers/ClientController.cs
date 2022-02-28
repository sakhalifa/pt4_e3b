using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT4.Model.dal;

namespace PT4.Controllers
{
    internal class ClientController
    {
        private IClientRepository _clientRepository;
        private IRendezVousRepository _rendezVousRepository;

        /// <summary>
        /// Constructor of the ClientController object
        /// </summary>
        /// <param name="clientRepository">The entity repository of the customers</param>
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        /// <summary>
        /// Creates a customer
        /// </summary>
        /// <param name="nom">Their last name</param>
        /// <param name="prenom">Their first name</param>
        /// <param name="numero">Their phone number (can be null)</param>
        /// <param name="email">Their email (can't be null)</param>
        public void CreerClient(string nom, string prenom, string numero, string email)
        {
            CLIENT client = _clientRepository.FindWhere(c => c.EMAIL == email).FirstOrDefault();
            if (client != null)
            {
                throw new Exception("Cette adresse mail est déjà utilisée");

            }
            _clientRepository.Insert(new CLIENT
            {
                EMAIL = email,
                NUMERO = numero,
                PRENOMCLIENT = prenom,
                NOMCLIENT = nom
            });
        }



        public void CreerRendezVous( CLIENT client, DateTime dateRdv, string raison)
        {

          /*  RENDEZVOUS rdv = _rendezVousRepository.FindWhere(rdv => rdv.DATEHEURERDV.Day == dateRdv.Day)*/
            _rendezVousRepository.Insert(new RENDEZVOUS {
                CLIENT = client,
                DATEHEURERDV = dateRdv,
                RAISON = raison
            });
        }

        



    }
}
