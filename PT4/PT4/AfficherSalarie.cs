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

            foreach (SALARIÉ s in _salarieController.FindAllNotAdmin())
            {
                allSalarie.Items.Add(s);
            }
        }

        private void OnDelete(IEnumerable<SALARIÉ> args)
        {
            foreach (SALARIÉ s in args)
            {
                allSalarie.Items.Remove(s);
            }
        }

        private void OnChanged(IEnumerable<SALARIÉ> args)
        {
            foreach (SALARIÉ s in args.Where(s => !s.estAdmin))
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
                    form.ShowDialog();
                }
            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allSalarie.SelectedItem != null)
            {
                if (MessageBox.Show("Voulez-vous vraiment supprimer ce(s) salarié(s)?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var castedSalarie = allSalarie.SelectedItems.Cast<SALARIÉ>();
                    StringBuilder sb = new StringBuilder("Vous avez bien supprimé le(s) salarié(s) ");
                    foreach (SALARIÉ s in castedSalarie)
                    {
                        sb.Append($"'{s.LOGIN}' ");
                    }
                    sb.RemoveLastCharacter();
                    _salarieController.DeleteBulk(castedSalarie);
                    
                    MessageBox.Show(sb.ToString());
                }
            }
        }

        private void modifierLeMdpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allSalarie.SelectedItems.Count == 1)
            {
                SALARIÉ s = (SALARIÉ)allSalarie.SelectedItems[0];
                _services.AddScoped((p) => new ModifierMdp(p.GetRequiredService<SalarieController>(), s.IDCOMPTE));
                using (ServiceProvider provider = _services.BuildServiceProvider())
                {
                    using (IServiceScope serviceScope = provider.CreateScope())
                    {
                        var form = serviceScope.ServiceProvider.GetService<ModifierMdp>();
                        form.ShowDialog();
                    }
                }
            }
            else
            {
                Utils.ShowError("ERREUR! Veuillez choisir 1 et 1 seul salarié !");
            }
        }
    }
}
