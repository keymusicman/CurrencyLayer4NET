using CurrencyLayer4NET.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CurrencyLayer4NET.Tests.CLManegerTests
{
    [TestClass]
    public class PlanLimitationTests : CLManagerTestBase
    {
        [TestMethod]
        [ExpectedException(typeof(SubscriptionLimitationException))]
        public void GetRates_Switch_Limitation_Test()
        {
            if (TestConfiguration.Plan != Plan.Free)
                ThrowFakeException();

            manager.GetRates("EUR");
        }

        [TestMethod]
        [ExpectedException(typeof(SubscriptionLimitationException))]
        public void Convert_Limitation_Test()
        {
            if (TestConfiguration.Plan != Plan.Free)
                ThrowFakeException();

            manager.Convert("USD", "CAD", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(SubscriptionLimitationException))]
        public void TimeFrame_Limitation_Test()
        {
            if (TestConfiguration.Plan >= Plan.Professional)
                ThrowFakeException();

            manager.GetTimeFrameRates(DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-3));
        }

        private void ThrowFakeException()
        {
            throw new SubscriptionLimitationException(0, ""); // fake exception for test not to fail if test plan is not Free
        }
    }
}