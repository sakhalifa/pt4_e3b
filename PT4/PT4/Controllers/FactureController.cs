using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Controllers
{
    class FactureController
    {
        private IFactureRepository _factureRepository;

        public FactureController(IFactureRepository factureRepository)
        {
            _factureRepository = factureRepository;
        }

        public void CreerFacture(ICollection<PRODUIT_VENDU> produitsConcernes, CLIENT client, int montant)
        {
            FACTURE f = new FACTURE
            {
                CLIENT = client,
                PRODUIT_VENDU = produitsConcernes,
                DATEFACTURE = new DateTime(),
                MONTANT = montant
            };
        }
    }
}
