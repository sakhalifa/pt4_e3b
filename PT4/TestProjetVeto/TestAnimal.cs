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
    public class TestAnimal
    {
        public CLIENT clientTest;
        public ANIMAL animalTest;

        [TestInitialize]
        public void TestInitialize()
        {
            clientTest = new CLIENT
            {
                NOMCLIENT = "Test",
                PRENOMCLIENT = "Test",
                NUMERO = "Test",
                EMAIL = "Test"
            };

            animalTest = new ANIMAL
            {
                IDANIMAL = 2,
                CLIENT = clientTest,
                NOMESPECE = "chat",
                NOMRACE = "tigre",
                NOMANIMAL = "Test",
                DATENAISSANCE = new DateTime(2009, 3, 10, 10, 0, 0),
                TAILLE = 18,
                POIDS = 7
            };
        }

        [TestMethod]
        public void TestCreerAnimal()
        {
            //CREATION DES DONNES MOCK
            var data = new List<ANIMAL>
            {
                new ANIMAL
            {
                IDANIMAL = 1,
                CLIENT = clientTest,
                NOMESPECE = "chat",
                NOMRACE = "tigre",
                NOMANIMAL = "Test",
                DATENAISSANCE = new DateTime(2009, 3, 10, 10, 0, 0),
                TAILLE = 18,
                POIDS = 7
            }
        };

            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<ANIMAL>()).Returns(mockSet);

            var mockRepo = new Mock<AnimalRepository>(mockContext.Object);
            mockRepo.Setup(c => c.Save()).Callback(() => { return; });
            mockRepo.CallBase = true;
            var anRepo = mockRepo.Object;

            var anController = new AnimalController(anRepo);

            //FIN DE CREATION DONNEES MOCK
            var animals = anRepo.FindAll();

            Assert.AreEqual(1, animals.Count()); //Test si l'animal de base a bien été ajouté dans la base
            Assert.AreEqual(clientTest, animals.First().CLIENT);

            anController.CreerAnimal(animalTest.CLIENT, animalTest.NOMESPECE, animalTest.NOMRACE, animalTest.NOMANIMAL, animalTest.DATENAISSANCE.GetValueOrDefault(), animalTest.TAILLE, animalTest.POIDS);

            animals = anRepo.FindAll();

            Assert.AreEqual(2, animals.Count()); // Test si la fonction de création d'un animal dans la base marche 

            anRepo.Delete(animals.First());

            animals = anRepo.FindAll();
            Assert.AreEqual(1, animals.Count()); // Test si la fonction Delete marche bien
        }
    }
}
