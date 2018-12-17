using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace CurrencyLayer4NET.Entities.Response
{
    public class CLConvertInfo
    {
        /// <summary>
        /// Returns the exact date and time the exchange rates were collected.
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// The exchange rate used for the conversion.
        /// </summary>
        public decimal Quote { get; set; }
    }
}