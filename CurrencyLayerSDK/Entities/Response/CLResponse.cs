namespace CurrencyLayer4NET.Entities.Response
{
    public class CLResponse
    {
        /// <summary>
        /// Returns true or false depending on whether or not your query succeeds.
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Returns a link to the currencylayer Terms & Conditions.
        /// </summary>
        public string Terms { get; set; }
        /// <summary>
        /// Returns a link to the currencylayer Privacy Policy.
        /// </summary>
        public string Privacy { get; set; }
        /// <summary>
        /// If your query fails, the currencylayer API will return a 3-digit error-code and a plain text "info" property containing suggestions for the user.
        /// </summary>
        public CLError Error { get; set; }
    }
}