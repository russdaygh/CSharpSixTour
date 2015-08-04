namespace CSharpSixTour.Domain
{
    public class Currency
    {
        public string Name { get; set; }
        public string Iso4217Code { get; set; }
        public static Currency GBP { get; } = new Currency { Name = "Great British Pound", Iso4217Code = "GBP" };
        public static Currency USD { get; } = new Currency { Name = "United States Dollar", Iso4217Code = "USD" };
    }
}
