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
    public class TestEmploye
    {
        private IGenericRepository<SALARIÉ> _salarieRepo;
        private IGenericRepository<CONGÉ> _congeRepo;
        private SalarieController _employeController;
        public CONGÉ congeTest;
        public SALARIÉ salaireTest;

        [TestInitialize]
        public void TestInitialize()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<DbContext, PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>()
                    .AddSingleton<IGenericRepository<SALARIÉ>, SalarieRepository>()
                    .AddSingleton<IGenericRepository<CONGÉ>, CongeRepository>()
                    .AddSingleton<SalarieController>()
            ;
            services.AddSingleton(services);

            using (ServiceProvider provider = services.BuildServiceProvider())
            {
                _salarieRepo = provider.GetRequiredService<IGenericRepository<SALARIÉ>>();
                _congeRepo = provider.GetRequiredService<IGenericRepository<CONGÉ>>();
                _employeController = provider.GetRequiredService<SalarieController>();
            }

            salaireTest = new SALARIÉ
            {
                DONNEES_PERSONNELLES = "Test",
                LOGIN = "Test",
                CONGÉ = null,
                estAdmin = false,
            };

            congeTest = new CONGÉ
            {
                ESTREGULIER = false,
                DATEDEBUT = new DateTime(2009, 3, 10, 10, 0, 0),
                DATEFIN = new DateTime(2009, 3, 17, 10, 0, 0)  
            };
        }

        [TestMethod]
        public void TestCreerSalarieEtPositionnerConge()
        {
            var reqSalarie1 = _salarieRepo.FindWhere((s) => s.LOGIN == salaireTest.LOGIN);
            Assert.AreEqual(reqSalarie1.Count(), 0); // Test si aucun salarié dans la base de ce login existe déjà

            var reqConge1 = _congeRepo.FindWhere((c) => c.DATEDEBUT == congeTest.DATEDEBUT);
            Assert.AreEqual(reqConge1.Count(), 0); // Test si aucun congé dans la base de ce style existe déjà

            _employeController.CreerSalarie(salaireTest.LOGIN, "Test", salaireTest.DONNEES_PERSONNELLES);
            reqSalarie1 = _salarieRepo.FindWhere((s) => s.LOGIN == salaireTest.LOGIN);

            Assert.AreEqual(reqSalarie1.Count(), 1); // Test l'insertion d'un salarie dans la base

            _employeController.PositionnerConge(salaireTest, congeTest.DATEDEBUT, congeTest.DATEFIN, congeTest.ESTREGULIER);
            reqConge1 = _congeRepo.FindWhere((c) => c.DATEDEBUT == congeTest.DATEDEBUT);
            Assert.AreEqual(reqConge1.Count(), 1); // Test si le congé a bien été ajouté dans la base

            foreach (SALARIÉ sal in reqSalarie1)
            {
                _salarieRepo.Delete(sal);
            }
            _salarieRepo.Save();

            foreach (CONGÉ con in reqConge1)
            {
                _congeRepo.Delete(con);
            }
            _congeRepo.Save();
        }

        [TestMethod]
        public void TestConnexion()
        {
            SALARIÉ sal = _employeController.Connexion(salaireTest.LOGIN, "Test");
            Assert.AreEqual(sal.LOGIN, null); // Test si la connexion pour un utilisateur qui n'est pas dans la base retourne un résultat null

            SALARIÉ sal2 = _employeController.Connexion("AMaux", "Admin123");
            Assert.AreEqual(sal2.LOGIN, "AMaux"); // Test si la connexion pour un utilisateur existant retourne bien un salarié de la base
        }

        [TestMethod]
        public void TestRecupCongesPourSalarie()
        {
            //Assert.ThrowsException<Exception>(_employeController.RecupCongesPourSalarie(salaireTest.LOGIN)); //Test si l'exception est bien levée si aucun utilisateur de ce login existe

            Assert.AreEqual(_employeController.RecupCongesPourSalarie("AMaux"), 2); //Test si on récupère bien le bon nombre de congé pour un login spécifié
        }
    }
}
