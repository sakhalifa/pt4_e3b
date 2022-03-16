using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PT4;
using PT4.Model.dal;
using PT4.Controllers;
using System.Linq;
using System;
using PT4.Model.impl;
using System.Data.Entity;

namespace TestProjetVeto
{
    [TestClass]
    class TestRDV
    {
        private IGenericRepository<RENDEZVOUS> _rdvRepo;
        private ClientController _clientController;
        public CLIENT clientTest;
        public RENDEZVOUS rdvTest;

        [TestInitialize]
        public void TestInitialize()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<DbContext, PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>()
                    .AddSingleton<IGenericRepository<RENDEZVOUS>, RendezVousRepository>()
                    .AddSingleton<ClientController>()
            ;
            services.AddSingleton(services);

            using (ServiceProvider provider = services.BuildServiceProvider())
            {
                _rdvRepo = provider.GetRequiredService<IGenericRepository<RENDEZVOUS>>();
                _clientController = provider.GetRequiredService<ClientController>();
            }

            clientTest = new CLIENT
            {
                NOMCLIENT = "Test",
                PRENOMCLIENT = "Test",
                NUMERO = "Test",
                EMAIL = "Test"
            };

            rdvTest = new RENDEZVOUS
            {
                CLIENT = clientTest,
                DATEHEURERDV = new DateTime(2050, 3, 10, 10, 0, 0),
                RAISON = "Mon chat ne veut plus manger",
                HEUREFINRDV = new DateTime(2050, 3, 10, 10, 30, 0)
            };
        }

        [TestMethod]
        public void TestCreerRDV()
        {
            var req1 = _rdvRepo.FindWhere((rdv) => rdv.HEUREFINRDV == rdvTest.HEUREFINRDV);

            Assert.AreEqual(req1.Count(), 0); // Test si aucun rdv dans la base de ce type existe déjà

            _clientController.CreerRendezVous(clientTest, rdvTest.DATEHEURERDV, rdvTest.RAISON, rdvTest.HEUREFINRDV);
            var req2 = _rdvRepo.FindWhere((rdv) => rdv.HEUREFINRDV == rdvTest.HEUREFINRDV);

            Assert.AreEqual(req2.Count(), 1); // Test l'insertion d'un rendez vous dans la base

            foreach (RENDEZVOUS rdv in req2)
            {
                _rdvRepo.Delete(rdv);
            }
            _rdvRepo.Save();
        }
    }
}
