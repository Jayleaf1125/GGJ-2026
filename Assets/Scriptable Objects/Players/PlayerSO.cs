using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player/New Player")]
public class PlayerSO : ScriptableObject
{
    public string playerName;
    public PlayerSO nextPlayer;
}
