using CurrencyLayer4NET.Entities.Response;
using CurrencyLayer4NET.Extensions;
using CurrencyLayer4NET.Infrastructure;
using CurrencyLayer4NET.Infrastructure.Execution;
using CurrencyLayer4NET.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyLayer4NET
{
    public class CLManager : ICLManager
    {
        #region Fields
        private IRequestPolicy mRequestPolicy { get; set; } = GlobalConfiguration.ExecutionPolicy ?? new SimpleRequestPolicy();

        /// <summary>
        /// Client settings
        /// </summary>
        private CLManagerSettings mSettings = GlobalConfiguration.Settings ?? CLManagerSettings.Defaults;

        /// <summary>
        /// CurrencyLayer account access token
        /// </summary>
        private string mAccessToken = null;
        #endregion

        #region Ctors
        public CLManager(string accessToken)
        {
            this.mAccessToken = accessToken;
        }

        public CLManager(string accessToken, CLManagerSettings settings) : this(accessToken)
        {
            mSettings = settings;
        }
        #endregion

        #region ICurrencyLayerManager implementation

        #region Currencies
        public CLCurrenciesResponse GetCurrencies() =>
            GetCurrenciesAsync().GetAwaiter().GetResult();

        public async Task<CLCurrenciesResponse> GetCurrenciesAsync() =>
            await RequestAsync<CLCurrenciesResponse>(Endpoints.CURRENCIES);
        #endregion

        #region Quotes
        public CLQuotesResponse GetRates() =>
            GetRates(null, null);

        public CLQuotesResponse GetRates(IEnumerable<string> currencies) =>
            GetRates(null, currencies);

        public CLQuotesResponse GetRates(string sourceCurrency) =>
            GetRates(sourceCurrency, null);

        public CLQuotesResponse GetRates(string sourceCurrency, IEnumerable<string> currencies) =>
            GetRatesAsync(sourceCurrency, currencies).GetAwaiter().GetResult();

        public async Task<CLQuotesResponse> GetRatesAsync() =>
            await GetRatesAsync(null, null);

        public async Task<CLQuotesResponse> GetRatesAsync(string sourceCurrency) =>
            await GetRatesAsync(sourceCurrency, null);

        public async Task<CLQuotesResponse> GetRatesAsync(IEnumerable<string> currencies) =>
            await GetRatesAsync(null, currencies);

        public async Task<CLQuotesResponse> GetRatesAsync(string sourceCurrency, IEnumerable<string> currencies)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.AddCurrencies(currencies);
            parameters.AddSourceCurrency(sourceCurrency);

            return await RequestAsync<CLQuotesResponse>(Endpoints.RATES, parameters);
        }
        #endregion

        #region Convert
        public CLConvertResponse Convert(string from, string to, decimal amount) =>
            ConvertAsync(from, to, amount).GetAwaiter().GetResult();

        public CLConvertResponse Convert(string from, string to, decimal amount, DateTime date) =>
            ConvertAsync(from, to, amount, date).GetAwaiter().GetResult();

        public async Task<CLConvertResponse> ConvertAsync(string from, string to, decimal amount)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (String.IsNullOrEmpty(from))
            {
                throw new ArgumentNullException("from");
            }
            if (String.IsNullOrEmpty(to))
            {
                throw new ArgumentNullException("to");
            }

            parameters.Add("from", from);
            parameters.Add("to", to);
            parameters.Add("amount", amount + "");

            return await RequestAsync<CLConvertResponse>(Endpoints.CONVERT, parameters);
        }

        public async Task<CLConvertResponse> ConvertAsync(string from, string to, decimal amount, DateTime date)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (String.IsNullOrEmpty(from))
            {
                throw new ArgumentNullException("from");
            }
            if (String.IsNullOrEmpty(to))
            {
                throw new ArgumentNullException("to");
            }

            parameters.Add("from", from);
            parameters.Add("to", to);
            parameters.Add("amount", amount + "");
            parameters.AddDate(date);

            return await RequestAsync<CLConvertResponse>(Endpoints.CONVERT, parameters);
        }
        #endregion

        #region Historical Quotes
        public CLQuotesResponse GetHistoricalRates(DateTime date) =>
    GetHistoricalRates(date, null, null);

        public CLQuotesResponse GetHistoricalRates(DateTime date, string sourceCurrency) =>
            GetHistoricalRates(date, sourceCurrency, null);

        public CLQuotesResponse GetHistoricalRates(DateTime date, IEnumerable<string> currencies) =>
            GetHistoricalRates(date, null, currencies);

        public CLQuotesResponse GetHistoricalRates(DateTime date, string sourceCurrency, IEnumerable<string> currencies) =>
            GetHistoricalRatesAsync(date, sourceCurrency, currencies).GetAwaiter().GetResult();

        public async Task<CLQuotesResponse> GetHistoricalRatesAsync(DateTime date) =>
            await GetHistoricalRatesAsync(date, null, null);

        public async Task<CLQuotesResponse> GetHistoricalRatesAsync(DateTime date, string sourceCurrency) =>
            await GetHistoricalRatesAsync(date, sourceCurrency, null);

        public async Task<CLQuotesResponse> GetHistoricalRatesAsync(DateTime date, IEnumerable<string> currencies) =>
            await GetHistoricalRatesAsync(date, null, currencies);

        public async Task<CLQuotesResponse> GetHistoricalRatesAsync(DateTime date, string sourceCurrency, IEnumerable<string> currencies)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.AddDate(date);
            parameters.AddCurrencies(currencies);
            parameters.AddSourceCurrency(sourceCurrency);

            return await RequestAsync<CLQuotesResponse>(Endpoints.HISTORICAL_RATES, parameters);
        }
        #endregion

        #region Time Frame Rates
        public CLTimeFrameResponse GetTimeFrameRates(DateTime startDate, DateTime endDate) =>
            GetTimeFrameRates(startDate, endDate, null, null);

        public CLTimeFrameResponse GetTimeFrameRates(DateTime startDate, DateTime endDate, string sourceCurrency) =>
            GetTimeFrameRates(startDate, endDate, sourceCurrency, null);

        public CLTimeFrameResponse GetTimeFrameRates(DateTime startDate, DateTime endDate, IEnumerable<string> currencies) =>
            GetTimeFrameRates(startDate, endDate, null, currencies);

        public CLTimeFrameResponse GetTimeFrameRates(DateTime startDate, DateTime endDate, string sourceCurrency, IEnumerable<string> currencies) =>
            GetTimeFrameRatesAsync(startDate, endDate, sourceCurrency, currencies).GetAwaiter().GetResult();

        public async Task<CLTimeFrameResponse> GetTimeFrameRatesAsync(DateTime startDate, DateTime endDate) =>
            await GetTimeFrameRatesAsync(startDate, endDate, null, null);

        public async Task<CLTimeFrameResponse> GetTimeFrameRatesAsync(DateTime startDate, DateTime endDate, string sourceCurrency) =>
            await GetTimeFrameRatesAsync(startDate, endDate, sourceCurrency, null);

        public async Task<CLTimeFrameResponse> GetTimeFrameRatesAsync(DateTime startDate, DateTime endDate, IEnumerable<string> currencies) =>
            await GetTimeFrameRatesAsync(startDate, endDate, null, currencies);

        public async Task<CLTimeFrameResponse> GetTimeFrameRatesAsync(DateTime startDate, DateTime endDate, string sourceCurrency, IEnumerable<string> currencies)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.AddStartDate(startDate);
            parameters.AddEndDate(startDate);
            parameters.AddCurrencies(currencies);
            parameters.AddSourceCurrency(sourceCurrency);

            return await RequestAsync<CLTimeFrameResponse>(Endpoints.TIMEFRAME, parameters);
        }
        #endregion

        #region Currency Change
        public CLCurrencyChangeResponse GetCurrencyChange(DateTime startDate, DateTime endDate) =>
            GetCurrencyChange(startDate, endDate, null, null);

        public CLCurrencyChangeResponse GetCurrencyChange(DateTime startDate, DateTime endDate, string sourceCurrency) =>
            GetCurrencyChange(startDate, endDate, sourceCurrency, null);

        public CLCurrencyChangeResponse GetCurrencyChange(DateTime startDate, DateTime endDate, IEnumerable<string> currencies) =>
            GetCurrencyChange(startDate, endDate, null, currencies);

        public CLCurrencyChangeResponse GetCurrencyChange(DateTime startDate, DateTime endDate, string sourceCurrency, IEnumerable<string> currencies) =>
            GetCurrencyChangeAsync(startDate, endDate, sourceCurrency, currencies).GetAwaiter().GetResult();

        public async Task<CLCurrencyChangeResponse> GetCurrencyChangeAsync(DateTime startDate, DateTime endDate) =>
            await GetCurrencyChangeAsync(startDate, endDate, null, null);

        public async Task<CLCurrencyChangeResponse> GetCurrencyChangeAsync(DateTime startDate, DateTime endDate, string sourceCurrency) =>
            await GetCurrencyChangeAsync(startDate, endDate, sourceCurrency, null);

        public async Task<CLCurrencyChangeResponse> GetCurrencyChangeAsync(DateTime startDate, DateTime endDate, IEnumerable<string> currencies) =>
            await GetCurrencyChangeAsync(startDate, endDate, null, currencies);

        public async Task<CLCurrencyChangeResponse> GetCurrencyChangeAsync(DateTime startDate, DateTime endDate, string sourceCurrency, IEnumerable<string> currencies)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.AddStartDate(startDate);
            parameters.AddEndDate(startDate);
            parameters.AddCurrencies(currencies);
            parameters.AddSourceCurrency(sourceCurrency);

            return await RequestAsync<CLCurrencyChangeResponse>(Endpoints.CHANGE, parameters);
        }
        #endregion

        #endregion

        #region Private
        private TResult Request<TResult>(string endpoint)
            where TResult : CLResponse =>
            Request<TResult>(endpoint, null);

        private TResult Request<TResult>(string endpoint, Dictionary<string, string> parameters)
            where TResult : CLResponse =>
            RequestAsync<TResult>(endpoint, parameters).GetAwaiter().GetResult();

        private async Task<TResult> RequestAsync<TResult>(string endpoint)
            where TResult : CLResponse =>
            await RequestAsync<TResult>(endpoint, null);

        private async Task<TResult> RequestAsync<TResult>(string endpoint, Dictionary<string, string> parameters)
            where TResult : CLResponse
        {
            var result = await CLQueryBuilder.
                Create(endpoint).
                WithSettings(mSettings).
                WithPolicy(mRequestPolicy).
                AddParameters(parameters).
                SetAccessKey(this.mAccessToken).
                GetResultAsync<TResult>();

            result.ThrowIfError();

            return result;
        }
        #endregion
    }
}