using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CurrencyLayer4NET.Entities.Response
{
    public class CLTimeFrameResponse : CLResponse
    {
        /// <summary>
        /// Should be true to confirm your request to the Time-Frame endpoint.
        /// </summary>
        [DefaultValue(false)]
        public bool TimeFrame { get; set; }
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
        /// The quotes object will contain one sub-object with exchange rate data per day in your time frame.
        /// </summary>
        public Dictionary<DateTime, Dictionary<string, decimal>> Quotes { get; set; }
    }
}