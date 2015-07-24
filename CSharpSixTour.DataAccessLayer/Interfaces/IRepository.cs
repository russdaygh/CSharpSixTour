using System;
using System.Collections.Generic;

namespace CSharpSixTour.DataAccessLayer.Interfaces
{
    public interface IRepository<T, U>
    {
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Delete(U id);
        T Get(U id);
        IEnumerable<T> Get(Predicate<T> predicate);
    }
}
