using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CurrencyLayer4NET.Tests.CLManegerTests
{
    [TestClass]
    public class ConvertTests : CLManagerTestBase
    {
        readonly DateTime YESTERDAY = DateTime.Now.AddDays(-1).Date;

        [TestMethod]
        public void Convert_Test()
        {
            if (TestConfiguration.Plan == Plan.Free) return;

            var response = manager.Convert("USD", "CAD", 10);

            AssertSuccess(response);
            Assert.IsNotNull(response.Query);

            Assert.AreEqual("USD", response.Query.From);
            Assert.AreEqual("CAD", response.Query.To);
            Assert.AreEqual(10, response.Query.Amount);

            Assert.IsNotNull(response.Info);
            Assert.IsFalse(response.Historical);
        }

        [TestMethod]
        public void Convert_Historical_Test()
        {
            if (TestConfiguration.Plan == Plan.Free) return;

            var response = manager.Convert("USD", "CAD", 10, YESTERDAY);

            AssertSuccess(response);
            Assert.IsNotNull(response.Query);

            Assert.AreEqual("USD", response.Query.From);
            Assert.AreEqual("CAD", response.Query.To);
            Assert.AreEqual(10, response.Query.Amount);

            Assert.IsNotNull(response.Info);
            Assert.IsTrue(response.Historical);
            Assert.AreEqual(YESTERDAY, response.Date);
        }
    }
}
