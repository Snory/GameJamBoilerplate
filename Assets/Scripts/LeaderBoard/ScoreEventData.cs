using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEventData : EventArgs { 
    
    public int Score;
    public string PlayerId;
    public string PlayerName;

    public ScoreEventData(int score)
    {
        Score = score;
        PlayerId = PlayerPrefs.GetString("CurrentPlayerId");
        PlayerName = PlayerPrefs.GetString("PlayerName");
    }

    public ScoreEventData(int score, string playerId, string playerName)
    {
        Score = score;
        PlayerId = playerId;
        PlayerName = playerName;
    }
}
