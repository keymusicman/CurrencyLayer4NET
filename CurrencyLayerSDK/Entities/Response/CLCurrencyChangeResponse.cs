using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CurrencyLayer4NET.Entities.Response
{
    public class CLCurrencyChangeResponse : CLResponse
    {
        /// <summary>
        /// Should true to confirm your request to the Currency-Change endpoint
        /// </summary>
        public bool Change { get; set; }
        /// <summary>
        /// The specified start date
        /// </summary>
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// The specified end date
        /// </summary>
        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }
        /// <summary>
        /// The currency to which all exchange rates are relative. (default: USD)
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// Quotes for specified currencies and time frame. The key is "<SourceCurrency><TargetCurrency>" (example - "USDEUR") and value if CLCurrencyChange object
        /// </summary>
        public Dictionary<string, CLCurrencyChange> Quotes { get; set; }
    }
}
