using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStates
{
    MainMenu,
    Leaderboard,
    Gameplay,
    Pause,
    GameOver
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameStates _currentGameState;

    public GeneralEvent GameStateChanged;

    public void OnGameplaySceneLoaded()
    {
        TransitToState(GameStates.Gameplay);
    }

    public void OnLeaderboardLoaded()
    {
        TransitToState(GameStates.Leaderboard);
    }

    public void OnGameOver()
    {
        TransitToState(GameStates.GameOver);
    }

    public void OnPauseGame()
    {
        TransitToState(GameStates.Pause);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneManager.LoadScene(SceneNames.MainMenu, LoadSceneMode.Single);
        TransitToState(GameStates.MainMenu);
    }

    private void TransitToState(GameStates newState)
    {
        _currentGameState = newState;
        switch (_currentGameState)
        {
            case GameStates.Pause:
                Time.timeScale = 0;
                break;
            case GameStates.GameOver:
                Time.timeScale = 0;
                break;
            case GameStates.Leaderboard:
                Time.timeScale = 0;
                break;
            default:
                Time.timeScale = 1;
                break;
        }

        GameStateChanged.Raise(new GameStateChangeEventArgs(_currentGameState));
    }
}