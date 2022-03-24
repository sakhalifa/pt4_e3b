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
    public class TestClient
    {
        private IGenericRepository<RENDEZVOUS> _rdvRepo;
        private IGenericRepository<CLIENT> _clientRepo;
        private ClientController _clientController;
        public CLIENT clientTest;
        public RENDEZVOUS rdvTest;

        [TestInitialize]
        public void TestInitialize()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<DbContext, PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>()
                    .AddSingleton<IGenericRepository<CLIENT>, ClientRepository>()
                    .AddSingleton<IGenericRepository<RENDEZVOUS>, RendezVousRepository>()
                    .AddSingleton<ClientController>()
            ;
            services.AddSingleton(services);

            using (ServiceProvider provider = services.BuildServiceProvider())
            {
                _rdvRepo = provider.GetRequiredService<IGenericRepository<RENDEZVOUS>>();
                _clientRepo = provider.GetRequiredService<IGenericRepository<CLIENT>>();
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
        public void TestCreerClient()
        {
            var req = _clientRepo.FindWhere((c) => c.NUMERO == clientTest.NUMERO);

            Assert.AreEqual(req.Count(), 0); // Test si aucun client dans la base de ce nom existe déjà

            _clientController.CreerClient(clientTest.NOMCLIENT, clientTest.PRENOMCLIENT, clientTest.NUMERO, clientTest.EMAIL);
            req = _clientRepo.FindWhere((c) => c.NUMERO == clientTest.NUMERO);

            Assert.AreEqual(req.Count(), 1); // Test l'insertion d'un client dans la base

            foreach (CLIENT cli in req)
            {
                _clientRepo.Delete(cli);
            }
            _clientRepo.Save();
        }

        [TestMethod]
        public void TestCreerRDV()
        {
            var req = _rdvRepo.FindWhere((rdv) => rdv.HEUREFINRDV == rdvTest.HEUREFINRDV);

            Assert.AreEqual(req.Count(), 0); // Test si aucun rdv dans la base de ce type existe déjà

            _clientController.CreerRendezVous(clientTest, rdvTest.DATEHEURERDV, rdvTest.RAISON, rdvTest.HEUREFINRDV);
            req = _rdvRepo.FindWhere((rdv) => rdv.HEUREFINRDV == rdvTest.HEUREFINRDV);

            Assert.AreEqual(req.Count(), 1); // Test l'insertion d'un rendez vous dans la base

            foreach (RENDEZVOUS rdv in req)
            {
                _rdvRepo.Delete(rdv);
            }
            _rdvRepo.Save();
        }
    }
}
