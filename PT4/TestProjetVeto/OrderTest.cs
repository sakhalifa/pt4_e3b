using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PT4;
using PT4.Controllers;
using PT4.Model.impl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProjetVeto
{
    [TestClass]
    public class OrderTest
    {
        public ORDONNANCE ordonnanceTest;
        public SOIN careTest;
        public ANIMAL animalTest;
        public CLIENT customerTest;

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod]
        public void TestCreateOrder()
        {
        }
    }
}
