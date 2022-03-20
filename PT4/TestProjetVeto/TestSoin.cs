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
    public class TestSoin
    {
        public SOIN soinTest;

        [TestInitialize]
        public void TestInitialize()
        {
            soinTest = new SOIN
            {
                DESCRIPTION = "Test"
            };
        }

        [TestMethod]
        public void TestCreerOrdonnance()
        {
            //CREATION DES DONNES MOCK
            var data = new List<SOIN> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<SOIN>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<SoinRepository, SOIN>(mockContext.Object);
            var soinRepo = mockRepo.Object;

            var soinController = new SoinController(soinRepo);
            //FIN DE CREATION DONNEES MOCK

            var soins = soinRepo.FindAll();

            Assert.AreEqual(0, soins.Count()); //Test si la base est bien vide

            soinController.CreerSoin(soinTest.DESCRIPTION);

            //Assert.AreEqual(1, maladies.Count()); ; // Test si la fonction de création d'une ordonnance dans la base marche 
        }
    }
}
