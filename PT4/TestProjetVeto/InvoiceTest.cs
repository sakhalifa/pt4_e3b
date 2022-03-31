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
    public class InvoiceTest
    {
        public FACTURE invoiceTest;
        public CLIENT customerTest;

        [TestInitialize]
        public void TestInitialize()
        {
            customerTest = new CLIENT
            {
                NOMCLIENT = "Test",
                PRENOMCLIENT = "Test",
                NUMERO = "Test",
                EMAIL = "Test"
            };

            invoiceTest = new FACTURE
            {
                CLIENT = customerTest,
                MONTANT = 92,
                PRODUIT_VENDU = null
            };
        }

        [TestMethod]
        public void TestCreateInvoice()
        {
           
        }
    }
}
