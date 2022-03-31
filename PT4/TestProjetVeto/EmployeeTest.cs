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
    public class EmployeeTest
    {
        public CONGÉ testHoliday;
        public SALARIÉ testSalary;

        [TestInitialize]
        public void TestInitialize()
        {
            testSalary = new SALARIÉ
            {
                DONNEES_PERSONNELLES = "Test",
                LOGIN = "Test",
                estAdmin = false,
            };

            testHoliday = new CONGÉ
            {
                ESTREGULIER = false,
                DATEDEBUT = new DateTime(2009, 3, 10, 10, 0, 0),
                DATEFIN = new DateTime(2009, 3, 17, 10, 0, 0)  
            };
        }

        [TestMethod]
        public void CreateEmployeeTest()
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

            var empController = new EmployesController(empRepo, holiRepo);

            //END OF DATA MOCK CREATION
            var employees = empRepo.FindAll();

            Assert.AreEqual(0, employees.Count()); // Test if the database is empty

            empController.CreerSalarie(testSalary.LOGIN, "Test", testSalary.DONNEES_PERSONNELLES);

            employees = empRepo.FindAll();
            Assert.AreEqual(1, employees.Count()); // Test if the function for creating an employee in the database works 

            Assert.ThrowsException<Exception>(() => empController.CreerSalarie(testSalary.LOGIN, "Test", testSalary.DONNEES_PERSONNELLES)); // Test if you cannot insert the same login twice
        }

        [TestMethod]
        public void TestPositionHolidays()
        {
            //DATA MOCK CREATION
            var data = new List<CONGÉ> { };
            var mockSet = Utils.CreateDbSet(data);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<CONGÉ>()).Returns(mockSet);

            var mockRepo = Utils.CreateMockRepo<SalarieRepository, SALARIÉ>(mockContext.Object);
            var empRepo = mockRepo.Object;

            var mockRepo2 = Utils.CreateMockRepo<CongeRepository, CONGÉ>(mockContext.Object);
            var holiRepo = mockRepo2.Object;

            var empController = new EmployesController(empRepo, holiRepo);
            //END OF DATA MOCK CREATION

            var holidays = holiRepo.FindAll();

            Assert.AreEqual(0, holidays.Count()); // Test if the database is empty

            empController.PositionnerConge(testSalary, testHoliday.DATEDEBUT, testHoliday.DATEFIN, testHoliday.ESTREGULIER);

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

            var empController = new EmployesController(empRepo, holiRepo);
            //END OF DATA MOCK CREATION

            Assert.IsNull(empController.Connexion(testSalary.LOGIN, "Test")); // Test if the connection for a user who is not in the database returns a null result

            empController.CreerSalarie(testSalary.LOGIN, "Test", testSalary.DONNEES_PERSONNELLES); // Add the test user

            SALARIÉ employee = empController.Connexion(testSalary.LOGIN, "Test");
            Assert.AreEqual(employee.LOGIN, "Test"); // Test if the connection for an existing user returns an employee from the database
        }
      
        
        [TestMethod]
        public void TestRecoverHolidayForEmployee()
        {
            //DATA MOCK CREATION
            var data = new List<SALARIÉ> { };
            var dataHoliday = new List<CONGÉ> { };
            var mockSet = Utils.CreateDbSet(data);
            var mockHoliday = Utils.CreateDbSet(dataHoliday);

            var mockContext = new Mock<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>();
            mockContext.Setup(c => c.Set<SALARIÉ>()).Returns(mockSet);
            mockContext.Setup(c => c.Set<CONGÉ>()).Returns(mockHoliday);

            var mockRepo = Utils.CreateMockRepo<SalarieRepository, SALARIÉ>(mockContext.Object);
            var empRepo = mockRepo.Object;

            var mockRepo2 = Utils.CreateMockRepo<CongeRepository, CONGÉ>(mockContext.Object);
            var holiRepo = mockRepo2.Object;

            var empController = new EmployesController(empRepo, holiRepo);
            //END OF DATA MOCK CREATION

            Assert.ThrowsException<Exception>(() => empController.RecupCongesPourSalarie(testSalary.LOGIN)); // Test if the exception is raised if no user of this login exists

            empController.CreerSalarie(testSalary.LOGIN, "Test", testSalary.DONNEES_PERSONNELLES); // Add the test user
            Assert.AreEqual(empController.RecupCongesPourSalarie("Test").Count(), 0); // Test if we get the right number of leave for a specified login
        }
        
    }
}
