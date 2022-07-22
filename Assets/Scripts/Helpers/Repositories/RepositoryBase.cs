using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RepositoryBase<T> : MonoBehaviour
{
    public abstract T Add(T item);
    public abstract IEnumerable<T> FindAll();

    public abstract void Load();
    public abstract void Save();
}
