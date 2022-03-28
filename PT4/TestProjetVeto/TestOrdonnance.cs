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
    public class TestOrdonnance
    {
        public ORDONNANCE ordonnanceTest;

        [TestInitialize]
        public void TestInitialize()
        {
            ordonnanceTest = new ORDONNANCE
            {
                DATEORDO = new DateTime(2009, 3, 10, 10, 0, 0),
                ANIMAL = null,
                SOIN = null
            };
        }

        [TestMethod]
        public void TestCreerOrdonnance()
        {
            //CREATION DES DONNES MOCK
            var data = new List<ORDONNANCE> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<ORDONNANCE>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<OrdonnanceRepository, ORDONNANCE>(mockContext.Object);
            var ordoRepo = mockRepo.Object;

            var ordoController = new OrdonnanceController(ordoRepo);
            //FIN DE CREATION DONNEES MOCK

            var ordonnances = ordoRepo.FindAll();

            Assert.AreEqual(0, ordonnances.Count()); //Test si la base est bien vide

            ordoController.CreerOrdonnance(ordonnanceTest.DATEORDO);

            //Assert.AreEqual(1, maladies.Count()); ; // Test si la fonction de création d'une ordonnance dans la base marche 
        }
    }
}
