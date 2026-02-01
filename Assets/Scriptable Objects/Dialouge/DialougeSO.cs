using UnityEngine;

[CreateAssetMenu(fileName = "New Dialouge Text", menuName = "Dialouge/New Dialouge Text")]
public class DialougeSO : ScriptableObject
{
    public string dialougeName;
    public string dialougeText;
    public Sprite dialougeImage;
    public DialougeSO nextDialougeText;
}
