using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameObject Fake;
    [SerializeField] List<GameObject> GoodDeal;

    [SerializeField] List<GameObject> BadDeal;

    public int Chance = 0;

    public int RandomAttempt = 0;
    public void Awake()
    {
        scoreManager = GetComponent<ScoreManager>();
    }

    public void Deal(GameObject Partner) 
    { 
        if(Partner == Fake) 
        {
            if (GoodDeal.Contains(Partner))
            {
                scoreManager.AddFakeMoney(1);
            }
            else if (BadDeal.Contains(Partner))
            {
                scoreManager.LoseFakeMoney(1);
            }
        }
        else 
        {
            if (GoodDeal.Contains(Partner))
            {
                scoreManager.AddMoney(1);
            }
            else if (BadDeal.Contains(Partner))
            {
                scoreManager.LoseMoney(1);
            }
            Chance += 5;
            scoreManager.AddMoney(1);
        }
    }
    public void EndGame()
    {
        RandomAttempt = Random.Range(0, 100);
        if (RandomAttempt < Chance) {
            scoreManager.AddMoney(8);
        }
    }
}
