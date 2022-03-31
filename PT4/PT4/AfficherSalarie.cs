using Microsoft.Extensions.DependencyInjection;
using PT4.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT4
{
    public partial class AfficherSalarie : Form
    {
        private SalarieController _salarieController;
        private ServiceCollection _services;

        public AfficherSalarie(SalarieController salarieController, ServiceCollection services)
        {
            InitializeComponent();
            _salarieController = salarieController;
            _services = services;

            _salarieController.SubscribeEmployee(OnChanged);
            _salarieController.SubscribeDeleteEmployee(OnDelete);

            this.Closed += (_, __) => { _salarieController.UnSubscribeEmployee(OnChanged); _salarieController.UnSubscribeDeleteEmployee(OnDelete); };

            foreach(SALARIÉ s in _salarieController.FindAll())
            {
                allSalarie.Items.Add(s);
            }
        }

        private void OnDelete(IEnumerable<SALARIÉ> args)
        {
            foreach(SALARIÉ s in args)
            {
                allSalarie.Items.Remove(s);
            }
        }

        private void OnChanged(IEnumerable<SALARIÉ> args)
        {
            foreach(SALARIÉ s in args)
            {
                allSalarie.Items.Remove(s);
                allSalarie.Items.Add(s);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _services.AddScoped<AjouterCompte>();
            using (ServiceProvider provider = _services.BuildServiceProvider())
            {
                using (IServiceScope serviceScope = provider.CreateScope())
                {
                    var form = serviceScope.ServiceProvider.GetService<AjouterCompte>();
                    Application.Run(form);
                }
            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(allSalarie.SelectedItem != null)
            {
                if(MessageBox.Show("Voulez-vous vraiment supprimer ce salarié?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    SALARIÉ s = (SALARIÉ)allSalarie.SelectedItem;
                    _salarieController.Delete(s);
                    MessageBox.Show($"Vous avez bien supprimé le salarié {s.LOGIN}");
                }
            }
        }
    }
}
