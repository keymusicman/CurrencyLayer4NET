using Newtonsoft.Json;

namespace CurrencyLayer4NET.Entities.Response
{
    public class CLCurrencyChange
    {
        /// <summary>
        /// The respective currency's exchange rate at the beginning of the specified period.
        /// </summary>
        [JsonProperty("start_rate")]
        public decimal StartRate { get; set; }
        /// <summary>
        /// The respective currency's exchange rate at the end of the specified period.
        /// </summary>
        [JsonProperty("end_rate")]
        public decimal EndRate { get; set; }
        /// <summary>
        /// The margin between the currency's StartRate and EndRate.
        /// </summary>
        public decimal Change { get; set; }
        /// <summary>
        /// The currency's percentage change within the specified time frame.
        /// </summary>
        [JsonProperty("change_pct")]
        public decimal ChangePercent { get; set; }
    }
}