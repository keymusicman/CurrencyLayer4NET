namespace CurrencyLayer4NET.Entities
{
    public class Quote
    {
        /// <summary>
        /// Base (source) currency for conversion
        /// </summary>
        public Currency SourceCurrency { get; set; }

        /// <summary>
        /// Target currency for coversion
        /// </summary>
        public Currency TargetCurrency { get; set; }

        /// <summary>
        /// (Source currency / target currency) ratio
        /// </summary>
        public decimal Rate { get; set; }
    }
}