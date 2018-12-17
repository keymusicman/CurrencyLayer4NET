using CurrencyLayer4NET.Entities.Response;
using CurrencyLayer4NET.Infrastructure;
using CurrencyLayer4NET.Infrastructure.Query;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyLayer4NET.Tests.InfrastructureTests
{
    [TestClass]
    public class QueryBuilderTests
    {
        [TestMethod]
        public void SimpleQuery_Test()
        {
            CLManagerSettings settings = new CLManagerSettings
            {
                LogRequestsAndResponses = true,
                FormatResponse = true
            };

            string response = CLQueryBuilder.
                Create(Endpoints.CURRENCIES).
                WithSettings(settings).
                GetResponse();

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void QuotesQuery_Test()
        {
            CLQuotesResponse response = CLQueryBuilder.
                Create(Endpoints.RATES).
                SetAccessKey(TestConfiguration.ApiAccessKey).
                GetResult<CLQuotesResponse>();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public void CallbackFunctionFeature_Test()
        {
            CLManagerSettings settings = new CLManagerSettings
            {
                LogRequestsAndResponses = true,
                FormatResponse = true
            };

            string response = CLQueryBuilder.
                Create(Endpoints.CURRENCIES).
                AddParameter("callback", "test_callback").
                WithSettings(settings).
                GetResponse();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Contains("test_callback"));
        }
    }
}
