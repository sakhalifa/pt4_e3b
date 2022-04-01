using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void DeleteBulk(IEnumerable<RENDEZVOUS> toDelete)
        {
            foreach (RENDEZVOUS r in toDelete)
            {
                _rdvRepo.Delete(r);

            }
            _rdvRepo.Save();
        }

        internal IEnumerable<RENDEZVOUS> FindForDay(DateTime datePicked)
        {
            return _rdvRepo.FindWhere((r) => r.DATEHEURERDV.Day == datePicked.Day);
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
