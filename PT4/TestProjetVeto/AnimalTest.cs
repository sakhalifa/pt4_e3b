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
        private CLIENT testCustomer;
        private ANIMAL testAnimal;
        private AnimalController anController;
        private AnimalRepository anRepo;
        private HistoriqueMaladieRepository anHistoriqueMaladieRepository;

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
                IDANIMAL = 1,
                CLIENT = testCustomer,
                NOMESPECE = "chat",
                NOMRACE = "tigre",
                NOMANIMAL = "Test",
                DATENAISSANCE = new DateTime(2009, 3, 10, 10, 0, 0),
                TAILLE = 18,
                POIDS = 7
            };

            //DATA MOCK CREATION
            var data = new List<ANIMAL> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<ANIMAL>()).Returns(mockSet);

            var mockRepo = new Mock<AnimalRepository>(mockContext.Object);
            mockRepo.Setup(c => c.Save()).Callback(() => { return; });
            mockRepo.Setup(c => c.Update(It.IsAny<ANIMAL>())).Callback<ANIMAL>(a => { return; });
            mockRepo.CallBase = true;
            anRepo = mockRepo.Object;

            var mockRepo2 = new Mock<HistoriqueMaladieRepository>(mockContext.Object);
            mockRepo2.Setup(c => c.Save()).Callback(() => { return; });
            mockRepo2.Setup(c => c.Update(It.IsAny<HISTORIQUEMALADIE>())).Callback<HISTORIQUEMALADIE>(h => { return; });
            mockRepo2.CallBase = true;
            anHistoriqueMaladieRepository = mockRepo2.Object;
            

            anController = new AnimalController(anRepo, anHistoriqueMaladieRepository);
            //END OF DATA MOCK CREATION
        }

        [TestMethod]
        public void TestAllMethods()
        {
            var animals = anRepo.FindAll();
            Assert.AreEqual(0, animals.Count()); // Test if the database contains one element

            CreateAnimalTest(animals);
            ModifyAnimalTest(animals.First());
            AllAnimalsCustomerTest();
            DeleteAnimalTest(animals, animals.Count());
        }

        private void CreateAnimalTest(IQueryable<ANIMAL> animals)
        {
            anController.CreerAnimal(testAnimal.CLIENT, testAnimal.NOMESPECE, testAnimal.NOMRACE, testAnimal.NOMANIMAL, testAnimal.DATENAISSANCE.GetValueOrDefault(), testAnimal.TAILLE, testAnimal.POIDS);
            animals = anRepo.FindAll();
            // Test if the animal creation function in the database works
            Assert.AreEqual(1, animals.Count());
        }

        
        private void ModifyAnimalTest(ANIMAL animal)
        {
            anController.ModifierAnimal(animal, testCustomer, "Test2", "Test2", "Test2", animal.DATENAISSANCE.GetValueOrDefault(), animal.TAILLE, animal.POIDS);
            var animals = anRepo.FindAll();
            // Test if the animal modification function in the database works
            Assert.AreEqual(animals.First().NOMANIMAL, "Test2"); 
        }

        private void AllAnimalsCustomerTest()
        {
            testCustomer.IDCLIENT = 1;
            var animals = anController.AllAnimalsOfCustomer(testCustomer);
            // Test if we find good number
            Assert.AreEqual(animals.Count(), 1);
        }

        private void DeleteAnimalTest(IQueryable<ANIMAL> animals, int number)
        {
            anController.DeleteAnimal(animals.First());
            Assert.AreEqual(animals.Count(), number - 1);
        }
    }
}
