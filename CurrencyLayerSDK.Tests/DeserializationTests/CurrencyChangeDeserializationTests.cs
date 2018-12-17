using CurrencyLayer4NET.Entities.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace CurrencyLayer4NET.Tests.DeserializationTests
{
    [TestClass]
    public class CurrencyChangeDeserializationTests
    {
        [TestMethod]
        public void CurrencyChangeDeserializationTest()
        {
            string responseString = @"
{
    ""success"": true,
    ""terms"": ""https://currencylayer.com/terms"",
    ""privacy"": ""https://currencylayer.com/privacy"",
    ""change"": true,
    ""start_date"": ""2005-01-01"",
    ""end_date"": ""2010-01-01"",
    ""source"": ""USD"",
    ""quotes"": {
        ""USDAUD"": {
            ""start_rate"": 1.281236,
            ""end_rate"": 1.108609,
            ""change"": -0.1726,
            ""change_pct"": -13.4735
        },
        ""USDEUR"": {
            ""start_rate"": 0.73618,
            ""end_rate"": 0.697253,
            ""change"": -0.0389,
            ""change_pct"": -5.2877
        },
        ""USDMXN"":{
            ""start_rate"": 11.149362,
            ""end_rate"": 13.108757,
            ""change"": 1.9594,
            ""change_pct"": 17.5741
        }
    }
}
";

            var response = JsonConvert.DeserializeObject<CLCurrencyChangeResponse>(responseString);

            var key1 = new DateTime(2005, 01, 01);
            var key2 = new DateTime(2010, 01, 01);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Change);
            Assert.AreEqual(key1, response.StartDate);
            Assert.AreEqual(key2, response.EndDate);
            Assert.AreEqual("USD", response.Source);
            Assert.AreEqual(3, response.Quotes.Count);
            Assert.IsTrue(response.Quotes.ContainsKey("USDAUD"));
            Assert.IsTrue(response.Quotes.ContainsKey("USDEUR"));
            Assert.IsTrue(response.Quotes.ContainsKey("USDMXN"));

            Assert.AreEqual(0.73618m, response.Quotes["USDEUR"].StartRate);
            Assert.AreEqual(0.697253m, response.Quotes["USDEUR"].EndRate);
            Assert.AreEqual(-0.0389m, response.Quotes["USDEUR"].Change);
            Assert.AreEqual(-5.2877m, response.Quotes["USDEUR"].ChangePercent);
        }
    }
}