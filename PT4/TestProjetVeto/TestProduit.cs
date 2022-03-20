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
    public class TestProduit
    {
        public PRODUIT produitTest;

        [TestInitialize]
        public void TestInitialize()
        {
            produitTest = new PRODUIT
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
        public void TestCreerOuMaJProduit()
        {
            //CREATION DES DONNES MOCK
            var data = new List<PRODUIT> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<PRODUIT>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<ProduitRepository, PRODUIT>(mockContext.Object);
            var produitRepo = mockRepo.Object;

            var produitController = new ProduitController(produitRepo);
            //FIN DE CREATION DONNEES MOCK

            var produits = produitRepo.FindAll();

            Assert.AreEqual(0, produits.Count()); //Test si la base est bien vide

            produitController.CreerOuMaJProduit(produitTest.NOMPRODUIT, (decimal) produitTest.PRIXDEVENTE, produitTest.PRIXACHAT, produitTest.QUANTITEENSTOCK, produitTest.DESCRIPTION, produitTest.MEDICAMENT, true);
            Assert.AreEqual(1, produits.Count()); ; // Test si la fonction de création d'un produit dans la base marche 

            produitController.CreerOuMaJProduit(produitTest.NOMPRODUIT, (decimal)produitTest.PRIXDEVENTE, produitTest.PRIXACHAT, produitTest.QUANTITEENSTOCK, produitTest.DESCRIPTION, produitTest.MEDICAMENT, true);
            Assert.AreEqual(240, produits.First().QUANTITEENSTOCK); // Test si la fonction de mise à jour marche bien
        }
    }
}
