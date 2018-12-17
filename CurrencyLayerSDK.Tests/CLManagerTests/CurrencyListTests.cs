using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyLayer4NET.Tests.CLManegerTests
{
    [TestClass]
    public class CurrencyListTests : CLManagerTestBase
    {
        [TestMethod]
        public void GetCurrencies_Test()
        {
            var response = manager.GetCurrencies();

            AssertSuccess(response);
            Assert.IsNotNull(response.Currencies);
        }
    }
}