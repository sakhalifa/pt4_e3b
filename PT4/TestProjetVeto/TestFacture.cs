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
    public class TestFacture
    {
        private IGenericRepository<FACTURE> _factureRepo;
        private FactureController _factureController;
        public FACTURE factureTest;

        [TestInitialize]
        public void TestInitialize()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<DbContext, PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>()
                    .AddSingleton<IGenericRepository<FACTURE>, FactureRepository>()
                    .AddSingleton<FactureController>()
            ;
            services.AddSingleton(services);

            using(ServiceProvider provider = services.BuildServiceProvider())
            {
                _factureRepo = provider.GetRequiredService<IGenericRepository<FACTURE>>();
            }

            factureTest = new FACTURE
            {
                CLIENT = null,
                
            };
        }

        [TestMethod]
        public void TestCreerFacture()
        {
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
        }
    }
}
