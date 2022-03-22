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
        public SOIN careTest;

        [TestInitialize]
        public void TestInitialize()
        {
            careTest = new SOIN
            {
                DESCRIPTION = "Test"
            };
        }

        [TestMethod]
        public void TestCreateCare()
        {
            //DATA MOCK CREATION
            var data = new List<SOIN> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<SOIN>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<SoinRepository, SOIN>(mockContext.Object);
            var careRepo = mockRepo.Object;

            var careController = new SoinController(careRepo);
            //END OF DATA MOCK CREATION

            var care = careRepo.FindAll();

            Assert.AreEqual(0, care.Count()); // Test if the database is empty

            careController.CreerSoin(careTest.DESCRIPTION);

            //Assert.AreEqual(1, maladies.Count()); ; // Test if the order creation function in the database works
        }
    }
}
