using System;
using System.Net.Mail;

namespace CSharpSixTour.Domain
{
    public partial class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PostalAddress Address { get; set; }
        public PhoneNumber[] PhoneNumbers { get; set; }
        public MailAddress Email { get; set; }
        public Salary Salary { get; set; }
    }
}
