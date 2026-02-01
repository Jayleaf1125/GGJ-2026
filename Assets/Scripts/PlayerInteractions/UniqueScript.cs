using UnityEngine;

public class UniqueScript : MonoBehaviour
{
    public ScoreManager scoreManager;
    public void VinterEffect()
    {
        scoreManager.LoseMoney(1);
        
    }
}
