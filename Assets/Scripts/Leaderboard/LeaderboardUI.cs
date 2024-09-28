using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _leaderBoardCanvas;

    [SerializeField]
    private Transform _leaderboardItemParent;

    [SerializeField]
    private GameObject _leaderboardItemPrefab;


    public async void OnGameStateChanged(EventArgs eventArgs)
    {
        GameStateChangeEventArgs gameStateChangeEventArgs = (GameStateChangeEventArgs)eventArgs;

        if (gameStateChangeEventArgs.CurrentGameState == GameStates.GameOver)
        {
            await ShowLeaderboard();
        }

        if (gameStateChangeEventArgs.CurrentGameState == GameStates.Pause)
        { 
            await ShowLeaderboard();
        }

        if (gameStateChangeEventArgs.CurrentGameState == GameStates.Leaderboard)
        {
            await ShowLeaderboard();
        }

        if (gameStateChangeEventArgs.CurrentGameState == GameStates.Gameplay)
        {
            HideLeaderboard();
        }
    }

    [ContextMenu("Show Leaderboard")]
    private async Task ShowLeaderboard() {
       
        _leaderBoardCanvas.SetActive(true);
        
        foreach (Transform child in _leaderboardItemParent)
        {
            Destroy(child.gameObject);
        }

        Debug.Log(Thread.CurrentThread.ManagedThreadId);
        var scores = await Leaderboard.Instance.GetScores();

        Debug.Log("Scores: " + scores.PlayerScores.Count);

        for (int i = 0; i < scores.PlayerScores.Count; i++)
        {
            var leaderboardItem = Instantiate(_leaderboardItemPrefab, _leaderboardItemParent);
            var score = scores.PlayerScores[i];
            leaderboardItem.GetComponent<LeaderboardItemUI>().SetLeaderboardItem(i, score.Username, score.Score);
        }
    }

    private void HideLeaderboard()
    {
        _leaderBoardCanvas.SetActive(false);
    }
}