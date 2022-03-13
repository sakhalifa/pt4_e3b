using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Controllers
{
    public class ProduitController
    {
        private IGenericRepository<PRODUIT> _produitRepository;

        public ProduitController(IGenericRepository<PRODUIT> produitRepository)
        {
            _produitRepository = produitRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prix"></param>
        /// <param name="quantite"></param>
        /// <param name="description"></param>
        /// <param name="estMedicament"></param>
        /// <param name="add">true iif we want to add the quantities. Else false</param>
        public void CreerOuMaJProduit(string nom, decimal prixVente, decimal prixAchat, int quantite, string description, bool estMedicament, bool add)
        {
            PRODUIT prod = _produitRepository.FindWhere(p => p.NOMPRODUIT == nom).FirstOrDefault();
            if(prod == null)
            {
                prod = new PRODUIT()
                {
                    NOMPRODUIT = nom,
                    PRIXACHAT = prixAchat,
                    DESCRIPTION = description,
                    MEDICAMENT = estMedicament,
                    PRIXDEVENTE = prixVente,
                    QUANTITEENSTOCK = (short)quantite
                };
                _produitRepository.Insert(prod);
            }
            else
            {
                if (add)
                {
                    quantite += prod.QUANTITEENSTOCK;
                }

                prod.PRIXACHAT = prixAchat;
                prod.DESCRIPTION = description;
                prod.MEDICAMENT = estMedicament;
                prod.PRIXDEVENTE = prixVente;
                prod.QUANTITEENSTOCK = (short)(quantite);
                
                _produitRepository.Update(prod);
            }
            _produitRepository.Save();
        }
    }
}
