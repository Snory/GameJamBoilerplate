using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public partial class Leaderboard : Singleton<Leaderboard>
{
    private string _token;
    private const string _getPlayersEndpoint = "https://batiko.pythonanywhere.com/api/players";
    private const string _postPlayerEndpoint = "https://batiko.pythonanywhere.com/api/players/player";
    private const string _getScoreEndpoint = "https://batiko.pythonanywhere.com/api/score";
    private const string _postScoreEndpoint = "https://batiko.pythonanywhere.com/api/score/player_score";

    [SerializeField]
    private GeneralEvent _playerAddedEvent;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);

        _token = LeaderboardConfiguration.Token;

        Debug.Log("Leaderboard loaded");
    }

    public async void OnPlayerAddEvent(EventArgs eventArgs)
    {
        PlayerAddEventArgs playerdataAddEvent = (PlayerAddEventArgs)eventArgs;

        // check if player aready exists

        PlayerDataList players = await GetPlayers();

        foreach (PlayerData player in players.Players)
        {
            if (player.Username == playerdataAddEvent.PlayerData.Username)
            {
                _playerAddedEvent.Raise(new PlayerAddedEventArgs(false));
                return;
            }
        }

        await PostNewPlayer(playerdataAddEvent.PlayerData);
    }

    public async Task<PlayerDataList> GetPlayers()
    {
        return await GetData<PlayerDataList>(_getPlayersEndpoint);
    }

    public async Task<PlayerScoreDataList> GetScores()
    {
        return await GetData<PlayerScoreDataList>(_getScoreEndpoint);
    }

    public async Task PostNewPlayer(PlayerData playerData)
    {
        await PostData(_postPlayerEndpoint, playerData);
    }

    public async Task PostPlayerScore(PlayerScoreData playerScoreData)
    {
        await PostData(_postScoreEndpoint, playerScoreData);
    }

    private async Task PostData<T>(string endpoint, T data)
    {
        string jsonData = JsonConvert.SerializeObject(data);

        using (UnityWebRequest request = UnityWebRequest.Post(endpoint, jsonData, "application/json"))
        {
            request.SetRequestHeader("Authorization", _token);

            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error posting data: " + request.error);
            }

            _playerAddedEvent.Raise(new PlayerAddedEventArgs(true));
        }
    }

    private async Task<T> GetData<T>(string endpoint)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(endpoint))
        {
            request.SetRequestHeader("Authorization", _token);

            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error getting data: " + request.error);
            }

            return JsonConvert.DeserializeObject<T>(request.downloadHandler.text);
        }
    }
}