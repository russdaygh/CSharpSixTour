namespace CSharpSixTour.Domain
{
    public partial class Person
    {
        public string Fullname => $"{FirstName} {LastName}";
    }

    public partial class PhoneNumber
    {
        public string FullNumber => DialingCode + Number.ToString();
    }
}
