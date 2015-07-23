using CSharpSixTour.DataAccessLayer;
using CSharpSixTour.Domain;
using System;
using System.Linq;

namespace NullConditionalOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonRepository people = new PersonRepository();

            Person person = people.Get(p => p.FirstName == "Russell" && p.LastName == "Day").FirstOrDefault();

            try
            {
                Console.WriteLine(person.Address.County);
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine(person?.Address.County);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine(person?.Address?.County);
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
