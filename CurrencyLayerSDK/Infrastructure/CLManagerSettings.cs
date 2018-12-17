namespace CurrencyLayer4NET.Infrastructure
{
    public class CLManagerSettings
    {
        public bool IsHttps { get; set; } = false;
        public string BaseUrl { get; set; } = "apilayer.net/api";
        public bool FormatResponse { get; set; } = false;
        public bool LogRequestsAndResponses { get; set; } = false;
        public string LogsDirectory { get; set; } = @"C:\Logs\CurrencyLayer4NET";

        internal static readonly CLManagerSettings Defaults = new CLManagerSettings();
    }
}