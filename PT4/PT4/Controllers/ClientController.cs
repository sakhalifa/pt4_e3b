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

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public void CreerClient(string nom, string prenom, string numero, string email)
        {
            _clientRepository.Insert(new CLIENT
            {
                EMAIL = email,
                NUMERO = numero,
                PRENOMCLIENT = prenom,
                NOMCLIENT = nom
            });
        }
    }
}
