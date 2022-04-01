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
    public class CareTest
    {
        private SOIN careTest;
        private List<MALADIE> diseaseTest;
        private List<PRODUIT> productTest;
        private SoinController careController;
        private SoinRepository careRepo;

        [TestInitialize]
        public void TestInitialize()
        {
            productTest = new List<PRODUIT>() {
                new PRODUIT
                {
                    NOMPRODUIT = "Test",
                    QUANTITEENSTOCK = 120,
                    DESCRIPTION = "Test",
                    MEDICAMENT = true,
                    PRIXACHAT = 10,
                    PRIXDEVENTE = 15
                }
            };

            diseaseTest = new List<MALADIE>(){
                new MALADIE
                {
                    NOMMALADIE = "Test",
                } 
            };

            careTest = new SOIN
            {
                MALADIE = diseaseTest,
                PRODUIT = productTest,
                DESCRIPTION = "Test"
            };

            //DATA MOCK CREATION
            var data = new List<SOIN> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<SOIN>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<SoinRepository, SOIN>(mockContext.Object);
            careRepo = mockRepo.Object;

            careController = new SoinController(careRepo);
            //END OF DATA MOCK CREATION
        }

        [TestMethod]
        public void TestCreateCare()
        {
            var cares = careRepo.FindAll();

            Assert.AreEqual(0, cares.Count()); // Test if the database is empty

            careController.CreateCare(careTest.MALADIE, careTest.PRODUIT, careTest.DESCRIPTION);

            Assert.AreEqual(1, cares.Count()); ; // Test if the order creation function in the database works
        }
    }
}
