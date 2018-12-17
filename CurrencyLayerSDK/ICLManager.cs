using CurrencyLayer4NET.Entities.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyLayer4NET
{
    /// <summary>
    /// Low-level interface for requests to CurrencyLayer. 
    /// See <see cref="https://currencylayer.com/documentation">Documentation</see> for more information
    /// </summary>
    public interface ICLManager
    {
        /// <summary>
        /// Gets full list of supported currencies
        /// </summary>
        CLCurrenciesResponse GetCurrencies();

        /// <summary>
        /// Gets full list of supported currencies
        /// </summary>
        Task<CLCurrenciesResponse> GetCurrenciesAsync();

        /// <summary>
        /// Gets real-time exchange rates
        /// </summary>
        CLQuotesResponse GetRates();
        /// <summary>
        /// Gets real-time exchange rates
        /// </summary>
        /// <param name="sourceCurrency">Specify a Source Currency other than the default USD. Supported on the Basic Plan and higher.</param>
        CLQuotesResponse GetRates(string sourceCurrency);
        /// <summary>
        /// Gets real-time exchange rates
        /// </summary>
        /// <param name="currencies">Specify a list of currency codes to limit your API response to specific currencies.</param>
        CLQuotesResponse GetRates(IEnumerable<string> currencies);
        /// <summary>
        /// Gets real-time exchange rates
        /// </summary>
        /// <param name="sourceCurrency">Specify a Source Currency other than the default USD. Supported on the Basic Plan and higher.</param>
        /// <param name="currencies">Specify a list of currency codes to limit your API response to specific currencies.</param>
        CLQuotesResponse GetRates(string sourceCurrency, IEnumerable<string> currencies);

        /// <summary>
        /// Gets real-time exchange rates
        /// </summary>
        Task<CLQuotesResponse> GetRatesAsync();
        /// <summary>
        /// Gets real-time exchange rates
        /// </summary>
        /// <param name="sourceCurrency">Specify a Source Currency other than the default USD. Supported on the Basic Plan and higher.</param>
        Task<CLQuotesResponse> GetRatesAsync(string sourceCurrency);
        /// <summary>
        /// Gets real-time exchange rates
        /// </summary>
        /// <param name="currencies">Specify a list of currency codes to limit your API response to specific currencies.</param>
        Task<CLQuotesResponse> GetRatesAsync(IEnumerable<string> currencies);
        /// <summary>
        /// Gets real-time exchange rates
        /// </summary>
        /// <param name="sourceCurrency">Specify a Source Currency other than the default USD. Supported on the Basic Plan and higher.</param>
        /// <param name="currencies">Specify a list of currency codes to limit your API response to specific currencies.</param>
        Task<CLQuotesResponse> GetRatesAsync(string sourceCurrency, IEnumerable<string> currencies);

        /// <summary>
        /// Gets accurate historical exchange rate data for every past day all the way back to the year of 1999.
        /// </summary>
        /// <param name="date">A date for which to request historical rates.</param>
        CLQuotesResponse GetHistoricalRates(DateTime date);
        /// <summary>
        /// Gets accurate historical exchange rate data for every past day all the way back to the year of 1999.
        /// </summary>
        /// <param name="date">A date for which to request historical rates.</param>
        /// <param name="sourceCurrency">Specify a Source Currency other than the default USD. Supported on the Basic Plan and higher.</param>
        CLQuotesResponse GetHistoricalRates(DateTime date, string sourceCurrency);
        /// <summary>
        /// Gets accurate historical exchange rate data for every past day all the way back to the year of 1999.
        /// </summary>
        /// <param name="date">A date for which to request historical rates.</param>
        /// <param name="currencies">Specify a list of currency codes to limit your API response to specific currencies.</param>
        CLQuotesResponse GetHistoricalRates(DateTime date, IEnumerable<string> currencies);
        /// <summary>
        /// Gets accurate historical exchange rate data for every past day all the way back to the year of 1999.
        /// </summary>
        /// <param name="date">A date for which to request historical rates.</param>
        /// <param name="sourceCurrency">Specify a Source Currency other than the default USD. Supported on the Basic Plan and higher.</param>
        /// <param name="currencies">Specify a list of currency codes to limit your API response to specific currencies.</param>
        CLQuotesResponse GetHistoricalRates(DateTime date, string sourceCurrency, IEnumerable<string> currencies);

        /// <summary>
        /// Gets accurate historical exchange rate data for every past day all the way back to the year of 1999.
        /// </summary>
        /// <param name="date">A date for which to request historical rates.</param>
        Task<CLQuotesResponse> GetHistoricalRatesAsync(DateTime date);
        /// <summary>
        /// Gets accurate historical exchange rate data for every past day all the way back to the year of 1999.
        /// </summary>
        /// <param name="date">A date for which to request historical rates.</param>
        /// <param name="sourceCurrency">Specify a Source Currency other than the default USD. Supported on the Basic Plan and higher.</param>
        Task<CLQuotesResponse> GetHistoricalRatesAsync(DateTime date, string sourceCurrency);
        /// <summary>
        /// Gets accurate historical exchange rate data for every past day all the way back to the year of 1999.
        /// </summary>
        /// <param name="date">A date for which to request historical rates.</param>
        /// <param name="currencies">Specify a list of currency codes to limit your API response to specific currencies.</param>
        Task<CLQuotesResponse> GetHistoricalRatesAsync(DateTime date, IEnumerable<string> currencies);
        /// <summary>
        /// Gets accurate historical exchange rate data for every past day all the way back to the year of 1999.
        /// </summary>
        /// <param name="date">A date for which to request historical rates.</param>
        /// <param name="sourceCurrency">Specify a Source Currency other than the default USD. Supported on the Basic Plan and higher.</param>
        /// <param name="currencies">Specify a list of currency codes to limit your API response to specific currencies.</param>
        Task<CLQuotesResponse> GetHistoricalRatesAsync(DateTime date, string sourceCurrency, IEnumerable<string> currencies);

        /// <summary>
        /// Request to perform a Single currency conversion on your behalf. Available on Basic Plan and higher
        /// </summary>
        /// <param name="from">The currency to convert from</param>
        /// <param name="to">The currency to convert to</param>
        /// <param name="amount">Amount to convert</param>
        CLConvertResponse Convert(string from, string to, decimal amount);
        /// <summary>
        /// Request to perform a Single currency conversion on your behalf. Available on Basic Plan and higher
        /// </summary>
        /// <param name="from">The currency to convert from</param>
        /// <param name="to">The currency to convert to</param>
        /// <param name="amount">Amount to convert</param>
        /// <param name="date">A date to use historical rates for this conversion.</param>
        CLConvertResponse Convert(string from, string to, decimal amount, DateTime date);

        /// <summary>
        /// Request to perform a Single currency conversion on your behalf. Available on Basic Plan and higher
        /// </summary>
        /// <param name="from">The currency to convert from</param>
        /// <param name="to">The currency to convert to</param>
        /// <param name="amount">Amount to convert</param>
        Task<CLConvertResponse> ConvertAsync(string from, string to, decimal amount);
        /// <summary>
        /// Request to perform a Single currency conversion on your behalf. Available on Basic Plan and higher
        /// </summary>
        /// <param name="from">The currency to convert from</param>
        /// <param name="to">The currency to convert to</param>
        /// <param name="amount">Amount to convert</param>
        /// <param name="date">A date to use historical rates for this conversion.</param>
        Task<CLConvertResponse> ConvertAsync(string from, string to, decimal amount, DateTime date);

        /// <summary>
        /// Request historical exchange rates for a time-period of your choice. (maximum range: 365 days). Available on: Professional Plan and higher
        /// </summary>
        /// <param name="startDate">The start date of your time frame.</param>
        /// <param name="endDate">The end date of your time frame.</param>
        CLTimeFrameResponse GetTimeFrameRates(DateTime startDate, DateTime endDate);
        /// <summary>
        /// Request historical exchange rates for a time-period of your choice. (maximum range: 365 days). Available on: Professional Plan and higher
        /// </summary>
        /// <param name="startDate">The start date of your time frame.</param>
        /// <param name="endDate">The end date of your time frame.</param>
        /// <param name="sourceCurrency">A Source Currency other than the default USD</param>
        CLTimeFrameResponse GetTimeFrameRates(DateTime startDate, DateTime endDate, string sourceCurrency);
        /// <summary>
        /// Request historical exchange rates for a time-period of your choice. (maximum range: 365 days). Available on: Professional Plan and higher
        /// </summary>
        /// <param name="startDate">The start date of your time frame.</param>
        /// <param name="endDate">The end date of your time frame.</param>
        /// <param name="currencies">A list of currency codes to limit your API response to specific currencies</param>
        CLTimeFrameResponse GetTimeFrameRates(DateTime startDate, DateTime endDate, IEnumerable<string> currencies);
        /// <summary>
        /// Request historical exchange rates for a time-period of your choice. (maximum range: 365 days). Available on: Professional Plan and higher
        /// </summary>
        /// <param name="startDate">The start date of your time frame.</param>
        /// <param name="endDate">The end date of your time frame.</param>
        /// <param name="sourceCurrency">A Source Currency other than the default USD</param>
        /// <param name="currencies">A list of currency codes to limit your API response to specific currencies</param>
        CLTimeFrameResponse GetTimeFrameRates(DateTime startDate, DateTime endDate, string sourceCurrency, IEnumerable<string> currencies);

        /// <summary>
        /// Request historical exchange rates for a time-period of your choice. (maximum range: 365 days). Available on: Professional Plan and higher
        /// </summary>
        /// <param name="startDate">The start date of your time frame.</param>
        /// <param name="endDate">The end date of your time frame.</param>
        Task<CLTimeFrameResponse> GetTimeFrameRatesAsync(DateTime startDate, DateTime endDate);
        /// <summary>
        /// Request historical exchange rates for a time-period of your choice. (maximum range: 365 days). Available on: Professional Plan and higher
        /// </summary>
        /// <param name="startDate">The start date of your time frame.</param>
        /// <param name="endDate">The end date of your time frame.</param>
        /// <param name="sourceCurrency">A Source Currency other than the default USD</param>
        Task<CLTimeFrameResponse> GetTimeFrameRatesAsync(DateTime startDate, DateTime endDate, string sourceCurrency);
        /// <summary>
        /// Request historical exchange rates for a time-period of your choice. (maximum range: 365 days). Available on: Professional Plan and higher
        /// </summary>
        /// <param name="startDate">The start date of your time frame.</param>
        /// <param name="endDate">The end date of your time frame.</param>
        /// <param name="currencies">A list of currency codes to limit your API response to specific currencies</param>
        Task<CLTimeFrameResponse> GetTimeFrameRatesAsync(DateTime startDate, DateTime endDate, IEnumerable<string> currencies);
        /// <summary>
        /// Request historical exchange rates for a time-period of your choice. (maximum range: 365 days). Available on: Professional Plan and higher
        /// </summary>
        /// <param name="startDate">The start date of your time frame.</param>
        /// <param name="endDate">The end date of your time frame.</param>
        /// <param name="sourceCurrency">A Source Currency other than the default USD</param>
        /// <param name="currencies">A list of currency codes to limit your API response to specific currencies</param>
        Task<CLTimeFrameResponse> GetTimeFrameRatesAsync(DateTime startDate, DateTime endDate, string sourceCurrency, IEnumerable<string> currencies);

        /// <summary>
        /// Request the change (both margin and percentage) for one or more currencies
        /// </summary>
        /// <param name="startDate">The start date of your time frame</param>
        /// <param name="endDate">The end date of your time frame</param>
        CLCurrencyChangeResponse GetCurrencyChange(DateTime startDate, DateTime endDate);
        /// <summary>
        /// Request the change (both margin and percentage) for one or more currencies
        /// </summary>
        /// <param name="startDate">The start date of your time frame</param>
        /// <param name="endDate">The end date of your time frame</param>
        /// <param name="sourceCurrency">A Source Currency other than the default USD</param>
        CLCurrencyChangeResponse GetCurrencyChange(DateTime startDate, DateTime endDate, string sourceCurrency);
        /// <summary>
        /// Request the change (both margin and percentage) for one or more currencies
        /// </summary>
        /// <param name="startDate">The start date of your time frame</param>
        /// <param name="endDate">The end date of your time frame</param>
        /// <param name="currencies">A list of currency codes to limit your API response to specific currencies.</param>
        CLCurrencyChangeResponse GetCurrencyChange(DateTime startDate, DateTime endDate, IEnumerable<string> currencies);
        /// <summary>
        /// Request the change (both margin and percentage) for one or more currencies
        /// </summary>
        /// <param name="startDate">The start date of your time frame</param>
        /// <param name="endDate">The end date of your time frame</param>
        /// <param name="sourceCurrency">A Source Currency other than the default USD</param>
        /// <param name="currencies">A list of currency codes to limit your API response to specific currencies.</param>
        CLCurrencyChangeResponse GetCurrencyChange(DateTime startDate, DateTime endDate, string sourceCurrency, IEnumerable<string> currencies);

        /// <summary>
        /// Request the change (both margin and percentage) for one or more currencies
        /// </summary>
        /// <param name="startDate">The start date of your time frame</param>
        /// <param name="endDate">The end date of your time frame</param>
        Task<CLCurrencyChangeResponse> GetCurrencyChangeAsync(DateTime startDate, DateTime endDate);
        /// <summary>
        /// Request the change (both margin and percentage) for one or more currencies
        /// </summary>
        /// <param name="startDate">The start date of your time frame</param>
        /// <param name="endDate">The end date of your time frame</param>
        /// <param name="sourceCurrency">A Source Currency other than the default USD</param>
        Task<CLCurrencyChangeResponse> GetCurrencyChangeAsync(DateTime startDate, DateTime endDate, string sourceCurrency);
        /// <summary>
        /// Request the change (both margin and percentage) for one or more currencies
        /// </summary>
        /// <param name="startDate">The start date of your time frame</param>
        /// <param name="endDate">The end date of your time frame</param>
        /// <param name="currencies">A list of currency codes to limit your API response to specific currencies.</param>
        Task<CLCurrencyChangeResponse> GetCurrencyChangeAsync(DateTime startDate, DateTime endDate, IEnumerable<string> currencies);
        /// <summary>
        /// Request the change (both margin and percentage) for one or more currencies
        /// </summary>
        /// <param name="startDate">The start date of your time frame</param>
        /// <param name="endDate">The end date of your time frame</param>
        /// <param name="sourceCurrency">A Source Currency other than the default USD</param>
        /// <param name="currencies">A list of currency codes to limit your API response to specific currencies.</param>
        Task<CLCurrencyChangeResponse> GetCurrencyChangeAsync(DateTime startDate, DateTime endDate, string sourceCurrency, IEnumerable<string> currencies);
    }
}