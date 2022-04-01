using Microsoft.Extensions.DependencyInjection;
using PT4.Controllers;
using System;
using System.Windows.Forms;

namespace PT4
{
    public partial class Connexion : Form
    {
        /// <summary>
        /// Instance of ServiceCollection
        /// </summary>
        private ServiceCollection _service;

        /// <summary>
        /// Instance of SalarieController
        /// </summary>
        private SalarieController _salarieController;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Instance of ServiceCollection</param>
        /// <param name="salarieController">Instance of SalarieController</param>
        public Connexion(ServiceCollection service, SalarieController salarieController)
        {
            InitializeComponent();
            _service = service;
            _salarieController = salarieController;
        }

        /// <summary>
        /// If all constraints are validated, it connects you to the application
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
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

        /// <summary>
        /// If all the constraints are validated, it returns true
        /// </summary>
        /// <returns>returns true if all the constraints are validated</returns>
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
