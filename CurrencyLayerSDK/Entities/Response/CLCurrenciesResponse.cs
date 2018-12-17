using System.Collections.Generic;

namespace CurrencyLayer4NET.Entities.Response
{
    public class CLCurrenciesResponse : CLResponse
    {
        /// <summary>
        /// A full list of supported currencies. Key is 3-letter currency code and value is currency name
        /// </summary>
        public Dictionary<string, string> Currencies { get; set; }
    }
}