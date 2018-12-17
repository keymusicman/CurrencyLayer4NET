using System;

namespace CurrencyLayer4NET.Exceptions
{
    public class CLException : Exception
    {
        public int Code { get; }

        public CLException(int code, string message) : base(message)
        {
            this.Code = code;
        }

        /// <summary>
        /// Generates specific exception based on error code. You can find API errors here: https://currencylayer.com/documentation (API Error Codes)
        /// </summary>
        public static CLException FromCode(int code, string message)
        {
            if (code == 104)
            {
                return new RequestLimitException(code, message);
            }

            if (code == 105)
            {
                return new SubscriptionLimitationException(code, message);
            }

            if (code == 201 || code == 202)
            {
                return new UnsupportedCurrencyException(code, message);
            }

            if (code == 301 ||
                code == 302 ||
                code == 401 ||
                code == 402 ||
                code == 403 ||
                code == 501 ||
                code == 502 ||
                code == 503 ||
                code == 504 ||
                code == 505)
            {
                return new InvalidQueryException(code, message);
            }

            // all the other exceptions
            return new CLException(code, message);
        }
    }

    /// <summary>
    /// The InvalidQueryException is thrown if some query parameters are invalid
    /// </summary>
    public class InvalidQueryException : CLException
    {
        public InvalidQueryException(int code, string message) : base(code, message)
        {
        }
    }

    public class UnsupportedCurrencyException : CLException
    {
        public UnsupportedCurrencyException(int code, string message) : base(code, message)
        {
        }
    }

    public class SubscriptionLimitationException : CLException
    {
        public SubscriptionLimitationException(int code, string message) : base(code, message)
        {
        }
    }

    public class RequestLimitException : CLException
    {
        public RequestLimitException(int code, string message) : base(code, message)
        {
        }
    }
}