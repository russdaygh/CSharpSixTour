using System;
using System.Collections.Generic;
using CSharpSixTour.DataAccessLayer.Interfaces;
using CSharpSixTour.Domain;

namespace CSharpSixTour.DataAccessLayer
{
    public class PersonRepository : IRepository<Person, Guid>
    {
        public void Create(Person item)
        {
            throw new NotImplementedException();
        }

        public void Update(Person item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Person item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Person Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> Get(Predicate<Person> predicate)
        {
            return new List<Person>();
        }
    }
}
