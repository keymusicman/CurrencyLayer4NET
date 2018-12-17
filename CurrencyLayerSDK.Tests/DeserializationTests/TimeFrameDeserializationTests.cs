using CurrencyLayer4NET.Entities.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace CurrencyLayer4NET.Tests.DeserializationTests
{
    [TestClass]
    public class TimeFrameDeserializationTests
    {
        [TestMethod]
        public void TimeFrameDeserializationTest()
        {
            string responseString = @"
{
    ""success"": true,
    ""terms"": ""https://currencylayer.com/terms"",
    ""privacy"": ""https://currencylayer.com/privacy"",
    ""timeframe"": true,
    ""start_date"": ""2010-03-01"",
    ""end_date"": ""2010-04-01"",
    ""source"": ""USD"",
    ""quotes"": {
        ""2010-03-01"": {
            ""USDUSD"": 1,
            ""USDGBP"": 0.668525,
            ""USDEUR"": 0.738541
        },
        ""2010-03-02"": {
            ""USDUSD"": 1,
            ""USDGBP"": 0.668827,
            ""USDEUR"": 0.736145
        }
    }
}
";

            var key1 = new DateTime(2010, 03, 01);
            var key2 = new DateTime(2010, 03, 02);

            var response = JsonConvert.DeserializeObject<CLTimeFrameResponse>(responseString);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.StartDate, new DateTime(2010, 03, 01));
            Assert.AreEqual(response.EndDate, new DateTime(2010, 04, 01));
            Assert.AreEqual(response.Source, "USD");
            Assert.IsNotNull(response.Quotes);
            Assert.AreEqual(2, response.Quotes.Count);
            Assert.AreEqual(key1, response.Quotes.Keys.ElementAt(0));
            Assert.AreEqual(key2, response.Quotes.Keys.ElementAt(1));

            Assert.AreEqual(3, response.Quotes[key1].Count);
            Assert.IsTrue(response.Quotes[key1].ContainsKey("USDUSD"));
            Assert.IsTrue(response.Quotes[key1].ContainsKey("USDGBP"));
            Assert.AreEqual(1, response.Quotes[key1]["USDUSD"]);
            Assert.AreEqual(0.668525m, response.Quotes[key1]["USDGBP"]);

            Assert.AreEqual(3, response.Quotes[key2].Count);
        }
    }
}
