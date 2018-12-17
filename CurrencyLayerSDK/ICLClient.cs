using CurrencyLayer4NET.Entities;
using System;
using System.Collections.Generic;

namespace CurrencyLayer4NET
{
    public interface ICLClient
    {
        IEnumerable<Quote> GetRates();
        IEnumerable<Quote> GetRates(Currency sourceCurrency);
        IEnumerable<Quote> GetRates(string sourceCurrency);
        IEnumerable<Quote> GetRates(Currency sourceCurrency, IEnumerable<Currency> currencies);
        IEnumerable<Quote> GetRates(string sourceCurrency, IEnumerable<string> currencies);
        IEnumerable<Quote> GetRates(IEnumerable<Currency> currencies);
        IEnumerable<Quote> GetRates(IEnumerable<string> currencies);

        IEnumerable<Quote> GetHistoricalRates(DateTime date);
        IEnumerable<Quote> GetHistoricalRates(DateTime date, Currency sourceCurrency);
        IEnumerable<Quote> GetHistoricalRates(DateTime date, string sourceCurrency);
        IEnumerable<Quote> GetHistoricalRates(DateTime date, Currency sourceCurrency, IEnumerable<Currency> currencies);
        IEnumerable<Quote> GetHistoricalRates(DateTime date, string sourceCurrency, IEnumerable<string> currencies);
        IEnumerable<Quote> GetHistoricalRates(DateTime date, IEnumerable<Currency> currencies);
        IEnumerable<Quote> GetHistoricalRates(DateTime date, IEnumerable<string> currencies);

        IEnumerable<Currency> GetCurrencies();
    }
}