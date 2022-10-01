using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerRefsScoreRepository : RepositoryBase
{

    private List<ScoreEventData> _results;

    public override void Add(ScoreEventData item)
    {
        _results.Add(item);

    }

    public override IEnumerable<ScoreEventData> FindAll()
    {
        return _results.Select(item => new ScoreEventData(item.ScoreData));
    }

    public override void Load()
    {
        List<ScoreData> dataList = new List<ScoreData>();
        if (PlayerPrefs.HasKey("Score"))
        {
            //rozparsovat json
            string data = PlayerPrefs.GetString("Score");

            //narvat do results   
            dataList = JsonUtility.FromJson<SerializableList<ScoreData>>(data).WrappedList;
        }
                
    }

    public override void Save()
    {
        string data = "";

        PlayerPrefs.SetString("Score", data);
    }
}
