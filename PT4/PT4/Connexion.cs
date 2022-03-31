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
    public partial class Connexion : Form
    {

        private ServiceCollection _service;
        private SalarieController _salarieController;
        public Connexion(ServiceCollection service, SalarieController salarieController)
        {
            InitializeComponent();
            _service = service;
            _salarieController = salarieController;
        }

        private void Connexion_Load(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            if (CheckRemplissage())
            {
                SALARIÉ s = _salarieController.Connexion(textBoxLogin.Text, textBoxPassword.Text);
                if (s is null)
                {
                    Utils.ShowError("ERREUR! Mot de passe ou login incorrect!");
                }
                else
                {
                    MessageBox.Show($"Connecté avec succès en tant que {s.LOGIN}");
                    this.Hide();
                    _service.AddScoped((p) => new MenuAcceuil(p.GetRequiredService<RendezVousController>(), _service, s.IDCOMPTE, s.estAdmin));
                    using (ServiceProvider provider = _service.BuildServiceProvider())
                    {
                        using (IServiceScope scope = provider.CreateScope())
                        {
                            MenuAcceuil mh = scope.ServiceProvider.GetService<MenuAcceuil>();


                            mh.Closed += (send, __) =>
                            {
                                if (send is MenuHamberger a)
                                {
                                    if (a.DialogResult == DialogResult.Retry)
                                    {
                                        this.Show();
                                    }
                                    else
                                    {
                                        this.Close();
                                    }
                                }
                            };
                            mh.ShowDialog();
                        }
                    }


                }
            }
        }

        private bool CheckRemplissage()
        {
            if (textBoxLogin.TextLength == 0)
            {
                Utils.ShowError("ERREUR! Vous devez rentrer un login!");
                return false;
            }
            if (textBoxPassword.TextLength == 0)
            {
                Utils.ShowError("ERREUR! Vous devez rentrer un mot de passe!");
                return false;
            }

            return true;
        }
    }
}
