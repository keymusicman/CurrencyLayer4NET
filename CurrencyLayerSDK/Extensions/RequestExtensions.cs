using System;
using System.Collections.Generic;
using System.Linq;
using static CurrencyLayer4NET.Infrastructure.Query.CLQueryBuilder;

namespace CurrencyLayer4NET.Extensions
{
    public static class RequestExtensions
    {
        private const string DateFormat = "yyyy-MM-dd";

        public static void AddAccessKey(this Dictionary<string, string> parameters, string accessKey)
        {
            if (parameters == null)
                return;

            parameters[KnownParameters.AccessKey] = accessKey;
        }

        public static void AddSourceCurrency(this Dictionary<string, string> parameters, string currency)
        {
            if (parameters == null || String.IsNullOrEmpty(currency))
                return;

            parameters[KnownParameters.SourceCurrency] = currency;
        }

        public static void AddCurrencies(this Dictionary<string, string> parameters, IEnumerable<string> currencies)
        {
            if (parameters == null || currencies == null)
                return;

            parameters[KnownParameters.Currencies] = String.Join(",", currencies.Where(q => !String.IsNullOrEmpty(q)));
        }

        public static void AddDate(this Dictionary<string, string> parameters, DateTime date)
        {
            if (parameters == null)
                return;

            AddDate(parameters, KnownParameters.Date, date);
        }

        public static void AddStartDate(this Dictionary<string, string> parameters, DateTime date)
        {
            if (parameters == null)
                return;

            AddDate(parameters, KnownParameters.StartDate, date);
        }

        public static void AddEndDate(this Dictionary<string, string> parameters, DateTime date)
        {
            if (parameters == null)
                return;

            AddDate(parameters, KnownParameters.EndDate, date);
        }

        private static void AddDate(this Dictionary<string, string> parameters, string name, DateTime date)
        {
            if (parameters == null)
                return;

            parameters[name] = date.ToString(DateFormat);
        }
    }
}
