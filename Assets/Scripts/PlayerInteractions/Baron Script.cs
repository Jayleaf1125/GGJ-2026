using UnityEngine;
using System.Collections.Generic ;
using System;


public class BaronScript : MonoBehaviour
{   
    [SerializeField] List<GameObject> GoodDeal;
    
    [SerializeField] List<GameObject> BadDeal;
    public ScoreManager scoreManager;

    public GameObject Fake;


    public void Awake()
    {
        scoreManager = GetComponent<ScoreManager>();
        //this form of finding gameobjects works for now. The unity window itself was messed up so.
        //GoodDeal = new List<GameObject>(new GameObject[] {GameObject.Find("ConMan"), GameObject.Find("Textile"), GameObject.Find("Vinter"), GameObject.Find("RailRoad")});
        //BadDeal = new List<GameObject>(new GameObject[] {GameObject.Find("Vinter"), GameObject.Find("Dress"), GameObject.Find("Mine"), GameObject.Find("Invent")});
    }
    public void Deal(GameObject Partner)
    {
        if (Partner == Fake)

        {
            if (GoodDeal.Contains(Partner))
            {
                scoreManager.AddFakeMoney(1);
            }
            else if (BadDeal.Contains(Partner))
            {
                scoreManager.LoseFakeMoney(1);
            }

            scoreManager.AddFakeMoney(3);
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

            scoreManager.AddMoney(3);
        }
    }
}
