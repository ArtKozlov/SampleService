using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetByPredicate(Func<T, bool> predicate);

        void Delete(T element);

        T Add(T element);

        T GetById(int? id);
    }
}
