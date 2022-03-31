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
        public CLIENT testCustomer;
        public ANIMAL testAnimal;

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
                IDANIMAL = 2,
                CLIENT = testCustomer,
                NOMESPECE = "chat",
                NOMRACE = "tigre",
                NOMANIMAL = "Test",
                DATENAISSANCE = new DateTime(2009, 3, 10, 10, 0, 0),
                TAILLE = 18,
                POIDS = 7
            };
        }

        [TestMethod]
        public void CreateAnimalTest()
        {
            

        }
    }
}
