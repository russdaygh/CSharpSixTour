namespace CSharpSixTour.Domain
{
    public class PostalAddress
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string TownCity { get; set; }
        public string County { get; set; }
        public Country Country { get; set; }
        public string Postcode { get; set; }
    }
}
