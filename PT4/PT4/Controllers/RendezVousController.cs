using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Controllers
{
    public class RendezVousController
    {
        private IGenericRepository<RENDEZVOUS> _rdvRepo;

        public RendezVousController(IGenericRepository<RENDEZVOUS> rdvRepo)
        {
            _rdvRepo = rdvRepo;
        }

        public IQueryable<RENDEZVOUS> FindAll()
        {
            return _rdvRepo.FindAll();
        }

        public void SubscribeAppointments(OnChanged<RENDEZVOUS> onChanged)
        {
            _rdvRepo.Subscribe(onChanged);
        }

        public void SubscribeDeleteAppointments(OnDelete<RENDEZVOUS> onDelete)
        {
            _rdvRepo.SubscribeDelete(onDelete);
        }

        public void UnSubscribeAppointments(OnChanged<RENDEZVOUS> onChanged)
        {
            _rdvRepo.UnSubscribe(onChanged);
        }

        public void UnSubscribeDeleteAppointments(OnDelete<RENDEZVOUS> onDelete)
        {
            _rdvRepo.UnSubscribeDelete(onDelete);
        }
    }
}
