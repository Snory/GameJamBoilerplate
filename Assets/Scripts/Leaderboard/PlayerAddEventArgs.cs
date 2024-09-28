using System;
using static Leaderboard;

public class PlayerAddEventArgs : EventArgs
{
    public PlayerData PlayerData;

    public PlayerAddEventArgs(PlayerData playerData)
    {
        this.PlayerData = playerData;
    }
}