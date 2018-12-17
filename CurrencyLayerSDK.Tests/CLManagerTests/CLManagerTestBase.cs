using CurrencyLayer4NET.Entities.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyLayer4NET.Tests.CLManegerTests
{
    public abstract class CLManagerTestBase
    {
        protected ICLManager manager;

        [TestInitialize]
        public void Initialize()
        {
            /*
            
            GlobalConfiguration.Settings = new CLManagerSettings
            {
                LogRequestsAndResponses = true,
                FormatResponse = true
            };

            */

            manager = new CLManager(TestConfiguration.ApiAccessKey);
        }

        protected void AssertSuccess(CLResponse response)
        {
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }
    }
}