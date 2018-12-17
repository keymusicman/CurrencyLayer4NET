using CurrencyLayer4NET.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CurrencyLayer4NET.Tests.CLManegerTests
{
    [TestClass]
    public class HistoricalRatesTests : CLManagerTestBase
    {
        readonly DateTime YESTERDAY = DateTime.Now.AddDays(-1).Date;

        [TestMethod]
        public void GetHistoricalRates_Test()
        {
            var response = manager.GetHistoricalRates(YESTERDAY);

            AssertSuccess(response);
            Assert.IsTrue(response.Historical);
            Assert.AreEqual(YESTERDAY, response.Date);
            Assert.AreEqual("USD", response.Source);
        }

        [TestMethod]
        public void GetHistoricalRates_SourceSwitch_Test()
        {
            if (TestConfiguration.Plan == Plan.Free) return;

            var response = manager.GetHistoricalRates(YESTERDAY, "CAD");

            AssertSuccess(response);
            Assert.IsTrue(response.Historical);
            Assert.AreEqual(YESTERDAY, response.Date);
            Assert.AreEqual("CAD", response.Source);
            Assert.IsNotNull(response.Quotes);
        }

        [TestMethod]
        public void GetHistoricalRates_TargetCurrencies_Test()
        {
            var response = manager.GetHistoricalRates(YESTERDAY, new List<string>() { "CAD", "EUR" });

            AssertSuccess(response);
            Assert.IsTrue(response.Historical);
            Assert.AreEqual(YESTERDAY, response.Date);
            Assert.AreEqual("USD", response.Source);
            Assert.IsNotNull(response.Quotes);
            Assert.AreEqual(2, response.Quotes.Count);
            Assert.IsTrue(response.Quotes.ContainsKey("USDCAD"));
            Assert.IsTrue(response.Quotes.ContainsKey("USDEUR"));
        }

        [TestMethod]
        public void GetHistoricalRates_SourceSwitch_TargetCurrencies_Test()
        {
            if (TestConfiguration.Plan == Plan.Free) return;

            var response = manager.GetHistoricalRates(YESTERDAY, "CAD", new List<string>() { "EUR", "USD" });

            AssertSuccess(response);
            Assert.IsTrue(response.Historical);
            Assert.AreEqual(YESTERDAY, response.Date);
            Assert.AreEqual("CAD", response.Source);
            Assert.IsNotNull(response.Quotes);
            Assert.AreEqual(2, response.Quotes.Count);
            Assert.IsTrue(response.Quotes.ContainsKey("CADEUR"));
            Assert.IsTrue(response.Quotes.ContainsKey("CADUSD"));
        }

        [TestMethod]
        [ExpectedException(typeof(UnsupportedCurrencyException))]
        public void GetHistoricalRates_NotSupportedCurrency_Test()
        {
            manager.GetHistoricalRates(YESTERDAY, new List<string> { "FZQ" });
        }
    }
}