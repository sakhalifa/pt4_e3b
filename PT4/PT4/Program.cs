using Microsoft.Extensions.DependencyInjection;
using PT4.Controllers;
using PT4.Model.dal;
using PT4.Model.impl;
using System;
using System.Windows.Forms;

namespace PT4
{
    static class Program
    {
        private static void ConfigureServices(ServiceCollection services)
        {
            /*
             * HAHAHAHAHAHAHAHA I HAVE TO DO THIS OTHERWISE ADDSINGLETON WON'T CREATE SINGLETONS???????
             * THIS IS 100% STUPID.
             * https://www.thinktecture.com/en/asp-net/aspnet-core-beware-singleton-may-not-be-singleton/
             */
            PT4_PLANNIMAUX_S4p2B_JKVBLBEntities dbContext = new PT4_PLANNIMAUX_S4p2B_JKVBLBEntities();
            var animalRepo = new AnimalRepository(dbContext);
            var clientRepo = new ClientRepository(dbContext);
            var congeRepo = new CongeRepository(dbContext);
            var factureRepo = new FactureRepository(dbContext);
            var maladieRepo = new MaladieRepository(dbContext);
            var ordonnanceRepo = new OrdonnanceRepository(dbContext);
            var produitRepo = new ProduitRepository(dbContext);
            var produitVenduRepo = new ProduitVenduRepository(dbContext);
            var rdvRepo = new RendezVousRepository(dbContext);
            var salarieRepo = new SalarieRepository(dbContext);
            var histoMaladieRepo = new HistoriqueMaladieRepository(dbContext);
            var careRepo = new SoinRepository(dbContext);

            services.AddSingleton<IGenericRepository<ANIMAL>>(animalRepo)
                    .AddSingleton<IGenericRepository<CLIENT>>(clientRepo)
                    .AddSingleton<IGenericRepository<CONGÉ>>(congeRepo)
                    .AddSingleton<IGenericRepository<FACTURE>>(factureRepo)
                    .AddSingleton<IGenericRepository<MALADIE>>(maladieRepo)
                    .AddSingleton<IGenericRepository<ORDONNANCE>>(ordonnanceRepo)
                    .AddSingleton<IGenericRepository<PRODUIT>>(produitRepo)
                    .AddSingleton<IGenericRepository<PRODUIT_VENDU>>(produitVenduRepo)
                    .AddSingleton<IGenericRepository<RENDEZVOUS>>(rdvRepo)
                    .AddSingleton<IGenericRepository<SALARIÉ>>(salarieRepo)
                    .AddSingleton<IGenericRepository<SOIN>>(careRepo)
                    .AddSingleton<IGenericRepository<HISTORIQUEMALADIE>>(histoMaladieRepo)
                    .AddTransient<AnimalController>()
                    .AddTransient<ClientController>()
                    .AddTransient<SalarieController>()
                    .AddTransient<FactureController>()
                    .AddTransient<MaladiesController>()
                    .AddTransient<OrdonnanceController>()
                    .AddTransient<ProduitController>()
                    .AddTransient<SoinController>()
                    .AddTransient<RendezVousController>()
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
            services.AddScoped<Connexion>();
            using (ServiceProvider provider = services.BuildServiceProvider())
            {
                using (IServiceScope serviceScope = provider.CreateScope())
                {
                    var form = serviceScope.ServiceProvider.GetService<Connexion>();
                    Application.Run(form);
                }
            }
        }
    }
}
