using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PT4;
using PT4.Model.dal;
using PT4.Controllers;
using Moq;
using System.Linq;
using System;
using PT4.Model.impl;
using System.Data.Entity;
using System.Collections.Generic;

namespace TestProjetVeto
{


    [TestClass]
    public class TestAnimal
    {
        private IGenericRepository<ANIMAL> _animalRepo;
        private AnimalController _animalController;
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
        }.AsQueryable();

            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<ANIMAL>()).Returns(mockSet);

            var anRepo = new AnimalRepository(mockContext.Object);

            //FIN DE CREATION DONNEES MOCK
            var animals = anRepo.FindAll();

            Assert.AreEqual(1, animals.Count());
            

            /*
            var req = _animalRepo.FindWhere((a) => a.NOMANIMAL == animalTest.NOMANIMAL);

            Assert.AreEqual(req.Count(), 0); // Test si aucun animal de ce nom dans la base existe déjà

            _animalController.CreerAnimal(clientTest, animalTest.NOMESPECE, animalTest.NOMRACE, animalTest.NOMANIMAL, (DateTime)animalTest.DATENAISSANCE, animalTest.TAILLE, animalTest.POIDS);
            req = _animalRepo.FindWhere((a) => a.NOMANIMAL == animalTest.NOMANIMAL);

            Assert.AreEqual(req.Count(), 1); // Test l'insertion d'un animal dans la base    

            foreach (ANIMAL ani in req)
            {
                _animalRepo.Delete(ani);
            }
            _animalRepo.Save();
            */
        }
    }
}
