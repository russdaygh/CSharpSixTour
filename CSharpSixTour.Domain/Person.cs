using System.Net.Mail;

namespace CSharpSixTour.Domain
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PostalAddress Address { get; set; }
        public PhoneNumber[] PhoneNumbers { get; set; }
        public MailAddress Email { get; set; }
    }
}
