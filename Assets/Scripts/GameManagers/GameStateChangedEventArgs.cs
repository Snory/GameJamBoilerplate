using System;

public class GameStateChangedEventArgs : EventArgs
{
    public GameState CurrentGameState;
    public GameState NewGameState;

    public GameStateChangedEventArgs(GameState currentGameState, GameState newGameState)
    {
        this.CurrentGameState = currentGameState;
        this.NewGameState = newGameState;
    }
}