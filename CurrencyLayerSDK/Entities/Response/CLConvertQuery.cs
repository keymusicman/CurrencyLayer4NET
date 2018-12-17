namespace CurrencyLayer4NET.Entities.Response
{
    public class CLConvertQuery
    {
        /// <summary>
        /// The currency the given amount is converted from.
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// The currency the given amount is converted to.
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// Convertion amount
        /// </summary>
        public decimal Amount { get; set; }
    }
}