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
    public class TestFacture
    {
        public FACTURE factureTest;
        public CLIENT clientTest;

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

            factureTest = new FACTURE
            {
                CLIENT = clientTest,
                MONTANT = 92,
                PRODUIT_VENDU = null
            };
        }

        [TestMethod]
        public void TestCreerFacture()
        {
            //CREATION DES DONNES MOCK
            var data = new List<FACTURE> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<FACTURE>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<FactureRepository, FACTURE>(mockContext.Object);
            var facRepo = mockRepo.Object;

            var facController = new FactureController(facRepo);
            //FIN DE CREATION DONNEES MOCK

            var factures = facRepo.FindAll();

            Assert.AreEqual(0, factures.Count()); //Test si la base est bien vide

            facController.CreerFacture(factureTest.PRODUIT_VENDU, factureTest.CLIENT, (int) factureTest.MONTANT);

            factures = facRepo.FindAll();

            //Assert.AreEqual(1, factures.Count()); // Test si la fonction de création d'une facture dans la base marche 
        }
    }
}
