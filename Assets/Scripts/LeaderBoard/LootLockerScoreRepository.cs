using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootLockerScoreRepository : RepositoryBase<ScoreEventData>
{
    int _leaderBoardId = 3195;

    public override ScoreEventData Add(ScoreEventData item)
    {

        LootLockerSDKManager.SubmitScore(item.PlayerId, item.Score, _leaderBoardId, (response) =>
           {
               if (!response.success)
               {
                   Debug.LogError("Score could not be updated: " + response.Error);
               }
           });

        return item;
    }

    private void SetName()
    {
        if (!PlayerPrefs.HasKey("PlayerName"))
        {
            return;
        }

        LootLockerSDKManager.GetPlayerName((response) =>
        {
            if (response.success)
            {
                if (string.IsNullOrEmpty(response.name))
                {
                    LootLockerSDKManager.SetPlayerName(PlayerPrefs.GetString("PlayerName"), (response) =>
                    {
                        if (!response.success)
                        {
                            Debug.LogError("Could not set name " + response.Error);
                        }
                    });
                }
            }
            else
            {
                Debug.LogError("Could not retrieve player name " + response.Error);
            }
        });
    }

    public override IEnumerable<ScoreEventData> FindAll()
    {
        List<ScoreEventData> data = new List<ScoreEventData>();

          LootLockerSDKManager.GetScoreListMain(_leaderBoardId, 10, 0, (response) =>
          {
              if (!response.success)
              {
                  Debug.LogError("Could not set name " + response.Error);
              }

          });

        return data;
    }


    public override void Load()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.LogError("error starting LootLocker session " + response.Error);

                return;
            }

            PlayerPrefs.SetString("CurrentPlayerId", response.player_id.ToString());

        });

        SetName();
    }

    public override void Save()
    {
        LootLockerSDKManager.EndSession((response) =>
        {
            if (!response.success)
            {
                Debug.LogError("error ending LootLocker session " + response.Error);

                return;
            }
        });
    }


}
