using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Controllers
{
    internal class MaladiesController
    {
        private IMaladieRepository _maladieRepo;

        public MaladiesController(IMaladieRepository maladieRepo)
        {
            _maladieRepo = maladieRepo;
        }


        public void CreerMaladie(string nomMaladie)
        {
            MALADIE maladie = _maladieRepo.FindWhere(m => m.NOMMALADIE == nomMaladie).FirstOrDefault();
            if (maladie != null)
            {
                throw new Exception("Une maladie porte déjà ce nom");
            }
            maladie = new MALADIE
            {
                NOMMALADIE = nomMaladie
            };

            _maladieRepo.Insert(maladie);
            _maladieRepo.Save();
        }

        public IEnumerable<MALADIE> ListerMaladies()
        {
            return _maladieRepo.FindAll();
        }
    }
}
