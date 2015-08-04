using CSharpSixTour.Domain;

namespace CSharpSixTour.DataAccessLayer.Interfaces
{
    public interface ICurrencyExchange
    {
        decimal Convert(Currency source, Currency target, decimal amount);
    }
}
