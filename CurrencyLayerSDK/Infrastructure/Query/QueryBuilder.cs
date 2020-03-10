using CurrencyLayer4NET.Entities.Response;
using CurrencyLayer4NET.Extensions;
using CurrencyLayer4NET.Infrastructure.Execution;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyLayer4NET.Infrastructure.Query
{
    public class CLQueryBuilder
    {
        #region Static
        public static CLQueryBuilder Create(string endpoint) => new CLQueryBuilder(endpoint);

        private static HttpClient _httpClient = new HttpClient();
        #endregion

        private Dictionary<string, string> mParameters;
        private string mEndpoint;
        private CLManagerSettings mSettings;
        private IRequestPolicy mRequestPolicy;

        public CLQueryBuilder(string endpoint)
        {
            this.mEndpoint = endpoint;
        }

        public CLQueryBuilder WithSettings(CLManagerSettings settings)
        {
            this.mSettings = settings;

            return this;
        }

        public CLQueryBuilder WithPolicy(IRequestPolicy policy)
        {
            this.mRequestPolicy = policy;

            return this;
        }

        public CLQueryBuilder SetExactParameters(Dictionary<string, string> parameters)
        {
            this.mParameters = parameters;

            return this;
        }

        public CLQueryBuilder AddParameters(Dictionary<string, string> parameters)
        {
            if (parameters == null)
            {
                return this;
            }

            CreateParametersIfNull();

            foreach (var key in parameters?.Keys)
            {
                this.mParameters[key] = parameters[key];
            }

            return this;
        }

        public CLQueryBuilder SetAccessKey(string accessKey)
        {
            CreateParametersIfNull();

            mParameters.AddAccessKey(accessKey);

            return this;
        }

        public CLQueryBuilder SetCurrencies(IEnumerable<string> currencies)
        {
            CreateParametersIfNull();

            mParameters.AddCurrencies(currencies);

            return this;
        }

        public CLQueryBuilder SetSource(string sourceCurrency)
        {
            CreateParametersIfNull();

            mParameters.AddSourceCurrency(sourceCurrency);

            return this;
        }

        public CLQueryBuilder SetDate(DateTime date)
        {
            CreateParametersIfNull();

            mParameters.AddDate(date);

            return this;
        }

        public CLQueryBuilder SetStartDate(DateTime date)
        {
            CreateParametersIfNull();

            mParameters.AddStartDate(date);

            return this;
        }

        public CLQueryBuilder SetEndDate(DateTime date)
        {
            CreateParametersIfNull();

            mParameters.AddEndDate(date);

            return this;
        }

        public CLQueryBuilder AddParameter(string key, string value)
        {
            if (!String.IsNullOrEmpty(key) && !String.IsNullOrEmpty(value))
            {
                CreateParametersIfNull();

                mParameters[key] = value;
            }

            return this;
        }

        public string GetResponse() =>
            GetResponseAsync().GetAwaiter().GetResult();

        public async Task<string> GetResponseAsync()
        {
            if (this.mSettings == null)
                this.mSettings = GlobalConfiguration.Settings ?? CLManagerSettings.Defaults;
            if (this.mRequestPolicy == null)
                this.mRequestPolicy = GlobalConfiguration.ExecutionPolicy ?? new SimpleRequestPolicy();

            return await mRequestPolicy.ExecuteAsync(async () =>
            {
                var requestId = DateTimeOffset.Now.ToUnixTimeSeconds();
                var protocol = mSettings.IsHttps ? "https://" : "http://";
                var url = mSettings.BaseUrl?.Trim(' ', '/');

                string query = protocol + url + "/" + mEndpoint;

                CreateParametersIfNull();

                if (mSettings.FormatResponse)
                {
                    mParameters["format"] = "1";
                }

                query += "?" + String.Join("&", mParameters.Select(q => q.Key + "=" + q.Value));

                LogRequestToFile(query, requestId);

                var request = _httpClient.GetAsync(query);

                using (var response = await request)
                {
                    var rawResponse = await response.Content.ReadAsStringAsync();

                    LogResponseToFile(rawResponse, requestId);

                    return rawResponse;
                }
            });
        }

        public TResult GetResult<TResult>() where TResult : CLResponse =>
            GetResultAsync<TResult>().GetAwaiter().GetResult();

        public async Task<TResult> GetResultAsync<TResult>() where TResult : CLResponse
        {
            var rawResponse = await GetResponseAsync();

            var result = JsonConvert.DeserializeObject<TResult>(rawResponse);

            return result;
        }

        private void CreateParametersIfNull()
        {

            if (this.mParameters == null) mParameters = new Dictionary<string, string>();
        }

        private void LogRequestToFile(string content, long requestId)
        {
            if (!mSettings.LogRequestsAndResponses) return;

            LogToFile(Path.Combine(mSettings.LogsDirectory, $"Request_{requestId}_{Thread.CurrentThread.ManagedThreadId}.txt"), content);
        }

        private void LogResponseToFile(string content, long requestId)
        {
            if (!mSettings.LogRequestsAndResponses) return;

            LogToFile(Path.Combine(mSettings.LogsDirectory, $"Response_{requestId}_{Thread.CurrentThread.ManagedThreadId}.txt"), content);
        }

        private void LogToFile(string fileName, string content)
        {
            if (!mSettings.LogRequestsAndResponses) return;

            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                }

                File.WriteAllText(fileName, content);
            }
            catch (Exception e)
            {
                Debug.Write("Error while logging. " + e);
            }
        }

        public class KnownParameters
        {
            public const string AccessKey = "access_key";
            public const string SourceCurrency = "source";
            public const string Currencies = "currencies";
            public const string Date = "date";
            public const string StartDate = "start_date";
            public const string EndDate = "end_date";
        }
    }
}