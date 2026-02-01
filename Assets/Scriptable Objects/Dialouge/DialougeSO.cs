using UnityEngine;

[CreateAssetMenu(fileName = "New Dialouge Text", menuName = "Dialouge/New Dialouge Text")]
public class DialougeSO : ScriptableObject
{
    public string dialougeName;
    [TextArea(5, 20)]
    public string dialougeText;
    public Sprite dialougeImage;
    public DialougeSO nextDialougeText;
}
