using CurrencyLayer4NET.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyLayer4NET.Tests
{
    [TestClass]
    public class CLClientTests
    {
        private ICLClient client;

        [TestInitialize]
        public void Initialize()
        {
            client = new CLClient(TestConfiguration.ApiAccessKey);
        }

        [TestMethod]
        [ExpectedException(typeof(CLException))]
        public void WrongTokenExceptionTest()
        {
            client = new CLClient("FAKE STRING");

            client.GetCurrencies();
        }

        [TestMethod]
        public void GetCurrenciesTest()
        {
            var currencies = client.GetCurrencies();

            Assert.IsNotNull(currencies);
            Assert.IsTrue(currencies.Any(q => q.Code == "USD"));
        }

        [TestMethod]
        public void GetUsdCurrencyTest()
        {
            var rates = client.GetRates(new List<string> { "USD" });

            Assert.IsNotNull(rates);
            Assert.AreEqual(1, rates.Count());
            Assert.AreEqual("USD", rates.ToList()[0].SourceCurrency.Code);
            Assert.AreEqual("USD", rates.ToList()[0].TargetCurrency.Code);
            Assert.AreEqual(1m, rates.ToList()[0].Rate);
        }

        [TestMethod]
        public void GetNonUsdCurrencyTest()
        {
            var rates = client.GetRates(new List<string> { "EUR" });

            Assert.IsNotNull(rates);
            Assert.AreEqual(1, rates.Count());
            Assert.AreEqual("USD", rates.ToList()[0].SourceCurrency.Code);
            Assert.AreEqual("EUR", rates.ToList()[0].TargetCurrency.Code);
            Assert.AreNotEqual(1m, rates.ToList()[0].Rate); // they are not equal in your time, aren't they? =)
        }

        [TestMethod]
        [ExpectedException(typeof(UnsupportedCurrencyException))]
        public void GetWrongCurrencyTest()
        {
            var rates = client.GetRates(new List<string> { "PSD" });

            Assert.IsNotNull(rates);
            Assert.AreEqual(0, rates.Count());
            Assert.AreEqual("USD", rates.ToList()[0].SourceCurrency.Code);
            Assert.AreEqual("USD", rates.ToList()[0].TargetCurrency.Code);
            Assert.AreEqual(1m, rates.ToList()[0].Rate);
        }

        [TestMethod]
        [ExpectedException(typeof(SubscriptionLimitationException))]
        public void GetByAnotherSourceCurrencyTest()
        {
            if (TestConfiguration.Plan != Plan.Free)
                throw new SubscriptionLimitationException(0, "");

            client.GetRates("EUR");
        }
    }
}