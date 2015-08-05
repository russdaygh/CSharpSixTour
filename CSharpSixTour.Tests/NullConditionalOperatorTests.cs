using System;
using System.Linq;
using CSharpSixTour.Domain;
using CSharpSixTour.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace CSharpSixTour.Tests
{
    [TestClass]
    public class NullConditionalOperatorTests
    {
        private MockPersonRepository MockPersonRepository { get; set; }

        private Person PersonWithNullAddress { get; set; }

        [TestInitialize]
        public void Initialise()
        {
            MockPersonRepository = new MockPersonRepository();
            MockPersonRepository.Create(new Person {Address = null});

            PersonWithNullAddress = MockPersonRepository.Get(p => p.Address == null).FirstOrDefault();
        }

        [TestMethod]
        public void CSharp5_PrintCountryName_ThrowsNullReference()
        {
            Should.Throw<NullReferenceException>(() =>
            {
                Console.WriteLine(PersonWithNullAddress.Address.Country.Name);
            });
        }

        [TestMethod]
        public void CSharp5_PrintCountryNameWithNullChecks_DoesNotThrowNullReference()
        {
            Should.NotThrow(() =>
            {
                if (PersonWithNullAddress != null && PersonWithNullAddress.Address != null &&
                    PersonWithNullAddress.Address.Country != null)
                {
                    Console.WriteLine(PersonWithNullAddress.Address.Country);
                }
            });
        }

        [TestMethod]
        public void CSharp6_PrintCountryName_DoesNotThrowNullReference()
        {
            Should.Throw<NullReferenceException>(() =>
            {
                Console.WriteLine(PersonWithNullAddress?.Address.Country.Name);
            });
        }

        [TestMethod]
        public void CSharp6_PrintCountryName_ConditionalPropagation()
        {
            Should.Throw<NullReferenceException>(() =>
            {
                Console.WriteLine(PersonWithNullAddress.Address.Country?.Name);
            });
        }
    }
}
