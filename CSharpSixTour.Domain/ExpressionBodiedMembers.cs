namespace CSharpSixTour.Domain
{
    public partial class Person
    {
        public string Fullname => $"{FirstName} {LastName}";
    }
}
