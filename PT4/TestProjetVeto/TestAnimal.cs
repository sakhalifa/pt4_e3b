using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PT4;
using PT4.Model.dal;
using PT4.Controllers;
using System.Linq;
using System;
using PT4.Model.impl;
using System.Data.Entity;

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
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<DbContext, PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>()
                    .AddSingleton<IGenericRepository<ANIMAL>, AnimalRepository>()
                    .AddSingleton<AnimalController>()
                    .AddSingleton<ClientController>()
            ;
            services.AddSingleton(services);

            using(ServiceProvider provider = services.BuildServiceProvider())
            {
                _animalRepo = provider.GetRequiredService<IGenericRepository<ANIMAL>>();
                _animalController = provider.GetRequiredService<AnimalController>();
            }

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
            var req = _animalRepo.FindWhere((a) => a.NOMANIMAL == animalTest.NOMANIMAL);

            Assert.AreEqual(req.Count(), 0); // Test si aucun animal de ce nom dans la base existe d�j�

            _animalController.CreerAnimal(clientTest, animalTest.NOMESPECE, animalTest.NOMRACE, animalTest.NOMANIMAL, (DateTime)animalTest.DATENAISSANCE, animalTest.TAILLE, animalTest.POIDS);
            req = _animalRepo.FindWhere((a) => a.NOMANIMAL == animalTest.NOMANIMAL);

            Assert.AreEqual(req.Count(), 1); // Test l'insertion d'un animal dans la base    

            foreach (ANIMAL ani in req)
            {
                _animalRepo.Delete(ani);
            }
            _animalRepo.Save();
        }
    }
}
