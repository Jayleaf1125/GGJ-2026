using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.Collections;
using Unity.Netcode;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.VisualScripting;
using UnityEngine;

public class LobbyManager : Singleton<LobbyManager>
{
    [SerializeField] string _lobbyName;
    [SerializeField] int _maxPlayers = 8;
    [SerializeField] TextMeshProUGUI _lobbyText;

    Lobby _hostLobby;
    public static string LobbyCode { get; private set; }
    float _heartbeatTimer;

    public event Action<FixedString64Bytes> OnPlayerJoin = delegate { };

    //public event Action<string> OnLobbyCode = delegate { };

    private protected override void Awake()
    {
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log($"Signed In: {AuthenticationService.Instance.PlayerId}");
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        _lobbyText.text = _lobbyName;
    }

    // Update is called once per frame
    void Update()
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

    //[Rpc(SendTo.Server)]
    async public void CreateLobby()
    {
        try
        {
            CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions
            {
                IsPrivate = true
            };

            Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName: _lobbyName, maxPlayers: _maxPlayers, options: createLobbyOptions);

            if (_hostLobby == null)
            {
                _hostLobby = lobby;          
                LobbyCode = lobby.LobbyCode;
            }

            UIManager.instance.UpdateLobbyCodeText(LobbyCode);
        }
        catch (LobbyServiceException e)
        {
            Debug.LogError(e.Message);
        }
    }

    public async void JoinLobbyByCode(string code)
    {
        try
        {
            QueryResponse queryResponse = await LobbyService.Instance.QueryLobbiesAsync();
            JoinLobbyByCodeOptions options = new JoinLobbyByCodeOptions
            {
                Player = GenerateRandomPlayer(),
            };

            Lobby joinedLobby = await LobbyService.Instance.JoinLobbyByCodeAsync(code, options);
            Debug.Log("Joined Lobby!");
            UIManager.instance.MoveToLobby();
            UIManager.instance.UpdatePlayerList(options.Player.Data["PlayerName"].Value);
            //PrintPlayers();
        }
        catch (LobbyServiceException e)
        {
            Debug.LogError(e.Message);
        }
    }

    void PrintPlayers()
    {
        string allCurrentPlayers = string.Empty;

        foreach (Player player in _hostLobby.Players)
        {
            allCurrentPlayers += $"{player.Data["PlayerName"].Value} | ";
            //Debug.Log(player.Id);
        }

        Debug.Log(allCurrentPlayers);
    }

    Player GenerateRandomPlayer()
    {
        string playerName = $"Player{UnityEngine.Random.Range(10, 99)}";

        return new Player
        {
            Data = new Dictionary<string, PlayerDataObject>
            {
                { "PlayerName", new PlayerDataObject(PlayerDataObject.VisibilityOptions.Member, playerName) }
            }
        };
    }
}
