using CurrencyLayer4NET.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CurrencyLayer4NET.Tests.CLManegerTests
{
    [TestClass]
    public class RatesTests : CLManagerTestBase
    {
        [TestMethod]
        public void GetRates_Test()
        {
            var response = manager.GetRates();
            AssertSuccess(response);
            Assert.AreEqual("USD", response.Source);
            Assert.IsNotNull(response.Quotes);
        }

        [TestMethod]
        public void GetRates_SourceSwitch_Test()
        {
            if (TestConfiguration.Plan == Plan.Free) return;

            var response = manager.GetRates("CAD");

            AssertSuccess(response);
            Assert.AreEqual("CAD", response.Source);
            Assert.IsNotNull(response.Quotes);
        }

        [TestMethod]
        public void GetRates_TargetCurrencies_Test()
        {
            var response = manager.GetRates(new List<string>() { "CAD", "EUR" });

            AssertSuccess(response);
            Assert.AreEqual("USD", response.Source);
            Assert.IsNotNull(response.Quotes);
            Assert.AreEqual(2, response.Quotes.Count);
            Assert.IsTrue(response.Quotes.ContainsKey("USDCAD"));
            Assert.IsTrue(response.Quotes.ContainsKey("USDEUR"));
        }

        [TestMethod]
        public void GetRates_SourceSwitch_TargetCurrencies_Test()
        {
            if (TestConfiguration.Plan == Plan.Free) return;

            var response = manager.GetRates("CAD", new List<string>() { "EUR", "USD" });

            AssertSuccess(response);
            Assert.AreEqual("CAD", response.Source);
            Assert.IsNotNull(response.Quotes);
            Assert.AreEqual(2, response.Quotes.Count);
            Assert.IsTrue(response.Quotes.ContainsKey("CADEUR"));
            Assert.IsTrue(response.Quotes.ContainsKey("CADUSD"));
        }

        [TestMethod]
        [ExpectedException(typeof(UnsupportedCurrencyException))]
        public void GetRates_NotSupportedCurrency_Test()
        {
            manager.GetRates(new List<string> { "FZQ" });
        }
    }
}