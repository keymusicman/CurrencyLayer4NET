using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CurrencyLayer4NET.Tests.CLManegerTests
{
    [TestClass]
    public class TimeFrameTests : CLManagerTestBase
    {
        DateTime StartDate = DateTime.Now.AddMonths(-1).Date;
        DateTime EndDate = DateTime.Now.AddDays(-1).Date;

        [TestMethod]
        public void GetTimeFrame_Test()
        {
            if (TestConfiguration.Plan < Plan.Professional)
                return;

            var response = manager.GetTimeFrameRates(StartDate, EndDate);

            AssertSuccess(response);

            Assert.AreEqual(response.StartDate, StartDate);
            Assert.AreEqual(response.EndDate, EndDate);
            Assert.AreEqual(response.Source, "USD");
            Assert.IsNotNull(response.Quotes);
        }

        [TestMethod]
        public void GetTimeFrame_SourceSwitch_Test()
        {
            if (TestConfiguration.Plan < Plan.Professional)
                return;

            var response = manager.GetTimeFrameRates(StartDate, EndDate, "EUR");

            AssertSuccess(response);

            Assert.AreEqual(response.StartDate, StartDate);
            Assert.AreEqual(response.EndDate, EndDate);
            Assert.AreEqual(response.Source, "EUR");
            Assert.IsNotNull(response.Quotes);
        }

        [TestMethod]
        public void GetTimeFrame_TargetCurrencies_Test()
        {
            if (TestConfiguration.Plan < Plan.Professional)
                return;

            var response = manager.GetTimeFrameRates(StartDate, EndDate, new[] { "CAD", "RUB" });

            AssertSuccess(response);

            Assert.AreEqual(response.StartDate, StartDate);
            Assert.AreEqual(response.EndDate, EndDate);
            Assert.AreEqual(response.Source, "USD");
            Assert.IsNotNull(response.Quotes);
            // as we requested only two currencies:
            Assert.IsTrue(!response.Quotes.Any(q => q.Value.Count != 2));
        }

        [TestMethod]
        public void GetTimeFrame_SourceSwitch_TargetCurrencies_Test()
        {
            if (TestConfiguration.Plan < Plan.Professional)
                return;

            var response = manager.GetTimeFrameRates(StartDate, EndDate, "GBP", new[] { "GBP", "EUR", "USD" });

            AssertSuccess(response);

            Assert.AreEqual(response.StartDate, StartDate);
            Assert.AreEqual(response.EndDate, EndDate);
            Assert.AreEqual(response.Source, "GBP");
            Assert.IsNotNull(response.Quotes);
            // as we requested only three currencies:
            Assert.IsTrue(!response.Quotes.Any(q => q.Value.Count != 3));
        }
    }
}