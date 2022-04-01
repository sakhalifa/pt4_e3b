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
        private PRODUIT productTest;
        private ProduitRepository productRepo;
        private ProduitController productController;

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

            //DATA MOCK CREATION
            var data = new List<PRODUIT> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<PRODUIT>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<ProduitRepository, PRODUIT>(mockContext.Object);
            productRepo = mockRepo.Object;

            productController = new ProduitController(productRepo);
            //END OF DATA MOCK CREATION
        }

        [TestMethod]
        public void TestCreateOrUpdateProductAndFindByName()
        {
            var products = productRepo.FindAll();
            Assert.AreEqual(0, products.Count()); // Test if the database is empty

            Assert.IsNull(productController.FindByName(productTest.NOMPRODUIT)); // Test if finding a product that does not exist returns null

            productController.CreerOuMaJProduit(productTest.NOMPRODUIT, (decimal)productTest.PRIXDEVENTE, productTest.PRIXACHAT, productTest.QUANTITEENSTOCK, productTest.DESCRIPTION, productTest.MEDICAMENT, true);
            Assert.AreEqual(1, products.Count()); ; // Test if the product creation function in the database works 

            Assert.IsNotNull(productController.FindByName(productTest.NOMPRODUIT)); // Test if now that the product is created if the method does not return null

            productController.CreerOuMaJProduit(productTest.NOMPRODUIT, (decimal)productTest.PRIXDEVENTE, productTest.PRIXACHAT, productTest.QUANTITEENSTOCK, productTest.DESCRIPTION, productTest.MEDICAMENT, true);
            Assert.AreEqual(240, products.First().QUANTITEENSTOCK); // Test if the update function works well

            TestRemoveByName(products);
            productController.CreerOuMaJProduit(productTest.NOMPRODUIT, (decimal)productTest.PRIXDEVENTE, productTest.PRIXACHAT, 5, productTest.DESCRIPTION, productTest.MEDICAMENT, true);
            TestGetAlmostExpiredProducts();
            TestGetAllSellableProducts();

        }

      
        private void TestRemoveByName(IQueryable<PRODUIT> products)
        {
            productController.RemoveByName(productTest.NOMPRODUIT);
            Assert.AreEqual(0, products.Count());
        }

        private void TestGetAlmostExpiredProducts()
        {
            var products = productController.GetAlmostExpiredProducts();
            Assert.AreEqual(1, products.Count());
            Assert.AreEqual(products.First().QUANTITEENSTOCK, 5);
        }

        private void TestGetAllSellableProducts()
        {
            var products = productController.GetAllSellableProducts();
            Assert.AreEqual(1, products.Count());
            productController.CreerOuMaJProduit("Test2", null, 3, 5, productTest.DESCRIPTION, productTest.MEDICAMENT, true);
            products = productController.GetAllSellableProducts();
            Assert.AreEqual(1, products.Count());
        }

      
        
    }
}
