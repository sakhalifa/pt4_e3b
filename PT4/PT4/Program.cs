using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PT4.Model.dal;
using PT4.Model.impl;
using System.Data.Entity;

namespace PT4
{
    static class Program
    {
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>()
                    .AddSingleton<IAnimalRepository, AnimalRepository>()
                    .AddSingleton<IClientRepository, ClientRepository>()
                    .AddSingleton<ICongeRepository, CongeRepository>()
                    .AddSingleton<IFactureRepository, FactureRepository>()
                    .AddSingleton<IMaladieRepository, MaladieRepository>()
                    .AddSingleton<IOrdonnanceRepository, OrdonnanceRepository>()
                    .AddSingleton<IProduitRepository, ProduitRepository>()
                    .AddSingleton<IRendezVousRepository, RendezVousRepository>()
                    .AddSingleton<ISalarieRepository, SalarieRepository>();
            services.AddSingleton(services);
        }

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
    }
}
