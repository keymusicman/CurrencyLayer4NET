using CurrencyLayer4NET.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CurrencyLayer4NET.Tests.ExtensionsTests
{
    [TestClass]
    public class RequestExtensionsTests
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();

        [TestMethod]
        public void AddAccessKey_Test()
        {
            parameters.AddAccessKey("abc");

            Assert.IsTrue(parameters.ContainsKey("access_key"));
            Assert.AreEqual("abc", parameters["access_key"]);
        }

        [TestMethod]
        public void AddSourceCurrency_Test()
        {
            parameters.AddSourceCurrency("USD");

            Assert.IsTrue(parameters.ContainsKey("source"));
            Assert.AreEqual("USD", parameters["source"]);
        }

        [TestMethod]
        public void AddCurrencies_Test()
        {
            parameters.AddCurrencies(new[] { "USD", "EUR", "CAD" });

            Assert.IsTrue(parameters.ContainsKey("currencies"));
            Assert.AreEqual("USD,EUR,CAD", parameters["currencies"]);
        }

        [TestMethod]
        public void AddDate_Test()
        {
            parameters.AddDate(new DateTime(2001, 10, 15));

            Assert.IsTrue(parameters.ContainsKey("date"));
            Assert.AreEqual("2001-10-15", parameters["date"]);
        }

        [TestMethod]
        public void AddDateNamed_Test()
        {
            parameters.AddDate("test_date", new DateTime(2011, 05, 15));

            Assert.IsTrue(parameters.ContainsKey("test_date"));
            Assert.AreEqual("2011-05-15", parameters["test_date"]);
        }
    }
}