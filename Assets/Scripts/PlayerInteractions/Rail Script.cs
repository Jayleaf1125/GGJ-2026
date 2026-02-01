using UnityEngine;
using System.Collections.Generic;
using System;
public class RailScript : MonoBehaviour
{
    public int RailRound = 0;

    public int RailMoney = 0;

    public ScoreManager scoreManager;
    public GameObject Fake;

    [SerializeField] List<GameObject> GoodDeal;
 [SerializeField]  List<GameObject> BadDeal;
 

    public void Awake()
    {
        scoreManager = GetComponent<ScoreManager>();
        //GoodDeal = new List<GameObject>(new GameObject[] {GameObject.Find("ConMan"), GameObject.Find("Textile"), GameObject.Find("Vinter"), GameObject.Find("Baron"),GameObject.Find("Dress")});
        //BadDeal = new List<GameObject>(new GameObject[] {GameObject.Find("Mine"), GameObject.Find("Invent")});
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

            RailMoney++;
        }
    }
    public void NewRound()
    {
        scoreManager.AddMoney(RailMoney);
    }
    
}
