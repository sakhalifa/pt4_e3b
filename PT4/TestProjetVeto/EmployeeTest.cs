using Microsoft.VisualStudio.TestTools.UnitTesting;
using PT4;
using PT4.Model.dal;
using PT4.Controllers;
using Moq;
using System.Linq;
using System;
using PT4.Model.impl;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TestProjetVeto
{
    [TestClass]
    public class EmployeeTest
    {
        private CONGÉ testHoliday;
        private SALARIÉ testSalary;
        private SalarieRepository empRepo;
        private CongeRepository holiRepo;
        private SalarieController empController;

        [TestInitialize]
        public void TestInitialize()
        {
            testSalary = new SALARIÉ
            {
                DONNEES_PERSONNELLES = "Test",
                LOGIN = "Test",
                estAdmin = false
            };

            testHoliday = new CONGÉ
            {
                ESTREGULIER = false,
                DATEDEBUT = new DateTime(2009, 3, 10, 10, 0, 0),
                DATEFIN = new DateTime(2009, 3, 17, 10, 0, 0)
            };

            //DATA MOCK CREATION
            var data = new List<SALARIÉ> { };
            var data2 = new List<CONGÉ> { };
            var mockSet = Utils.CreateDbSet(data);
            var mockSet2 = Utils.CreateDbSet(data2);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<SALARIÉ>()).Returns(mockSet);
            mockContext.Setup(c => c.Set<CONGÉ>()).Returns(mockSet2);

            var mockRepo = Utils.CreateMockRepo<SalarieRepository, SALARIÉ>(mockContext.Object);

            mockRepo.Setup(m => m.FindById(It.IsAny<object[]>())).Returns<object[]>(o =>
            {
                int id = (int)o[0];
                return mockRepo.Object.FindWhere(s => s.IDCOMPTE == id).FirstOrDefault();
            });
            empRepo = mockRepo.Object;

            var mockRepo2 = Utils.CreateMockRepo<CongeRepository, CONGÉ>(mockContext.Object);
            holiRepo = mockRepo2.Object;


            empController = new SalarieController(empRepo, holiRepo);

            //END OF DATA MOCK CREATION
        }

        [TestMethod]
        public void CreateEmployeeAndChangePasswordTest()
        {
            var employees = empRepo.FindAll();

            Assert.AreEqual(0, employees.Count()); // Test if the database is empty

            empController.CreerSalarie(testSalary.LOGIN, "Test");

            employees = empRepo.FindAll();
            // Test if the function for creating an employee in the database works 
            Assert.AreEqual(1, employees.Count());

            // Test if you cannot insert the same login twice
            Assert.ThrowsException<ArgumentException>(() => empController.CreerSalarie(testSalary.LOGIN, "Test"));


            byte[] hashedPwd = PT4.Utils.Hash("Test");
            //Verify if the last password was 'Test'
            Assert.IsTrue(employees.First().MDP.SequenceEqual(hashedPwd));

            empController.ChangerMotDePasse(employees.First(), "NewPassword");

            hashedPwd = PT4.Utils.Hash("NewPassword");
            //Verify if the password has changed to 'NewPassword'
            Assert.IsTrue(employees.First().MDP.SequenceEqual(hashedPwd));

            hashedPwd = PT4.Utils.Hash("False");
            Assert.IsFalse(employees.First().MDP.SequenceEqual(hashedPwd));
        }

        [TestMethod]
        public void TestPositionHolidays()
        {
            var holidays = holiRepo.FindAll();

            Assert.AreEqual(0, holidays.Count()); // Test if the database is empty

            //Create employee
            empController.CreerSalarie(testSalary.LOGIN, "Test");

            empController.PositionnerConge(testSalary.IDCOMPTE, testHoliday.DATEDEBUT, testHoliday.DATEFIN, testHoliday.ESTREGULIER);

            holidays = holiRepo.FindAll();
            Assert.AreEqual(1, holidays.Count()); // Test if the function to position fillets in the database works 
        }


        [TestMethod]
        public void TestConnection()
        {
            //DATA MOCK CREATION
            var data = new List<SALARIÉ> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<SALARIÉ>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<SalarieRepository, SALARIÉ>(mockContext.Object);
            var empRepo = mockRepo.Object;

            var mockRepo2 = Utils.CreateMockRepo<CongeRepository, CONGÉ>(mockContext.Object);
            var holiRepo = mockRepo2.Object;

            var empMock = new Mock<SalarieController>(empRepo, holiRepo);
            //We must override the connection method because we should use SequenceEqual for the mock and not == 
            empMock.Setup(s => s.Connexion(It.IsAny<string>(), It.IsAny<string>())).Returns<string, string>((login, clearPwd) =>
            {
                byte[] hashedPwd = SHA256.Create().ComputeHash(new UTF8Encoding().GetBytes(clearPwd));
                SALARIÉ salarie = mockRepo.Object.FindWhere(s => s.LOGIN == login && s.MDP.SequenceEqual(hashedPwd)).FirstOrDefault();
                return salarie;
            });
            var empController = empMock.Object;
            //END OF DATA MOCK CREATION


            // Test if the connection for a user who is not in the database returns a null result
            Assert.IsNull(empController.Connexion(testSalary.LOGIN, "Test"));

            empController.CreerSalarie(testSalary.LOGIN, "Test"); // Add the test user

            SALARIÉ employee = empController.Connexion(testSalary.LOGIN, "Test");
            // Test if the connection for an existing user returns an employee from the database
            Assert.AreEqual(employee.LOGIN, "Test");
        }


        [TestMethod]
        public void TestRecoverHolidayForEmployee()
        {
            // Test if the exception is raised if no user of this login exists
            Assert.ThrowsException<ArgumentException>(() => empController.RecupCongesPourSalarie(testSalary.LOGIN));

            empController.CreerSalarie(testSalary.LOGIN, "Test"); // Add the test user
            // Test if we get the right number of leave for a specified login
            Assert.AreEqual(empController.RecupCongesPourSalarie("Test").Count(), 0);
        }

        [TestMethod]
        public void PersonnalDataTest()
        {
            var employees = empRepo.FindAll();
            Assert.AreEqual(0, employees.Count()); // Test if the database is empty

            empController.CreerSalarie(testSalary.LOGIN, "Test");

            empController.DonneesPersoSalarie(employees.First(), "New personnal data");

            Assert.AreEqual(employees.First().DONNEES_PERSONNELLES, "New personnal data");
        }
    }
}
