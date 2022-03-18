using Microsoft.VisualStudio.TestTools.UnitTesting;
using PT4;
using PT4.Model.dal;
using PT4.Controllers;
using Moq;
using System.Linq;
using System;
using PT4.Model.impl;
using System.Collections.Generic;

namespace TestProjetVeto
{
    [TestClass]
    public class TestClient
    {
        public CLIENT clientTest;
        public RENDEZVOUS rdvTest;

        [TestInitialize]
        public void TestInitialize()
        {
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
            //CREATION DES DONNES MOCK
            var data = new List<CLIENT> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<CLIENT>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<ClientRepository, CLIENT>(mockContext.Object);
            var cliRepo = mockRepo.Object;

            var mockRepo2 = Utils.CreateMockRepo<RendezVousRepository, RENDEZVOUS>(mockContext.Object);
            var rdvRepo = mockRepo2.Object;


            var cliController = new ClientController(cliRepo, rdvRepo);

            //FIN DE CREATION DONNEES MOCK
            var clients = cliRepo.FindAll();

            Assert.AreEqual(0, clients.Count()); //Test si la base est bien vide

            cliController.CreerClient(clientTest.NOMCLIENT, clientTest.PRENOMCLIENT, clientTest.NUMERO, clientTest.EMAIL);

            clients = cliRepo.FindAll();

            Assert.AreEqual(1, clients.Count()); // Test si la fonction de création d'un client dans la base marche 
        }

        [TestMethod]
        public void TestCreerRDV()
        {
            //CREATION DES DONNES MOCK
            var data = new List<RENDEZVOUS> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<RENDEZVOUS>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<ClientRepository, CLIENT>(mockContext.Object);
            var cliRepo = mockRepo.Object;

            var mockRepo2 = Utils.CreateMockRepo<RendezVousRepository, RENDEZVOUS>(mockContext.Object);
            var rdvRepo = mockRepo2.Object;

            var cliController = new ClientController(cliRepo, rdvRepo);

            //FIN DE CREATION DONNEES MOCK
            var clients = rdvRepo.FindAll();

            Assert.AreEqual(0, clients.Count()); //Test si la base est bien vide

            cliController.CreerRendezVous(clientTest, rdvTest.DATEHEURERDV, rdvTest.RAISON, rdvTest.HEUREFINRDV);

            clients = rdvRepo.FindAll();

            Assert.AreEqual(1, clients.Count()); // Test si la fonction de création d'un rendez vous dans la base marche 
        }
    }
}
