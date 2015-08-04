using System;
using CSharpSixTour.DataAccessLayer.Interfaces;
using CSharpSixTour.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace CSharpSixTour.Tests
{
    class MockCurrencyExchange : ICurrencyExchange
    {
        private IEnumerable<ExchangeRate> ExchangeRates { get; set; }
        public decimal Convert(Currency source, Currency target, decimal amount)
        {
            if(source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            if (!ExchangeRates.Any(er => er.CurrencyA == source && er.CurrencyB == target))
            {
                throw new NoCompatibleExchangeRateFoundException(source, target);
            }
            return amount * ExchangeRates.Single(er => er.CurrencyA == source).Rate;
        }

        [Serializable]
        private class NoCompatibleExchangeRateFoundException : Exception
        {
            private Currency source;
            private Currency target;

            public NoCompatibleExchangeRateFoundException()
            {
            }

            public NoCompatibleExchangeRateFoundException(string message) : base(message)
            {
            }

            public NoCompatibleExchangeRateFoundException(string message, Exception innerException) : base(message, innerException)
            {
            }

            public NoCompatibleExchangeRateFoundException(Currency source, Currency target)
            {
                this.source = source;
                this.target = target;
            }

            protected NoCompatibleExchangeRateFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
