using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootLockerScoreEventData : ScoreEventData
{
    public string PlayerId;

    public LootLockerScoreEventData(ScoreData scoreData, string playerId) : base(scoreData)
    {
        PlayerId = playerId;
    }
}
