using UnityEngine;
using Unity.Services.Core;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using System.Collections.Generic;
using TMPro;

public class TestLobby : MonoBehaviour
{
    Lobby _hostLobby;
    float _heartbeatTimer;
    string _playerName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        _playerName = "Player" + Random.Range(10, 99);

        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log($"Signed In: {AuthenticationService.Instance.PlayerId}");
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    private void Update()
    {
        HandleLobbyHeartbeat();
    }

    async void HandleLobbyHeartbeat()
    {
        if (_hostLobby == null) return;

        _heartbeatTimer -= Time.deltaTime;

        if (_heartbeatTimer <= 0f)
        {
            float HEARTBEAT_TIMER_MAX = 15f;
            _heartbeatTimer = HEARTBEAT_TIMER_MAX;

            await LobbyService.Instance.SendHeartbeatPingAsync(_hostLobby.Id);
        }
    }

    // Make sure to change our public functions into private once we get the UI Lobby working

    public async void CreateLobby()
    {
        try
        {

            string lobbyName = "MyLobby";
            int maxPlayers = 4;

            CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions
            {
                IsPrivate = false,
                Player = GetPlayer()
            };

            Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName: lobbyName, maxPlayers: maxPlayers, options: createLobbyOptions);

            Debug.Log($"Created Lobby! | Name: {lobby.Name} | Max Players: {lobby.MaxPlayers}");
            
            _hostLobby = lobby;
            PrintPlayers(lobby);

        } catch (LobbyServiceException e)
        {
            Debug.LogError(e.Message);
        }
    }

    public async void ListLobbies()
    {
        try
        {
            QueryLobbiesOptions lobbyFilter = FilterLobbies();
            QueryResponse queryResponse = await LobbyService.Instance.QueryLobbiesAsync(options: lobbyFilter);
            List<Lobby> results = queryResponse.Results;

            Debug.Log($"Lobbies found: {results.Count}");

            //PrintPlayers(_hostLobby);

            foreach (Lobby lobby in results)
            {
                Debug.Log($"Lobby Name: {lobby.Name} | Players: {lobby.Players.Count} / {lobby.MaxPlayers}");
            }
        }
        catch (LobbyServiceException e)
        {
            Debug.LogError(e.Message);
        }
    }

    QueryLobbiesOptions FilterLobbies()
    {
        QueryLobbiesOptions queryLobbiesOptions = new QueryLobbiesOptions
        {
            Count = 25,
            Filters = new List<QueryFilter>
            {
                new QueryFilter(field: QueryFilter.FieldOptions.AvailableSlots, value: "0", op: QueryFilter.OpOptions.GT)
            },
            Order = new List<QueryOrder>
            {
                new QueryOrder(asc: false, field: QueryOrder.FieldOptions.Created)
            }
        };
        return queryLobbiesOptions;
    }
    
    // Joins the first looby, dont use in production
    public async void TestJoinLobby()
    {
        try
        {
            QueryResponse queryResponse = await LobbyService.Instance.QueryLobbiesAsync();
            Lobby joinedLobby = await LobbyService.Instance.JoinLobbyByIdAsync(queryResponse.Results[0].Id);
            Debug.Log("Joined Lobby! Test Works");
            PrintPlayers(joinedLobby);
        }
        catch (LobbyServiceException e)
        {
            Debug.LogError(e.Message);
        }
    }

    public async void QuickJoinLobby()
    {
        try
        {
            Lobby joinedLobby = await LobbyService.Instance.QuickJoinLobbyAsync();
            Debug.Log("Quick Joined Lobby Successful!");
        }
        catch (LobbyServiceException e)
        {
            Debug.LogError(e.Message);
        }
    }

    void PrintPlayers(Lobby lobby)
    {
        Debug.Log($"Players in Lobby: {lobby.Players}");

        string allCurrentPlayers = string.Empty;

        foreach (Player player in lobby.Players)
        {
            allCurrentPlayers += $"{player.Data["PlayerName"].Value} | ";
        }

        Debug.Log(allCurrentPlayers);
    }

    public void PrintSingleLobby()
    {
        if (_hostLobby == null)
        {
            Debug.LogWarning("Not the host");
            return;
        }

        //foreach (Player player in _hostLobby.Players)
        //{
        //    //Debug.Log($"{player.Data["PlayerName"].Value}");
        //    //Debug.Log("Hello");
        //}
        Debug.Log(_hostLobby.Players.Count);
    }

    public void PrintCurrentPlayerInfo()
    {
        Player player = GetPlayer();
        Debug.Log($"{player.Data["PlayerName"].Value}");
    }

    Player GetPlayer()
    {
        return new Player
        {
            Data = new Dictionary<string, PlayerDataObject> 
            {
                { "PlayerName", new PlayerDataObject(PlayerDataObject.VisibilityOptions.Member, _playerName) }
            }
        };
    }
}
