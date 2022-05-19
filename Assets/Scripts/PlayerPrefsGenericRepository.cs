using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerPrefsGenericRepository<T> : IRepository<T> where T : class
{
    public T Add(T item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Find(Func<T, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Load()
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }
}
