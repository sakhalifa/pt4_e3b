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
    public class TestEmploye
    {
        public CONG� congeTest;
        public SALARI� salaireTest;

        [TestInitialize]
        public void TestInitialize()
        {
            salaireTest = new SALARI�
            {
                DONNEES_PERSONNELLES = "Test",
                LOGIN = "Test",
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
        public void TestCreerSalarie()
        {
            //CREATION DES DONNES MOCK
            var data = new List<SALARI�> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<SALARI�>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<SalarieRepository, SALARI�>(mockContext.Object);
            var salRepo = mockRepo.Object;

            var mockRepo2 = Utils.CreateMockRepo<CongeRepository, CONG�>(mockContext.Object);
            var conRepo = mockRepo2.Object;

            var empController = new EmployesController(salRepo, conRepo);

            //FIN DE CREATION DONNEES MOCK
            var salarie = salRepo.FindAll();

            Assert.AreEqual(0, salarie.Count()); //Test si la base est bien vide

            empController.CreerSalarie(salaireTest.LOGIN, "Test", salaireTest.DONNEES_PERSONNELLES);

            salarie = salRepo.FindAll();
            Assert.AreEqual(1, salarie.Count()); // Test si la fonction de cr�ation d'un salari� dans la base marche 

            //Assert.ThrowsException<ArgumentException>(() = empController.CreerSalarie(salaireTest.LOGIN, "Test", salaireTest.DONNEES_PERSONNELLES)); // Test si l'on ne peut pas ins�rer deux fois le m�me login 
        }

        [TestMethod]
        public void TestPositionnerConge()
        {
            //CREATION DES DONNES MOCK
            var data = new List<CONG�> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<CONG�>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<SalarieRepository, SALARI�>(mockContext.Object);
            var salRepo = mockRepo.Object;

            var mockRepo2 = Utils.CreateMockRepo<CongeRepository, CONG�>(mockContext.Object);
            var conRepo = mockRepo2.Object;

            var empController = new EmployesController(salRepo, conRepo);

            //FIN DE CREATION DONNEES MOCK
            var conge = conRepo.FindAll();

            Assert.AreEqual(0, conge.Count()); //Test si la base est bien vide

            empController.PositionnerConge(salaireTest, congeTest.DATEDEBUT, congeTest.DATEFIN, congeTest.ESTREGULIER);

            conge = conRepo.FindAll();
            Assert.AreEqual(1, conge.Count()); // Test si la fonction de positionner des cong�s dans la base marche 
        }

    
        [TestMethod]
        public void TestConnexion()
        {
            //CREATION DES DONNES MOCK
            var data = new List<SALARI�> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<SALARI�>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<SalarieRepository, SALARI�>(mockContext.Object);
            var salRepo = mockRepo.Object;

            var mockRepo2 = Utils.CreateMockRepo<CongeRepository, CONG�>(mockContext.Object);
            var conRepo = mockRepo2.Object;

            var empController = new EmployesController(salRepo, conRepo);

            Assert.IsNull(empController.Connexion(salaireTest.LOGIN, "Test")); // Test si la connexion pour un utilisateur qui n'est pas dans la base retourne un r�sultat null

            empController.CreerSalarie(salaireTest.LOGIN, "Test", salaireTest.DONNEES_PERSONNELLES); //On ajoute l'utilisateur test

            SALARI� sal = empController.Connexion(salaireTest.LOGIN, "Test");
            Assert.AreEqual(sal.LOGIN, "Test"); // Test si la connexion pour un utilisateur existant retourne bien un salari� de la base
        }
      
        
        [TestMethod]
        public void TestRecupCongesPourSalarie()
        {
            //CREATION DES DONNES MOCK
            var data = new List<SALARI�> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<SALARI�>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<SalarieRepository, SALARI�>(mockContext.Object);
            var salRepo = mockRepo.Object;

            var mockRepo2 = Utils.CreateMockRepo<CongeRepository, CONG�>(mockContext.Object);
            var conRepo = mockRepo2.Object;

            var empController = new EmployesController(salRepo, conRepo);

            //Assert.ThrowsException<Exception>(_employeController.RecupCongesPourSalarie(salaireTest.LOGIN)); //Test si l'exception est bien lev�e si aucun utilisateur de ce login existe

            empController.CreerSalarie(salaireTest.LOGIN, "Test", salaireTest.DONNEES_PERSONNELLES); //On ajoute l'utilisateur test
            //Assert.AreEqual(empController.RecupCongesPourSalarie("Test").Count(), 0); //Test si on r�cup�re bien le bon nombre de cong� pour un login sp�cifi�
        }
        
    }
}
