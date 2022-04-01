using Microsoft.Extensions.DependencyInjection;
using PT4.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PT4
{
    public partial class MenuAcceuil : MenuHamberger
    {

        private RendezVousController _rendezVousController;

        public MenuAcceuil(RendezVousController rdvController, ServiceCollection services, int salarieId, bool estAdmin) : base(services, salarieId, estAdmin)
        {
            InitializeComponent();
            _rendezVousController = rdvController;
            _rendezVousController.SubscribeAppointments(OnChanged);
            _rendezVousController.UnSubscribeDeleteAppointments(OnChanged);

            this.Closed += (_, __) => { _rendezVousController.UnSubscribeAppointments(OnChanged); _rendezVousController.UnSubscribeDeleteAppointments(OnChanged); };

            InitializeBoldedDates();
        }

        private void InitializeBoldedDates()
        {
            IQueryable<RENDEZVOUS> appointmentsOfTheMonth = _rendezVousController.FindAll();
            foreach (RENDEZVOUS rdv in appointmentsOfTheMonth)
            {
                monthCalendar1.AddBoldedDate(rdv.DATEHEURERDV);
            }
        }

        private void OnChanged(IEnumerable<RENDEZVOUS> args)
        {
            monthCalendar1.RemoveAllBoldedDates();
            InitializeBoldedDates();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            _services.AddScoped((p) => new AfficherJournee(p.GetRequiredService<RendezVousController>(), e.Start));
            using (ServiceProvider provider = _services.BuildServiceProvider())
            {
                using (IServiceScope scope = provider.CreateScope())
                {
                    scope.ServiceProvider.GetService<AfficherJournee>().ShowDialog();
                }
            }
        }
    }
}
