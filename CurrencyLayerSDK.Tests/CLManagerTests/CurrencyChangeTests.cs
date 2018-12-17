using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CurrencyLayer4NET.Tests.CLManegerTests
{
    [TestClass]
    public class CurrencyChangeTests : CLManagerTestBase
    {
        DateTime StartDate = DateTime.Now.AddMonths(-1).Date;
        DateTime EndDate = DateTime.Now.AddDays(-1).Date;

        [TestMethod]
        public void GetCurrencyChange_Test()
        {
            if (TestConfiguration.Plan < Plan.Enterprise) return;

            var response = manager.GetCurrencyChange(StartDate, EndDate);

            AssertSuccess(response);
            Assert.AreEqual(StartDate, response.StartDate);
            Assert.AreEqual(EndDate, response.EndDate);
            Assert.AreEqual("USD", response.Source);
            Assert.IsNotNull(response.Quotes);
            Assert.IsTrue(response.Quotes.Count > 0);
        }

        [TestMethod]
        public void GetCurrencyChange_CurrencySwitch_Test()
        {
            if (TestConfiguration.Plan < Plan.Enterprise) return;

            var response = manager.GetCurrencyChange(StartDate, EndDate, "EUR");

            AssertSuccess(response);
            Assert.AreEqual(StartDate, response.StartDate);
            Assert.AreEqual(EndDate, response.EndDate);
            Assert.AreEqual("EUR", response.Source);
            Assert.IsNotNull(response.Quotes);
            Assert.IsTrue(response.Quotes.Count > 0);
        }

        [TestMethod]
        public void GetCurrencyChange_TargetCurrencies_Test()
        {
            if (TestConfiguration.Plan < Plan.Enterprise) return;

            var response = manager.GetCurrencyChange(StartDate, EndDate, new[] { "GBP", "AUD", "CAD" });

            AssertSuccess(response);
            Assert.AreEqual(StartDate, response.StartDate);
            Assert.AreEqual(EndDate, response.EndDate);
            Assert.AreEqual("USD", response.Source);
            Assert.IsNotNull(response.Quotes);
            Assert.AreEqual(3, response.Quotes.Count);
        }

        [TestMethod]
        public void GetCurrencyChange_CurrencySwitch_TargetCurrencies_Test()
        {
            if (TestConfiguration.Plan < Plan.Enterprise) return;

            var response = manager.GetCurrencyChange(StartDate, EndDate, "EUR", new[] { "GBP", "AUD", "CAD" });

            AssertSuccess(response);
            Assert.AreEqual(StartDate, response.StartDate);
            Assert.AreEqual(EndDate, response.EndDate);
            Assert.AreEqual("EUR", response.Source);
            Assert.IsNotNull(response.Quotes);
            Assert.AreEqual(3, response.Quotes.Count);
        }
    }
}