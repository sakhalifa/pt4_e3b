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
    public class ProductTest
    {
        public PRODUIT productTest;

        [TestInitialize]
        public void TestInitialize()
        {
            productTest = new PRODUIT
            {
                NOMPRODUIT = "Test",
                QUANTITEENSTOCK = 120,
                DESCRIPTION = "Test",
                MEDICAMENT = true,
                PRIXACHAT = 10,
                PRIXDEVENTE = 15
            };
        }

        [TestMethod]
        public void TestCreateOrUpdateProductAndFindByName()
        {
            //DATA MOCK CREATION
            var data = new List<PRODUIT> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<PRODUIT>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<ProduitRepository, PRODUIT>(mockContext.Object);
            var productRepo = mockRepo.Object;

            var productController = new ProduitController(productRepo);
            //END OF DATA MOCK CREATION

            var products = productRepo.FindAll();

            Assert.AreEqual(0, products.Count()); // Test if the database is empty

            Assert.IsNull(productController.FindByName(productTest.NOMPRODUIT)); // Test if finding a product that does not exist returns null

            productController.CreerOuMaJProduit(productTest.NOMPRODUIT, (decimal)productTest.PRIXDEVENTE, productTest.PRIXACHAT, productTest.QUANTITEENSTOCK, productTest.DESCRIPTION, productTest.MEDICAMENT, true);
            Assert.AreEqual(1, products.Count()); ; // Test if the product creation function in the database works 

            Assert.IsNotNull(productController.FindByName(productTest.NOMPRODUIT)); // Test if now that the product is created if the method does not return null

            productController.CreerOuMaJProduit(productTest.NOMPRODUIT, (decimal)productTest.PRIXDEVENTE, productTest.PRIXACHAT, productTest.QUANTITEENSTOCK, productTest.DESCRIPTION, productTest.MEDICAMENT, true);
            Assert.AreEqual(240, products.First().QUANTITEENSTOCK); // Test if the update function works well
        }
    }
}
