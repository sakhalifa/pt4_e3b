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
        private CLIENT testCustomer;
        private RENDEZVOUS testAppointment;
        private ClientController customerController;
        private ClientRepository customerRepo;
        private RendezVousRepository appointmentRepo;

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

            //DATA MOCK CREATION
            var data = new List<CLIENT> { };
            var data2 = new List<RENDEZVOUS> { };
            var mockSet = Utils.CreateDbSet(data);
            var mockSet2 = Utils.CreateDbSet(data2);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<CLIENT>()).Returns(mockSet);
            mockContext.Setup(c => c.Set<RENDEZVOUS>()).Returns(mockSet2);

            var mockRepo = Utils.CreateMockRepo<ClientRepository, CLIENT>(mockContext.Object);
            customerRepo = mockRepo.Object;

            var mockRepo2 = Utils.CreateMockRepo<RendezVousRepository, RENDEZVOUS>(mockContext.Object);
            appointmentRepo = mockRepo2.Object;

            customerController = new ClientController(customerRepo, appointmentRepo);

            //END OF DATA MOCK CREATION
        }

        [TestMethod]
        public void TestCreateCustomer()
        {
            var customers = customerRepo.FindAll();

            Assert.AreEqual(0, customers.Count()); //Test si la base est bien vide

            customerController.CreerClient(testCustomer.NOMCLIENT, testCustomer.PRENOMCLIENT, testCustomer.NUMERO, testCustomer.EMAIL);

            customers = customerRepo.FindAll();

            Assert.AreEqual(1, customers.Count()); // Test if the creation function of a customer in the database works
            // Test if you cannot create two customers with the same email
            Assert.ThrowsException<ArgumentException>(() => customerController.CreerClient("Test2", "Test2", "Test2", testCustomer.EMAIL)); 
        }

        [TestMethod]
        public void TestCreateAppointment()
        {
            var appointments = appointmentRepo.FindAll();
            Assert.AreEqual(0, appointments.Count()); // Test if the database is empty

            customerController.CreerRendezVous(testCustomer, testAppointment.DATEHEURERDV, testAppointment.RAISON, testAppointment.HEUREFINRDV);

            appointments = appointmentRepo.FindAll();
            // Test if the creation function of a rendez vous in the database works
            Assert.AreEqual(1, appointments.Count());

            // Test if you cannot take an appointment if the schedule is already taken
            Assert.ThrowsException<ArgumentException>(() => customerController.CreerRendezVous(testCustomer, testAppointment.DATEHEURERDV, testAppointment.RAISON, testAppointment.HEUREFINRDV)); 
        }

        [TestMethod]
        public void TestModifyCustomerAndFindByEmail()
        {
            var customers = customerRepo.FindAll();
            Assert.AreEqual(0, customers.Count()); // Test if the database is empty

            customerController.CreerClient(testCustomer.NOMCLIENT, testCustomer.PRENOMCLIENT, testCustomer.NUMERO, testCustomer.EMAIL);
            customers = customerRepo.FindAll();
            // Test if the good customer is add to the database
            Assert.AreEqual(customers.First().NOMCLIENT, "Test" ); 

            customerController.ModifierClient(customers.First(), "Modify", "Modify", "Modify", "Modify");
            // Test if the name of the same customer is changed
            Assert.AreEqual(customers.First().NOMCLIENT, "Modify"); 

            customerController.CreerClient("Test2", testCustomer.PRENOMCLIENT, testCustomer.NUMERO, "newEmail");
            var customer2 = customerController.FindByEmail("newEmail");
            //We have to do this because the database automatically sets this number but not here because it's mock
            customer2.IDCLIENT = 1;
            // Test if the good customer is add to the database
            Assert.AreEqual(customer2.NOMCLIENT, "Test2"); 

            // Test if you cannot modify a customer with an email which already exist
            Assert.ThrowsException<ArgumentException>(() => customerController.ModifierClient(customer2, "newName", "Modify", "Modify", "Modify")); 
        }

        [TestMethod]
        public void TestListCustomerAndRemoveFindByEmail()
        {
            var customers = customerRepo.FindAll();
            Assert.AreEqual(0, customers.Count()); // Test if the database is empty

            customerController.CreerClient(testCustomer.NOMCLIENT, testCustomer.PRENOMCLIENT, testCustomer.NUMERO, testCustomer.EMAIL);
            customers = customerController.ListCustomers();
            // Test if the customer was add to the database
            Assert.AreEqual(customers.Count(), 1);

            var customer = customerController.FindByEmail("Test");
            Assert.AreEqual(customer.NOMCLIENT, "Test"); //Test if the find by email is good

            customerController.RemoveByEmail("Test");
            customers = customerController.ListCustomers();
            // Test if the customer was delite from the database according to his email
            Assert.AreEqual(customers.Count(), 0);
        }
    }
}
