using System;

[Serializable]
public class HighScoreData
{
    public string PlayerName;
    public int Score;

    public HighScoreData(string playerName, int score)
    {
        PlayerName = playerName;
        Score = score;
    }
}
