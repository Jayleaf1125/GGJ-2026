using UnityEngine;
using Unity.Services.Core;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using System.Collections.Generic;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    private protected override void Awake()
    {
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // -- Works for listing out the players in the lobby
        //for (int i = 0; i < 3; i++)
        //{
        //    _playerList.text += $"\nplayer{i}";
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
