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
        }

        [TestMethod]
        public void TestPositionHolidays()
        {
        }

    
        [TestMethod]
        public void TestConnection()
        {
        }
      
        
        [TestMethod]
        public void TestRecoverHolidayForEmployee()
        {
           
        }
        
    }
}
