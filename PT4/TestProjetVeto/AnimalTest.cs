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
    public class AnimalTest
    {
        public CLIENT testCustomer;
        public ANIMAL testAnimal;

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

            testAnimal = new ANIMAL
            {
                IDANIMAL = 2,
                CLIENT = testCustomer,
                NOMESPECE = "chat",
                NOMRACE = "tigre",
                NOMANIMAL = "Test",
                DATENAISSANCE = new DateTime(2009, 3, 10, 10, 0, 0),
                TAILLE = 18,
                POIDS = 7
            };
        }

        [TestMethod]
        public void CreateAnimalTest()
        {
            //DATA MOCK CREATION
            var data = new List<ANIMAL>
            {
                new ANIMAL
            {
                IDANIMAL = 1,
                CLIENT = testCustomer,
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
            //END OF DATA MOCK CREATION

            var animals = anRepo.FindAll();

            Assert.AreEqual(1, animals.Count()); // Test if the database contains one element
            Assert.AreEqual(testCustomer, animals.First().CLIENT);

            anController.CreerAnimal(testAnimal.CLIENT, testAnimal.NOMESPECE, testAnimal.NOMRACE, testAnimal.NOMANIMAL, testAnimal.DATENAISSANCE.GetValueOrDefault(), testAnimal.TAILLE, testAnimal.POIDS);

            animals = anRepo.FindAll();

            Assert.AreEqual(2, animals.Count()); // Test if the animal creation function in the database works

            anRepo.Delete(animals.First());

            animals = anRepo.FindAll(); // Test if the animal deletion function in the database works
            Assert.AreEqual(1, animals.Count());

        }
    }
}
