using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSixTour.DataAccessLayer
{
    interface IRepository<T, U>
    {
        U Create(T item);
        void Update(T item);
        void Delete(T item);
        void Delete(U id);
        T GetById(U id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Predicate<T> predicate);
    }
}
