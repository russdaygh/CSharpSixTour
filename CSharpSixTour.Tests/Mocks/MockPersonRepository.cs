using System;
using System.Collections.Generic;
using System.Linq;
using CSharpSixTour.DataAccessLayer.Interfaces;
using CSharpSixTour.Domain;

namespace CSharpSixTour.Tests.Mocks
{
    public class MockPersonRepository : IRepository<Person, Guid>
    {
        private List<Person> People { get; } = new List<Person>();

        public void Create(Person person)
        {
            People.Add(person);
        }

        public void Update(Person person)
        {
            People.RemoveAll(p => p.Id == person.Id);
            People.Add(person);
        }

        public void Delete(Person person)
        {
            People.Remove(person);
        }

        public void Delete(Guid id)
        {
            People.RemoveAll(p => p.Id == id);
        }

        public Person Get(Guid id)
        {
            return People.Single(p => p.Id == id);
        }

        public IEnumerable<Person> Get(Predicate<Person> predicate)
        {
            return People.FindAll(predicate);
        }
    }
}
