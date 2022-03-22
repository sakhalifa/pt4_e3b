using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PT4;
using PT4.Controllers;
using PT4.Model.impl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProjetVeto
{
    [TestClass]
    public class OrderTest
    {
        public ORDONNANCE ordonnanceTest;

        [TestInitialize]
        public void TestInitialize()
        {
            ordonnanceTest = new ORDONNANCE
            {
                DATEORDO = new DateTime(2009, 3, 10, 10, 0, 0)
            };
        }

        [TestMethod]
        public void TestCreateOrder()
        {
            //DATA MOCK CREATION
            var data = new List<ORDONNANCE> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<ORDONNANCE>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<OrdonnanceRepository, ORDONNANCE>(mockContext.Object);
            var orderRepo = mockRepo.Object;

            var orderController = new OrdonnanceController(orderRepo);
            //END OF DATA MOCK CREATION

            var orders = orderRepo.FindAll();

            Assert.AreEqual(0, orders.Count()); // Test if the database is empty

            orderController.CreerOrdonnance(ordonnanceTest.DATEORDO);

            //Assert.AreEqual(1, maladies.Count()); ; // Test if the order creation function in the database works
        }
    }
}
