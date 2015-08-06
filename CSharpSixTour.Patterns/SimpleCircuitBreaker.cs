using System;

namespace CSharpSixTour.Patterns
{
    public class SimpleCircuitBreaker<T>
    {
        private readonly T Target;

        private readonly SimpleCircuitBreakerConfig Config;

        private readonly Predicate<Exception> ExceptionFilter;

        private int TryCounter { get; set; }

        public CircuitBreakerState State { private set; get; }

        public Exception LastException { get; set; }

        public SimpleCircuitBreaker(T target, SimpleCircuitBreakerConfig config, Predicate<Exception> exceptionFilter = null, CircuitBreakerState state = CircuitBreakerState.Open)
        {
            if(target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            if(config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            Target = target;
            Config = config;
            ExceptionFilter = exceptionFilter;
            State = state;
        }

        public U Call<U>(Func<T, U> action)
        {
            TryCounter++;

            if (State == CircuitBreakerState.Closed)
            {
                if (TryCounter > Config.RetryThreshold)
                {
                    Open();
                }
                else
                {
                    throw LastException;
                }
            }

            try
            {
                U returnValue = action.Invoke(Target);

                Open();

                return returnValue;
            }
            catch (Exception e) when ((ExceptionFilter?.Invoke(e)).GetValueOrDefault(true))
            {
                if (TryCounter > Config.Threshold)
                {
                    Close(e);
                }

                LastException = e;

                throw;
            }
        }

        public void Call(Action<T> action)
        {
            Call(t =>
            {
                action.Invoke(t);
                return 0;
            });
        }

        private void Open()
        {
            TryCounter = 0;
            State = CircuitBreakerState.Open;
        }

        private void Close(Exception exception)
        {
            State = CircuitBreakerState.Closed;
            LastException = exception;
            TryCounter = 0;
        }
    }

    public class SimpleCircuitBreakerConfig
    {
        public int Threshold { get; set; }
        public int RetryThreshold { get; set; }
    }

    public enum CircuitBreakerState
    {
        Open,
        Closed
    }
}
