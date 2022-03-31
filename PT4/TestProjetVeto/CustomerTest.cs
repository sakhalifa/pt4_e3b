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
    public class CustomerTest
    {
        public CLIENT testCustomer;
        public RENDEZVOUS testAppointment;

        [TestInitialize]
        public void TestInitialize()
        {
            testCustomer = new CLIENT
            {
                NOMCLIENT = "Test",
                PRENOMCLIENT = "Test",
                NUMERO = "Test",
                EMAIL = "Test"
            };

            testAppointment = new RENDEZVOUS
            {
                CLIENT = testCustomer,
                DATEHEURERDV = new DateTime(2050, 3, 10, 10, 0, 0),
                RAISON = "Mon chat ne veut plus manger",
                HEUREFINRDV = new DateTime(2050, 3, 10, 10, 30, 0)
            };
        }

        [TestMethod]
        public void TestCreateCustomer()
        {
            //DATA MOCK CREATION
            var data = new List<CLIENT> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<CLIENT>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<ClientRepository, CLIENT>(mockContext.Object);
            var customerRepo = mockRepo.Object;

            var mockRepo2 = Utils.CreateMockRepo<RendezVousRepository, RENDEZVOUS>(mockContext.Object);
            var appointmentRepo = mockRepo2.Object;

            var customerController = new ClientController(customerRepo, appointmentRepo);

            //END OF DATA MOCK CREATION
            var customers = customerRepo.FindAll();

            Assert.AreEqual(0, customers.Count()); // Test if the database is empty

            customerController.CreerClient(testCustomer.NOMCLIENT, testCustomer.PRENOMCLIENT, testCustomer.NUMERO, testCustomer.EMAIL);

            customers = customerRepo.FindAll();

            Assert.AreEqual(1, customers.Count()); // Test if the creation function of a customer in the database works
        }

        [TestMethod]
        public void TestCreateAppointment()
        {
            //DATA MOCK CREATION
            var data = new List<RENDEZVOUS> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<RENDEZVOUS>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<ClientRepository, CLIENT>(mockContext.Object);
            var customerRepo = mockRepo.Object;

            var mockRepo2 = Utils.CreateMockRepo<RendezVousRepository, RENDEZVOUS>(mockContext.Object);
            var appointmentRepo = mockRepo2.Object;

            var customerController = new ClientController(customerRepo, appointmentRepo);

            //END OF DATA MOCK CREATION
            var customers = appointmentRepo.FindAll();

            Assert.AreEqual(0, customers.Count()); // Test if the database is empty

            customerController.CreerRendezVous(testCustomer, testAppointment.DATEHEURERDV, testAppointment.RAISON, testAppointment.HEUREFINRDV);

            customers = appointmentRepo.FindAll();

            Assert.AreEqual(1, customers.Count()); // Test if the creation function of a rendez vous in the database works
        }
    }
}
