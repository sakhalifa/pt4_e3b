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
        /// <summary>
        /// Instance of SalarieController
        /// </summary>
        private SalarieController _salarieController;
        /// <summary>
        /// Instance of ServiceCollection
        /// </summary>
        private ServiceCollection _services;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="salarieController">Instance of SalarieController</param>
        /// <param name="services"> Instance of ServiceCollection</param>
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

        /// <summary>
        /// Function which is called whenever there is a salary which is deleted 
        /// </summary>
        /// <param name="args">All the salary deleted</param>
        private void OnDelete(IEnumerable<SALARIÉ> args)
        {
            foreach (SALARIÉ s in args)
            {
                allSalarie.Items.Remove(s);
            }
        }

        /// <summary>
        /// Function which is called whenever there is a salary updated or added
        /// </summary>
        /// <param name="args">All the salary which has been added or updated</param>
        private void OnChanged(IEnumerable<SALARIÉ> args)
        {
            foreach (SALARIÉ s in args.Where(s => !s.estAdmin))
            {
                allSalarie.Items.Remove(s);
                allSalarie.Items.Add(s);
            }
        }

        /// <summary>
        /// Function which shows the page to create a new acount for a new salary
        /// </summary>
        /// <param name="sender"> object </param>
        /// <param name="e"> EventArgs</param>
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

        /// <summary>
        /// Function which deletes the salary
        /// </summary>
        /// <param name="sender"> object </param>
        /// <param name="e">EventArgs</param>
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

        /// <summary>
        /// Function which shows the page to change password
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
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
