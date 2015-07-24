using System;
using CSharpSixTour.Domain;
using CSharpSixTour.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace CSharpSixTour.Tests
{
    [TestClass]
    public class StringInterpolationTests
    {
        private Person Person { get; set; }

        [TestInitialize]
        public void Initalise()
        {
            Person = new Person {FirstName = "Muddy", LastName = "Boots"};
        }

        [TestMethod]
        public void CSharp5_FormatFullName()
        {
            var phrase = string.Format("Full name = {0} {1}", Person.FirstName, Person.LastName);

            phrase.ShouldBe("Full name = Muddy Boots");
        }

        [TestMethod]
        public void CSharp6_InterpolateFullName()
        {
            var phrase = $"Full name = {Person.FirstName} {Person.LastName}";

            phrase.ShouldBe("Full name = Muddy Boots");
        }

        [TestMethod]
        public void CSharp5_FormatFloats()
        {
            var number = string.Format("π = {0:f}", Math.PI);

            number.ShouldBe("π = 3.14");
        }

        [TestMethod]
        public void CSharp6_InterpolateFloats()
        {
            var number = $"π = {Math.PI:F}";

            number.ShouldBe("π = 3.14");
        }

        [TestMethod]
        public void CSharp6_InterpolateDates()
        {
            var dateTime = new DateTime(2015, 8, 7);

            var date = $"{dateTime:d/M/yyyy}";

            date.ShouldBe("7/8/2015");
        }
    }
}
