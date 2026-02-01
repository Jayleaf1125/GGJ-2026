using UnityEngine;

public class UniqueScript : MonoBehaviour
{
    public ScoreManager scoreManager;

    public void Awake()
    {
        scoreManager = GetComponent<ScoreManager>();
    }
    public void VinterEffect()
    {
        scoreManager.LoseMoney(1);
        
    }
    public void InventEffect() 
    {
        scoreManager.AddMoney(1);
    }
}
