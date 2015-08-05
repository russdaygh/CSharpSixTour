using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace CSharpSixTour.Tests
{
    [TestClass]
    public class ExceptionFiltersTests
    {
        [TestMethod]
        public void CSharp5_ExceptionFiltering()
        {
            Exception exception = null;

            try
            {
                int result = int.Parse(null);
                //int result = int.Parse("not a number");
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("Handled argument null exception");
            }
            catch(FormatException)
            {
                Console.WriteLine("Handled format exception");
            }
            catch(Exception)
            {
                throw;
            }
        }      
    }
}
