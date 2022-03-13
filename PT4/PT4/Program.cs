using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PT4.Model.dal;
using PT4.Model.impl;
using System.Data.Entity;
using PT4.Controllers;

namespace PT4
{
    static class Program
    {
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>()
                    .AddSingleton<IGenericRepository<ANIMAL>, AnimalRepository>()
                    .AddSingleton<IGenericRepository<CLIENT>, ClientRepository>()
                    .AddSingleton<IGenericRepository<CONGÉ>, CongeRepository>()
                    .AddSingleton<IGenericRepository<FACTURE>, FactureRepository>()
                    .AddSingleton<IGenericRepository<MALADIE>, MaladieRepository>()
                    .AddSingleton<IGenericRepository<ORDONNANCE>, OrdonnanceRepository>()
                    .AddSingleton<IGenericRepository<PRODUIT>, ProduitRepository>()
                    .AddSingleton<IGenericRepository<RENDEZVOUS>, RendezVousRepository>()
                    .AddSingleton<IGenericRepository<SALARIÉ>, SalarieRepository>()
                    .AddSingleton<AnimalController>()
                    .AddSingleton<ClientController>()
                    .AddSingleton<EmployesController>()
                    .AddSingleton<FactureController>()
                    .AddSingleton<MaladieRepository>()
                    .AddSingleton<OrdonnanceRepository>()
                    .AddSingleton<ProduitController>()
                    .AddSingleton<SoinController>()
            ;
            services.AddSingleton(services);
        }

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            services.AddScoped<MenuHamberger>();
            using (ServiceProvider provider = services.BuildServiceProvider())
            {
                MenuHamberger form = provider.GetRequiredService<MenuHamberger>();
                Application.Run(form);
            }
            
        }
    }
}
