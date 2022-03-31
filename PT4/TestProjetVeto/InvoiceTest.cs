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
    public class InvoiceTest
    {
        public FACTURE invoiceTest;
        public CLIENT customerTest;

        [TestInitialize]
        public void TestInitialize()
        {
            customerTest = new CLIENT
            {
                NOMCLIENT = "Test",
                PRENOMCLIENT = "Test",
                NUMERO = "Test",
                EMAIL = "Test"
            };

            invoiceTest = new FACTURE
            {
                CLIENT = customerTest,
                MONTANT = 92,
                PRODUIT_VENDU = null
            };
        }

        [TestMethod]
        public void TestCreateInvoice()
        {
            //DATA MOCK CREATION
            var data = new List<FACTURE> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<FACTURE>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<FactureRepository, FACTURE>(mockContext.Object);
            var invRepo = mockRepo.Object;

            var invController = new FactureController(invRepo);
            //END OF DATA MOCK CREATION

            var invoices = invRepo.FindAll();

            Assert.AreEqual(0, invoices.Count()); // Test if the database is empty

            invController.CreerFacture(invoiceTest.PRODUIT_VENDU, invoiceTest.CLIENT, (int) invoiceTest.MONTANT);

            invoices = invRepo.FindAll();

            //Assert.AreEqual(1, factures.Count()); // Test if the invoice creation function in the database works
        }
    }
}
