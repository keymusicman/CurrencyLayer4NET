using CurrencyLayer4NET.Entities;
using CurrencyLayer4NET.Entities.Response;
using CurrencyLayer4NET.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyLayer4NET.Extensions
{
    public static class CLResponseExtensions
    {
        public static IEnumerable<Quote> ToQuotes(this CLQuotesResponse response)
        {
            return response.Quotes.Select(q =>
            {
                string targetCurrency = q.Key.Substring(3);

                return new Quote()
                {
                    SourceCurrency = Currency.FromCode(response.Source),
                    TargetCurrency = Currency.FromCode(targetCurrency),
                    Rate = q.Value
                };
            });
        }

        public static IEnumerable<Quote> ToHistoricalQuotes(this CLQuotesResponse response)
        {
            if (!response.Historical)
            {
                throw new Exception("The specified response is not historical");
            }

            return response.Quotes.Select(q =>
            {
                string targetCurrency = q.Key.Substring(3);

                return new HistoricalQuote()
                {
                    SourceCurrency = Currency.FromCode(response.Source),
                    TargetCurrency = Currency.FromCode(targetCurrency),
                    // for historical response date always should be set. The case when Date has no value should be considered as bug
                    Date = response.Date.Value,
                    Rate = q.Value
                };
            });
        }

        public static IEnumerable<Currency> ToCurrencies(this CLCurrenciesResponse response)
        {
            return response.Currencies.Select(q => new Currency(q.Key, q.Value));
        }
    }

    internal static class CLResponseExtensionsInternal
    {
        public static void ThrowIfError(this CLResponse response)
        {
            if (!response.Success)
            {
                throw CLException.FromCode(response.Error.Code, response.Error.Info);
            }
        }
    }
}