using System;
using System.Collections.Generic;

public interface IRepository<T>
{
    T Add(T item);
    void Save(IEnumerable<T> listOfData);
    IEnumerable<T> Load();
    IEnumerable<T> Find(Func<T, bool> predicate);
}
