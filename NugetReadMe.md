# CurrencyLayer4NET: A .NET library for CurrencyLayer API

[![Apache 2](http://img.shields.io/badge/license-Apache%202-brightgreen.svg)](http://www.apache.org/licenses/LICENSE-2.0)

CurrencyLayer4NET is a .NET library that makes it easier to do API calls to [CurrencyLayer.com](https://currencylayer.com).

# Using CurrencyLayer4NET
CurrencyLayer4NET provides 3 different levels of how you can make CurrencyLayer API calls: [CLClient](#CLClient), [CLManager](#CLManager), [CLQueryBuilder](#CLQueryBuilder).

## CLClient
This is high-level class that operates its own entities like `Currency`, `Quote`, etc. For example, getting all currencies looks like that:
```cs
ICLClient clClient = new CLClient("YOUR_API_ACCESS_KEY");
IEnumerable<Currency> currencies = clClient.GetCurrencies();
```
Getting currencies exchange rates:
```cs
Currency eur = Currency.FromCode("EUR");
Currency cad = Currency.FromCode("CAD");

ICLClient clClient = new CLClient("YOUR_API_ACCESS_KEY");
IEnumerable<Quote> quotes = clClient.GetRates(new[] { eur, usd });
// or
IEnumerable<Quote> quotes = clClient.GetRates(new[] { "EUR", "USD" });
```

### Pros:
- You can operate simple objects

### Cons:
- Some methods are not implemented
- Async methods not implemented

## CLManager
This is low-level class that operates entities that are nearly exactly repeat CurrencyLayer API responses structure (`CLCurrenciesResponse`, `CLQuotesResponse`, etc). Getting all currencies looks like that:
```cs
ICLManager manager = new CLManager("YOUR_API_ACCESS_KEY");
CLCurrenciesResponse response = manager.GetCurrencies();

foreach (var currency in response.Currencies){
	Console.WriteLine($"Currency Code: {currency.Key}, Currency Name: {currency.Value}");
}
```

### Pros:
- Full support of CurrencyLayer API endpoints
- Async methods are available

### Cons:
- Low-level response objects
- JSONP Callback Function feature missing

## CLQueryBuilder
This is low-level class that allows building and executing queries to CurrencyLayer API. This class operates the same response entities as CLManager does (`CLCurrenciesResponse`, `CLQuotesResponse`, etc). Getting all currencies looks like that:
```cs
CLCurrenciesResponse response = CLQueryBuilder.
                Create(Endpoints.CURRENCIES).
                GetResult<CLCurrenciesResponse>();
```
To request quotes for specified currencies, you can do this:
```cs
CLQuotesResponse response = CLQueryBuilder.
                Create(Endpoints.RATES).
                SetAccessKey("YOUR_API_ACCESS_KEY").
				SetCurrencies(new[] { "EUR", "GBP" }).
                GetResult<CLQuotesResponse>();
```
JSONP Callback function feature:
```cs
string response = CLQueryBuilder.
                Create(Endpoints.CURRENCIES).
                AddParameter("callback", "test_callback").
                GetResponse();
```

### Pros:
- Full support of CurrencyLayer API endpoints and features
- Async methods are available

### Cons:
- Low-level response objects
- In fact you build query manually, so you possibly will need to look at [documentation](https://currencylayer.com/documentation) to get the exact parameters for the query you want to make

# Running Tests

In order to run Unit Tests you should perform the following simple steps:
- If you do not have a [CurrencyLayer](https://currencylayer.com) account, sign up. If you already have the account, sign in.
- You will need an API Access Key. You can find it on your [Dashboard](https://currencylayer.com/dashboard).
- Open `CurrencyLayerNET.Tests.TestConfiguration` class.
- Replace `ApiAccessKey` property value to your API Access Key.
- Replace `Plan` enum property value to the corresponding Plan of your CurrencyLayer subscription plan. Example:
```cs
public static string ApiAccessKey { get; set; } = "b69242edc1d371e395060d3f414870d2";
public static Plan Plan { get; set; } = Plan.Professional;
```
**Note**: some of Unit Tests depend on your account subscription plan. So if you will set wrong `Plan`, some tests may fail.
