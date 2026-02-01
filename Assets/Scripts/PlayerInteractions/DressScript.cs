using System.Collections.Generic;
using UnityEngine;

public class DressScript : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameObject Fake;

    public List<GameObject> Investors;
    [SerializeField] List<GameObject> GoodDeal;

    [SerializeField] List<GameObject> BadDeal;

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
            Investors.Add(Partner);
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
            Investors.Add(Partner);
        }
       
    }

    public void NextRound() 
    {
        foreach (GameObject Partner in Investors) 
        {
            Debug.Log(Partner + ("Lost money lmao"));
        }
    }
}
