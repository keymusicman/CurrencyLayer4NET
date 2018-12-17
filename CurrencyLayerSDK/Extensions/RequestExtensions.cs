using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyLayer4NET.Extensions
{
    public static class RequestExtensions
    {
        public static void AddAccessKey(this Dictionary<string, string> parameters, string accessKey)
        {
            if (parameters == null)
                return;

            parameters["access_key"] = accessKey;
        }

        public static void AddSourceCurrency(this Dictionary<string, string> parameters, string currency)
        {
            if (parameters == null || String.IsNullOrEmpty(currency))
                return;

            parameters["source"] = currency;
        }

        public static void AddCurrencies(this Dictionary<string, string> parameters, IEnumerable<string> currencies)
        {
            if (parameters == null || currencies == null)
                return;

            parameters["currencies"] = String.Join(",", currencies.Where(q => !String.IsNullOrEmpty(q)));
        }

        public static void AddDate(this Dictionary<string, string> parameters, DateTime date)
        {
            if (parameters == null)
                return;

            AddDate(parameters, "date", date);
        }

        public static void AddDate(this Dictionary<string, string> parameters, string name, DateTime date)
        {
            if (parameters == null)
                return;

            parameters[name] = date.ToString("yyyy-MM-dd");
        }
    }
}
