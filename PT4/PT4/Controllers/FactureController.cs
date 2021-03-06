using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PT4.Controllers
{
    public class FactureController
    {
        private HashSet<PRODUIT_VENDU> produitsVenduToInsert;
        private HashSet<PRODUIT> produitsToUpdate;

        private IGenericRepository<FACTURE> _factureRepository;
        private IGenericRepository<PRODUIT_VENDU> _produitVendusRepository;
        private IGenericRepository<PRODUIT> _produitRepository;

        public FactureController(IGenericRepository<FACTURE> factureRepository, IGenericRepository<PRODUIT_VENDU> produitVendusRepository, IGenericRepository<PRODUIT> produitRepo)
        {
            _factureRepository = factureRepository;
            _produitVendusRepository = produitVendusRepository;
            _produitRepository = produitRepo;
            this.Reset();
        }

        public void Reset()
        {
            if (produitsVenduToInsert != null)
            {
                foreach (var p in produitsVenduToInsert)
                {
                    p.PRODUIT.QUANTITEENSTOCK += p.QUANTITÉ;
                }
            }
            produitsVenduToInsert = new HashSet<PRODUIT_VENDU>();
            produitsToUpdate = new HashSet<PRODUIT>();
        }

        public void UpdateMontant(FACTURE f)
        {
            decimal sum = 0;
            foreach (PRODUIT_VENDU p in produitsVenduToInsert)
            {
                sum += p.Montant;
            }

            f.MONTANT = sum;
        }

        public FACTURE CreerFacture(CLIENT client)
        {
            FACTURE f = new FACTURE
            {
                CLIENT = client
            };

            return f;
        }

        public FACTURE AddProductToReceipt(FACTURE f, PRODUIT p, short quantite)
        {
            if (p.QUANTITEENSTOCK < quantite)
            {
                throw new ArgumentException($"ERREUR! Vous voulez vendre {quantite} de '{p.NOMPRODUIT}' alors qu'il n'y en a que {p.QUANTITEENSTOCK} en stock!");
            }
            if (!p.PRIXDEVENTE.HasValue)
            {
                throw new ArgumentException($"ERREUR! Le produit '{p.NOMPRODUIT}' n'est pas vendable!");
            }
            PRODUIT_VENDU pv = f.PRODUIT_VENDU.FirstOrDefault((tpv) => tpv.PRODUIT == p);
            if (pv is null)
            {
                pv = new PRODUIT_VENDU
                {
                    PRODUIT = p,
                    FACTURE = f,
                    QUANTITÉ = quantite
                };

                f.PRODUIT_VENDU.Add(pv);
                produitsVenduToInsert.Add(pv);
            }
            else
            {
                pv.QUANTITÉ += quantite;

            }
            p.QUANTITEENSTOCK -= quantite;
            produitsToUpdate.Add(p);
            return f;
        }

        public FACTURE RemoveProductFromReceipt(FACTURE f, PRODUIT p, short quantite)
        {
            //We can do that because we will always have the same references because all of the receipt and the sold products are
            //pushed to the database at the last moment, so no proxies magic yay
            PRODUIT_VENDU pv = f.PRODUIT_VENDU.FirstOrDefault((tpv) => tpv.PRODUIT == p);
            if (pv is null)
            {
                throw new ArgumentException("ERREUR! Le produit n'est pas vendu dans cette facture!");
            }
            else
            {
                if (quantite > pv.QUANTITÉ)
                {
                    throw new ArgumentException($"ERREUR! Vous ne pouvez pas retirer plus de {quantite} '{p.NOMPRODUIT}' sur cette facture!");
                }
                else if (quantite == pv.QUANTITÉ)
                {
                    f.PRODUIT_VENDU.Remove(pv);
                    produitsVenduToInsert.Remove(pv);

                    p.QUANTITEENSTOCK += quantite;
                    produitsToUpdate.Remove(p);
                }
                else
                {
                    //No need to remark it for update etc because the save will be done at the end so it will only use the latest data
                    pv.QUANTITÉ -= quantite;
                    p.QUANTITEENSTOCK += quantite;
                }
            }

            return f;
        }

        public void SaveReceipt(FACTURE f)
        {
            f.DATEFACTURE = DateTime.Now;
            _factureRepository.Insert(f);
            foreach (PRODUIT_VENDU p in produitsVenduToInsert)
            {
                _produitVendusRepository.Insert(p);
            }
            foreach (PRODUIT p in produitsToUpdate)
            {
                _produitRepository.Update(p);
            }
            _factureRepository.Save();
            produitsVenduToInsert = new HashSet<PRODUIT_VENDU>();
            produitsToUpdate = new HashSet<PRODUIT>();
        }
    }
}
