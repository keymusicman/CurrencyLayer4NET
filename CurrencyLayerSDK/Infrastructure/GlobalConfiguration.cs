using CurrencyLayer4NET.Infrastructure.Execution;

namespace CurrencyLayer4NET.Infrastructure
{
    public class GlobalConfiguration
    {
        public static IRequestPolicy ExecutionPolicy { get; set; } = new SimpleRequestPolicy();
        public static CLManagerSettings Settings { get; set; } = CLManagerSettings.Defaults;
    }
}