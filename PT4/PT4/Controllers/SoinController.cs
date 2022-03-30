using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Controllers
{
    public class SoinController
    {
        private IGenericRepository<SOIN> _soinRepository;

        public SoinController(IGenericRepository<SOIN> soinRepo)
        {
            _soinRepository = soinRepo;
        }





        public void CreerSoin(string description)
        {
            _soinRepository.Insert(new SOIN
            {
                DESCRIPTION = description
            });
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








    }
}
