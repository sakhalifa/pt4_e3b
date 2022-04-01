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
        private FACTURE invoiceTest;
        private CLIENT customerTest;
        private PRODUIT productTest;
        private PRODUIT productTest2;

        [TestInitialize]
        public void TestInitialize()
        {
            productTest = new PRODUIT
            {
                NOMPRODUIT = "Test",
                QUANTITEENSTOCK = 120,
                DESCRIPTION = "Test",
                MEDICAMENT = true
            };

            productTest2 = new PRODUIT
            {
                NOMPRODUIT = "Test2",
                QUANTITEENSTOCK = 10,
                DESCRIPTION = "Test2",
                MEDICAMENT = true,
                PRIXACHAT = 1,
                PRIXDEVENTE = 2
            };

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
        public void TestAllMethodsOfInvoiceController()
        {
            //DATA MOCK CREATION
            var data = new List<FACTURE> { };
            var dataSellProduct = new List<PRODUIT_VENDU> { };
            var dataProduct = new List<PRODUIT> { };
            var mockSet = Utils.CreateDbSet(data);
            var mockSell = Utils.CreateDbSet(dataSellProduct);
            var mockProduct = Utils.CreateDbSet(dataProduct);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<FACTURE>()).Returns(mockSet);
            mockContext.Setup(c => c.Set<PRODUIT_VENDU>()).Returns(mockSell);
            mockContext.Setup(c => c.Set<PRODUIT>()).Returns(mockProduct);

            var mockRepo = Utils.CreateMockRepo<FactureRepository, FACTURE>(mockContext.Object);
            var invRepo = mockRepo.Object;

            var mockRepo2 = Utils.CreateMockRepo<ProduitVenduRepository, PRODUIT_VENDU>(mockContext.Object);
            var sellProductRepo = mockRepo2.Object;

            var mockRepo3 = Utils.CreateMockRepo<ProduitRepository, PRODUIT>(mockContext.Object);
            var prodRepo = mockRepo3.Object;

            var invController = new FactureController(invRepo, sellProductRepo, prodRepo);
            //END OF DATA MOCK CREATION

            FACTURE facture = invController.CreerFacture(customerTest);
            // Test if the invoice creation function works
            Assert.AreEqual("Test", facture.CLIENT.PRENOMCLIENT); 

            TestAddProductToReceipt(facture, invController);
            TestUpdateAmount(facture, invController);
            TestRemoveProductFromReceipt(facture, invController);
            facture = invController.AddProductToReceipt(facture, productTest2, 5);
            TestReset(invController);
            TestSaveReceipt(facture, invController, invRepo);
            
        }

        private void TestUpdateAmount(FACTURE facture, FactureController invController)
        {
            invController.UpdateMontant(facture);
            // Test if the calcul of the amount is good
            Assert.AreEqual(facture.MONTANT, 16);
        }

        private void TestSaveReceipt(FACTURE facture, FactureController invController, FactureRepository invRepo)
        {
            facture = invController.AddProductToReceipt(facture, productTest2, 5);
            invController.SaveReceipt(facture);
            Assert.AreEqual(invRepo.FindAll().First(), facture);
        }

        private void TestAddProductToReceipt(FACTURE facture, FactureController invController)
        {
            // Test if the exception is thrown if the wanted quantity is above the quantity in stock
            Assert.ThrowsException<ArgumentException>(() => invController.AddProductToReceipt(facture, productTest2, 15));

            // Test if the exception is thrown if the product is not saleable
            Assert.ThrowsException<ArgumentException>(() => invController.AddProductToReceipt(facture, productTest, 10));

            facture = invController.AddProductToReceipt(facture, productTest2, 5);
            // Test if the real quantity has decreased
            Assert.AreEqual(productTest2.QUANTITEENSTOCK, 5);
            // Test the number of product sold
            Assert.AreEqual(facture.PRODUIT_VENDU.Count, 1);

            facture = invController.AddProductToReceipt(facture, productTest2, 3);
            // Test if the real quantity has decreased
            Assert.AreEqual(productTest2.QUANTITEENSTOCK, 2);
            // Test if the quantity of the product sold has increased
            Assert.AreEqual(facture.PRODUIT_VENDU.First().QUANTITÉ, 8);
        }

        private void TestReset(FactureController invController)
        {
            invController.Reset();
            // Test if the reset function reset the invoince
            Assert.AreEqual(productTest2.QUANTITEENSTOCK, 10);
        }

        private void TestRemoveProductFromReceipt(FACTURE facture, FactureController invController)
        {
            // Test if the exception is thrown if you want to remove more product than contains the invoice
            Assert.ThrowsException<ArgumentException>(() => invController.RemoveProductFromReceipt(facture, productTest2, 20));

            // Test if the exception is thrown if the product is not in the invoice
            Assert.ThrowsException<ArgumentException>(() => invController.RemoveProductFromReceipt(facture, productTest, 20));

            invController.RemoveProductFromReceipt(facture, productTest2, 5);
            Assert.AreEqual(productTest2.QUANTITEENSTOCK, 7);
            Assert.AreEqual(facture.PRODUIT_VENDU.Count, 1);

            invController.RemoveProductFromReceipt(facture, productTest2, 3);
            Assert.AreEqual(productTest2.QUANTITEENSTOCK, 10);
            Assert.AreEqual(facture.PRODUIT_VENDU.Count, 0);
        }

        
    }
}
