using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpSixTour.Domain;

namespace CSharpSixTour.Tests
{
    [TestClass]
    public class ExceptionFiltersTests
    {
        [TestMethod]
        public void CSharp5_ExceptionFiltering()
        {
            try
            {
                Person person = new Person {
                    FirstName = "Last",
                    LastName = "First",
                    Salary = new Salary {
                        Currency = Currency.GBP,
                        Amount = 1000
                    }
                };

                MockCurrencyExchange exchange = new MockCurrencyExchange();

                var dollars = exchange.Convert(person.Salary.Currency, Currency.USD, person.Salary.Amount);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
