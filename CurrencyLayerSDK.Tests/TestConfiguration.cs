namespace CurrencyLayer4NET.Tests
{
    internal static class TestConfiguration
    {
        /// <summary>
        /// Your CurrencyLayer account access key
        /// </summary>
        public static string ApiAccessKey { get; set; } = "YOUR_ACCESS_KEY";
        /// <summary>
        /// Your CurrencyLayer account subscription plan
        /// </summary>
        public static Plan Plan { get; set; } = Plan.Free;
    }

    enum Plan { Free, Basic, Professional, Enterprise }
}
