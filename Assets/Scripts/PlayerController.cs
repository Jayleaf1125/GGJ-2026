using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{

    NetworkVariable<FixedString64Bytes> _playerName = new NetworkVariable<FixedString64Bytes>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!IsOwner) return;
        _playerName.Value = GeneratePlayerName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    FixedString64Bytes GeneratePlayerName() => $"Player{Random.Range(10, 99)}";
}
