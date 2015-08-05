using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
                int result = int.Parse(null);
                //int result = int.Parse("not a number");
            }
            catch (ArgumentNullException)
            {
            }
            catch (FormatException)
            {
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected exception caught");
            }
        }

        [TestMethod]
        public void CSharp5_ExceptionFiltering2()
        {
            try
            {
                int result = int.Parse(null);
                //int result = int.Parse("not a number");
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException || ex is FormatException)
                {
                    Console.WriteLine("Expected exception caught");
                }
                else
                {
                    Console.WriteLine("Unexpected exception caught");
                }
            }
        }

        [TestMethod]
        public void CSharp6_ExceptionFiltering()
        {
            try
            {
                int result = int.Parse(null);
            }
            catch (Exception ex) when (ShouldBeLogged(ex))
            {
                Console.WriteLine("Exception logged");
            }
        }

        private Predicate<Exception> ShouldBeLogged = ex => { return (ex is ArgumentNullException || ex is FormatException); };

        [TestMethod]
        public void CSharp6_ExceptionFiltering2()
        {
            try
            {
                int result = int.Parse(null);
                //int[] numbers = new int[] { };
                //int result = numbers[3];
            }
            catch(Exception ex) when (Log(ex))
            {
                Console.WriteLine("Exception caught");
            }
        }

        private Predicate<Exception> Log = ex => 
        {
            if (ex is ArgumentNullException || ex is FormatException)
            {
                Console.WriteLine("Exception logged");
                return true;
            }
            return false;
        };

        //https://lostechies.com/jimmybogard/2015/07/17/c-6-exception-filters-will-improve-your-home-life/
    }
}
