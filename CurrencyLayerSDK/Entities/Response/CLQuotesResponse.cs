using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CurrencyLayer4NET.Entities.Response
{
    public class CLQuotesResponse : CLResponse
    {
        /// <summary>
        /// Returns the exact date and time the exchange rates were collected.
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Returns the currency to which all exchange rates are relative. (default: USD)
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// True if you request historical rates
        /// </summary>
        [DefaultValue(false)]
        public bool Historical { get; set; }
        /// <summary>
        /// Date for historical rates. Will be null if you query real-time quotes
        /// </summary>
        public DateTime? Date { get; set; }
        /// <summary>
        /// Quotes for currencies. The key is currencies pair in format "<Source><Target>" (for example, "USDCAD" for usd to cad quote) and the value is the quote
        /// </summary>
        public Dictionary<string, decimal> Quotes { get; set; }
    }
}