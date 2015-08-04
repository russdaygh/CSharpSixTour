using System;

namespace CSharpSixTour.Domain
{
    public class Salary
    {
        public decimal Amount { get; set; }
        public TimeSpan Frequency { get; set; }
        public Currency Currency { get; set; }
    }
}