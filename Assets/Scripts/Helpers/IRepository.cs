using System;
using System.Collections.Generic;

public interface IRepository<T>
{
    void Add(T item);

    IEnumerable<T> FindAll();

    void Save();
    void Load();

}
