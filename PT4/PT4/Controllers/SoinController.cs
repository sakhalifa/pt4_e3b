using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4.Controllers
{
    public class SoinController
    {
        private IGenericRepository<SOIN> _soinRepository;

        public SoinController(IGenericRepository<SOIN> soinRepo)
        {
            _soinRepository = soinRepo;
        }

        private IEnumerable<SOIN> GetIntersectedCare(IEnumerable<MALADIE> diseases, IEnumerable<PRODUIT> products)
        {
            //Forced to do this sloow method because _soinRepository.FindWhere((ss) => ss.PRODUIT == products && ss.MALADIE == diseases); doesn't work :(
            IEnumerable<SOIN> intersectedCare = null;
            foreach (PRODUIT p in products)
            {
                if (intersectedCare is null)
                {
                    intersectedCare = p.SOIN;
                }
                else
                {
                    intersectedCare = intersectedCare.Intersect(p.SOIN);
                }
            }
            foreach (MALADIE m in diseases)
            {
                intersectedCare = intersectedCare.Intersect(m.SOIN);
            }

            return intersectedCare;
        }

        public void CreateCare(IEnumerable<MALADIE> diseases, IEnumerable<PRODUIT> products, string description)
        {
            var intersectedCare = GetIntersectedCare(diseases, products);

            //Have to check if there's a care that has EXACTLY the diseases AND the products in it. Else, it will trigger
            //Event if we have less diseases/products but all of them are in the care.
            //Basically, it's a strict equality instead of a "check include"
            if (intersectedCare.Count() > 0 && intersectedCare.Any((s) => s.MALADIE.SequenceEqual(diseases) && s.PRODUIT.SequenceEqual(products)))
            {
                throw new ArgumentException("ERREUR! Vous ne pouvez pas avoir 2x exactement le même soin avec les même produits et les même maladies impliqués");
            }


            SOIN newCare = new SOIN
            {
                DESCRIPTION = description,
                MALADIE = diseases.ToList(),
                PRODUIT = products.ToList()
            };
            _soinRepository.Insert(newCare);

            _soinRepository.Save();
        }

        /// <summary>
        /// Find all cares in the database
        /// </summary>
        public IQueryable<SOIN> FindAll()
        {
            return _soinRepository.FindAll();
        }

        public void SubscribeSoins(OnChanged<SOIN> onChanged)
        {
            _soinRepository.Subscribe(onChanged);
        }

        public void UnSubscribeSoins(OnChanged<SOIN> onChanged)
        {
            _soinRepository.UnSubscribe(onChanged);
        }

        public void SubscribeDeleteSoins(OnDelete<SOIN> onDelete)
        {
            _soinRepository.SubscribeDelete(onDelete);
        }

        public void UnSubscribeDeleteSoins(OnDelete<SOIN> onDelete)
        {
            _soinRepository.UnSubscribeDelete(onDelete);
        }

        internal void RemoveCare(SOIN s)
        {
            if (s.ORDONNANCE.Count > 0)
            {
                StringBuilder sb = new StringBuilder("ERREUR! Ce soin est contenu dans une ou plusieurs ordonnances." +
                    " Veuillez les supprimer de ces ordonnances avant de supprimer le soin :\n");
                foreach (ORDONNANCE o in s.ORDONNANCE)
                {
                    sb.Append("- ").Append(o.ToString()).Append("\n");
                }
                sb.RemoveLastCharacter();
                throw new ArgumentException(sb.ToString());
            }
            _soinRepository.Delete(s);
            _soinRepository.Save();
        }

        internal void EditCare(SOIN soin, ICollection<MALADIE> diseases, ICollection<PRODUIT> products, string desc)
        {
            var intersectedCare = GetIntersectedCare(diseases, products);
            if (intersectedCare.Count() > 0 && intersectedCare.Any((s) => (s != soin || s.ID != soin.ID) && s.MALADIE.SequenceEqual(diseases) && s.PRODUIT.SequenceEqual(products)))
            {
                throw new ArgumentException("ERREUR! Vous ne pouvez pas avoir 2x exactement le même soin avec les même produits et les même maladies impliqués");
            }

            soin.MALADIE = diseases;
            soin.PRODUIT = products;
            soin.DESCRIPTION = desc;

            _soinRepository.Update(soin);
            _soinRepository.Save();
        }
    }
}
