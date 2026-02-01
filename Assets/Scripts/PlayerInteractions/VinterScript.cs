using UnityEngine;
using System.Collections.Generic;
using System;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public ScoreManager scoreManager;
    public List<GameObject> Victims;
    public List<GameObject> GoodDeal;
 public List<GameObject> BadDeal;

    public int DrunkMoney = 0;

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
        Victims.Add(Partner);
    }
    public void NewRound()
    {
        foreach(GameObject Partner in Victims)
        {
            UniqueScript Unique = gameObject.GetComponent<UniqueScript>();
            Unique.VinterEffect();
            scoreManager.AddMoney(1);
            Debug.Log(Partner + ("Got his shit stolen"));
        }

        Victims.Clear();
    }
}
