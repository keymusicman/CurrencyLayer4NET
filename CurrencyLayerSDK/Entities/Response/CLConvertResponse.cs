using System;
using System.ComponentModel;

namespace CurrencyLayer4NET.Entities.Response
{
    public class CLConvertResponse : CLResponse
    {
        /// <summary>
        /// Convert query
        /// </summary>
        public CLConvertQuery Query { get; set; }
        /// <summary>
        /// Convert info (quote and its timestamp)
        /// </summary>
        public CLConvertInfo Info { get; set; }
        /// <summary>
        /// True if you request historical rates
        /// </summary>
        [DefaultValue(false)]
        public bool Historical { get; set; }
        /// <summary>
        /// Date for historical rates. Will be null if you query real-time quotes
        /// </summary>
        public DateTime? Date { get; set; }
        /// <summary>
        /// Conversion result
        /// </summary>
        public decimal Result { get; set; }
    }
}