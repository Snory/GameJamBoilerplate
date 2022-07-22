using LootLocker.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour 
{

    public RepositoryBase<HighScoreEventData> HighScoreRepository;

    // Start is called before the first frame update
    void Start()
    {
        HighScoreRepository.Load();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void OnApplicationQuit()
    {
        HighScoreRepository.Save();
    }

    public void OnHighScoreAdded(EventArgs highScoreData)
    {        
        HighScoreRepository.Add((HighScoreEventData) highScoreData);
    }
}
