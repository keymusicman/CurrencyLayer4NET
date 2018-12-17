namespace CurrencyLayer4NET.Entities.Response
{
    public class CLError
    {
        /// <summary>
        /// 3-digit error-code
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// User-friendly error message
        /// </summary>
        public string Info { get; set; }
    }
}