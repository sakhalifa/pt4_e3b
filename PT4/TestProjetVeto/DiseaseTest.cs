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
    public class DiseaseTest
    {
        private MALADIE diseaseTest;
        private MaladieRepository diseaseRepo;
        private MaladiesController diseaseController;

        [TestInitialize]
        public void TestInitialize()
        {
            diseaseTest = new MALADIE
            {
                NOMMALADIE = "Test",
            };

            //DATA MOCK CREATION
            var data = new List<MALADIE> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<MALADIE>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<MaladieRepository, MALADIE>(mockContext.Object);
            diseaseRepo = mockRepo.Object;

            diseaseController = new MaladiesController(diseaseRepo);
            //END OF DATA MOCK CREATION
        }

        [TestMethod]
        public void TestCreateAndListDisease()
        {
            var diseases = diseaseRepo.FindAll();

            Assert.AreEqual(0, diseases.Count()); // Test if the database is empty

            diseaseController.CreerMaladie(diseaseTest.NOMMALADIE);


            Assert.AreEqual(1, diseases.Count()); // Test if the disease creation function in the database works

            Assert.ThrowsException<ArgumentException>(() => diseaseController.CreerMaladie(diseaseTest.NOMMALADIE)); // Test if adding the same disease raises the exception
        }
    }
}
