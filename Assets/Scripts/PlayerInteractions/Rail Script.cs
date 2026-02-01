using UnityEngine;
using System.Collections.Generic;
using System;
public class RailScript : MonoBehaviour
{
    public int RailRound = 0;

    public int RailMoney = 0;

    public ScoreManager scoreManager;

    public List<GameObject> GoodDeal;
 public List<GameObject> BadDeal;
 

    public void Awake()
    {
        GoodDeal = new List<GameObject>(new GameObject[] {GameObject.Find("ConMan"), GameObject.Find("Textile"), GameObject.Find("Vinter"), GameObject.Find("Baron"),GameObject.Find("Dress")});
        BadDeal = new List<GameObject>(new GameObject[] {GameObject.Find("Mine"), GameObject.Find("Invent")});
    }
    
   
         public void Deal(GameObject Partner)
    {
        if(GoodDeal.Contains(Partner))
        {
            scoreManager.AddMoney(1);
        }
        else if (BadDeal.Contains(Partner))
        {
            scoreManager.LoseMoney(1);
        }

        RailMoney ++;

    }
    public void NewRound()
    {
        scoreManager.AddMoney(RailMoney);
    }
    
}
