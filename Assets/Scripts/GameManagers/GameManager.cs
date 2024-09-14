using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
public enum GameState { GAMEPLAY, PAUSED, MAINMENU }

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private string _startScene;


    [SerializeField]
    private GameState _currentGameState = GameState.MAINMENU;

    public GameState GameState { get => _currentGameState; }

    [SerializeField]
    private GeneralEvent _gameStateChangedEvent;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void TransitToState(GameState newGameState)
    {
        _gameStateChangedEvent.Raise(new GameStateChangedEventArgs(_currentGameState, newGameState));
        _currentGameState = newGameState;

        switch (newGameState)
        {
            case GameState.PAUSED:
                Time.timeScale = 0f;
                break;
            default:
                Time.timeScale = 1f;
                break;
        }

    }

    private void Start()
    {
        SceneManager.LoadScene(_startScene, LoadSceneMode.Single);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void OnGamePlayStarted()
    {
        TransitToState(GameState.GAMEPLAY);
    }

    public void OnMainMenu()
    {
        TransitToState(GameState.MAINMENU);
    }


    private void PauseGame()
    {
        if(_currentGameState == GameState.PAUSED)
        {
            TransitToState(GameState.GAMEPLAY);
        } else if(_currentGameState == GameState.GAMEPLAY)
        {
            TransitToState(GameState.PAUSED);
        }
    }

    public void RestartGame()
    {
        if(_currentGameState == GameState.MAINMENU)
        {
            return;
        }

        TransitToState(GameState.GAMEPLAY);
    }

    private void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
    }

}
