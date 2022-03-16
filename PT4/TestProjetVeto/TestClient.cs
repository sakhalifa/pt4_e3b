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
        private IGenericRepository<CLIENT> _clientRepo;
        private ClientController _clientController;
        public CLIENT clientTest;

        [TestInitialize]
        public void TestInitialize()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<DbContext, PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>()
                    .AddSingleton<IGenericRepository<CLIENT>, ClientRepository>()
                    .AddSingleton<ClientController>()
            ;
            services.AddSingleton(services);

            using (ServiceProvider provider = services.BuildServiceProvider())
            {
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
        }

        [TestMethod]
        public void TestCreerClient()
        {
            var req1 = _clientRepo.FindWhere((c) => c.NUMERO == clientTest.NUMERO);

            Assert.AreEqual(req1.Count(), 0); // Test si aucun client dans la base de ce nom existe déjà

            _clientController.CreerClient(clientTest.NOMCLIENT, clientTest.PRENOMCLIENT, clientTest.NUMERO, clientTest.EMAIL);
            var req2 = _clientRepo.FindWhere((c) => c.NUMERO == clientTest.NUMERO);

            Assert.AreEqual(req2.Count(), 1); // Test l'insertion d'un client dans la base

            foreach (CLIENT cli in req2)
            {
                _clientRepo.Delete(cli);
            }
            _clientRepo.Save();
        }
    }
}
