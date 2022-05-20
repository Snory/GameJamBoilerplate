using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerPrefsGenericRepository<T> : IRepository<T> where T : class
{
   
    [SerializeField] private string _playerRefsName;

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
        if (PlayerPrefs.HasKey(_playerRefsName))
        {
            string savedData = PlayerPrefs.GetString(_playerRefsName);
            return JsonUtility.FromJson<IEnumerable<T>>(savedData);
        }

        return new List<T>();
    }

    public void Save(IEnumerable<T> listOfHighScores)
    {
        string savedJson = JsonUtility.ToJson(listOfHighScores);
        PlayerPrefs.SetString(_playerRefsName, savedJson);
        PlayerPrefs.Save();
    }
}
