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
        private IGenericRepository<SALARI�> _salarieRepo;
        private IGenericRepository<CONG�> _congeRepo;
        private SalarieController _employeController;
        public CONG� congeTest;
        public SALARI� salaireTest;

        [TestInitialize]
        public void TestInitialize()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<DbContext, PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>()
                    .AddSingleton<IGenericRepository<SALARI�>, SalarieRepository>()
                    .AddSingleton<IGenericRepository<CONG�>, CongeRepository>()
                    .AddSingleton<SalarieController>()
            ;
            services.AddSingleton(services);

            using (ServiceProvider provider = services.BuildServiceProvider())
            {
                _salarieRepo = provider.GetRequiredService<IGenericRepository<SALARI�>>();
                _congeRepo = provider.GetRequiredService<IGenericRepository<CONG�>>();
                _employeController = provider.GetRequiredService<SalarieController>();
            }

            salaireTest = new SALARI�
            {
                DONNEES_PERSONNELLES = "Test",
                LOGIN = "Test",
                CONG� = null,
                estAdmin = false,
            };

            congeTest = new CONG�
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
            Assert.AreEqual(reqSalarie1.Count(), 0); // Test si aucun salari� dans la base de ce login existe d�j�

            var reqConge1 = _congeRepo.FindWhere((c) => c.DATEDEBUT == congeTest.DATEDEBUT);
            Assert.AreEqual(reqConge1.Count(), 0); // Test si aucun cong� dans la base de ce style existe d�j�

            _employeController.CreerSalarie(salaireTest.LOGIN, "Test", salaireTest.DONNEES_PERSONNELLES);
            reqSalarie1 = _salarieRepo.FindWhere((s) => s.LOGIN == salaireTest.LOGIN);

            Assert.AreEqual(reqSalarie1.Count(), 1); // Test l'insertion d'un salarie dans la base

            _employeController.PositionnerConge(salaireTest, congeTest.DATEDEBUT, congeTest.DATEFIN, congeTest.ESTREGULIER);
            reqConge1 = _congeRepo.FindWhere((c) => c.DATEDEBUT == congeTest.DATEDEBUT);
            Assert.AreEqual(reqConge1.Count(), 1); // Test si le cong� a bien �t� ajout� dans la base

            foreach (SALARI� sal in reqSalarie1)
            {
                _salarieRepo.Delete(sal);
            }
            _salarieRepo.Save();

            foreach (CONG� con in reqConge1)
            {
                _congeRepo.Delete(con);
            }
            _congeRepo.Save();
        }

        [TestMethod]
        public void TestConnexion()
        {
            SALARI� sal = _employeController.Connexion(salaireTest.LOGIN, "Test");
            Assert.AreEqual(sal.LOGIN, null); // Test si la connexion pour un utilisateur qui n'est pas dans la base retourne un r�sultat null

            SALARI� sal2 = _employeController.Connexion("AMaux", "Admin123");
            Assert.AreEqual(sal2.LOGIN, "AMaux"); // Test si la connexion pour un utilisateur existant retourne bien un salari� de la base
        }

        [TestMethod]
        public void TestRecupCongesPourSalarie()
        {
            //Assert.ThrowsException<Exception>(_employeController.RecupCongesPourSalarie(salaireTest.LOGIN)); //Test si l'exception est bien lev�e si aucun utilisateur de ce login existe

            Assert.AreEqual(_employeController.RecupCongesPourSalarie("AMaux"), 2); //Test si on r�cup�re bien le bon nombre de cong� pour un login sp�cifi�
        }
    }
}
