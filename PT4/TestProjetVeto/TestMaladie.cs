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
    public class TestMaladie
    {
        public MALADIE maladieTest;

        [TestInitialize]
        public void TestInitialize()
        {
            maladieTest = new MALADIE
            {
                NOMMALADIE = "Test",
            };
        }

        [TestMethod]
        public void TestCreerMaladie()
        {
            //CREATION DES DONNES MOCK
            var data = new List<MALADIE> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<MALADIE>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<MaladieRepository, MALADIE>(mockContext.Object);
            var malRepo = mockRepo.Object;

            var malController = new MaladiesController(malRepo);
            //FIN DE CREATION DONNEES MOCK

            var maladies = malRepo.FindAll();

            Assert.AreEqual(0, maladies.Count()); //Test si la base est bien vide

            malController.CreerMaladie(maladieTest.NOMMALADIE);

            malController.ListerMaladies();

            Assert.AreEqual(1, maladies.Count()); ; // Test si la fonction de création d'une facture dans la base marche 

            //Assert.ThrowsException<string>(malController.CreerMaladie(maladieTest.NOMMALADIE)); //Test si l'ajout d'une même maladie lève l'exception
        }

        [TestMethod]
        public void TestRechercherMaladies()
        {

        }
    }
}
