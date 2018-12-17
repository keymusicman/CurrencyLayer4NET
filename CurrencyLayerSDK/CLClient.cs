using CurrencyLayer4NET.Entities;
using CurrencyLayer4NET.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyLayer4NET
{
    public class CLClient : ICLClient
    {
        private ICLManager currencyLayoutManager;

        #region Ctor
        public CLClient(String accessToken)
        {
            currencyLayoutManager = new CLManager(accessToken);
        }
        #endregion

        #region ICLClient Implementation

        #region Currencies list
        public IEnumerable<Currency> GetCurrencies() => currencyLayoutManager.GetCurrencies().ToCurrencies();
        #endregion

        #region Rates
        public IEnumerable<Quote> GetRates() =>
            GetRates((string)null, null);

        public IEnumerable<Quote> GetRates(Currency sourceCurrency) =>
            GetRates(sourceCurrency.Code, null);

        public IEnumerable<Quote> GetRates(string sourceCurrency) =>
            GetRates(sourceCurrency, null);

        public IEnumerable<Quote> GetRates(Currency sourceCurrency, IEnumerable<Currency> currencies) =>
            GetRates(sourceCurrency.Code, currencies.Select(q => q.Code));

        public IEnumerable<Quote> GetRates(string sourceCurrency, IEnumerable<string> currencies) =>
            currencyLayoutManager.GetRates(sourceCurrency, currencies).ToQuotes();

        public IEnumerable<Quote> GetRates(IEnumerable<Currency> currencies) =>
            GetRates(null, currencies.Select(q => q.Code));

        public IEnumerable<Quote> GetRates(IEnumerable<string> currencies) =>
            GetRates(null, currencies);
        #endregion

        #region Historical rates
        public IEnumerable<Quote> GetHistoricalRates(DateTime date) =>
            GetHistoricalRates(date, (string)null, null);

        public IEnumerable<Quote> GetHistoricalRates(DateTime date, Currency sourceCurrency) =>
            GetHistoricalRates(date, sourceCurrency.Code, null);

        public IEnumerable<Quote> GetHistoricalRates(DateTime date, string sourceCurrency) =>
            GetHistoricalRates(date, sourceCurrency, null);

        public IEnumerable<Quote> GetHistoricalRates(DateTime date, Currency sourceCurrency, IEnumerable<Currency> currencies) =>
            GetHistoricalRates(date, sourceCurrency.Code, currencies.Select(q => q.Code));

        public IEnumerable<Quote> GetHistoricalRates(DateTime date, IEnumerable<Currency> currencies) =>
            GetHistoricalRates(date, null, currencies.Select(q => q.Code));

        public IEnumerable<Quote> GetHistoricalRates(DateTime date, IEnumerable<string> currencies) =>
            GetHistoricalRates(date, null, currencies);

        public IEnumerable<Quote> GetHistoricalRates(DateTime date, string sourceCurrency, IEnumerable<string> currencies) =>
            currencyLayoutManager.GetHistoricalRates(date, sourceCurrency, currencies).ToHistoricalQuotes();
        #endregion

        #endregion
    }
}