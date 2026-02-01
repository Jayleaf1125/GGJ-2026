    using UnityEngine;
using System.Collections.Generic;
using System;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public ScoreManager scoreManager;
    
     public List<GameObject> Victims;
    [SerializeField] List<GameObject> GoodDeal;
 [SerializeField] List<GameObject> BadDeal;

    public int DrunkMoney = 0;

    public GameObject Fake;

    public void Awake()
    {
        scoreManager = GetComponent<ScoreManager>();
        //GoodDeal = new List<GameObject>(new GameObject[] {GameObject.Find("ConMan"), GameObject.Find("Textile"), GameObject.Find("Vinter"), GameObject.Find("Baron"),GameObject.Find("Dress")});
        //BadDeal = new List<GameObject>(new GameObject[] {GameObject.Find("Mine"), GameObject.Find("Invent")});
    }
    public void Start()
    {
        
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
            Victims.Add(Partner);
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
            Victims.Add(Partner);
        }
    }
    public void NewRound()
    {
        foreach(GameObject Partner in Victims)
        {
            UniqueScript Unique = gameObject.GetComponent<UniqueScript>();
            Unique.VinterEffect();
            scoreManager.AddMoney(1);
            //Debug.Log(Partner + ("Got his shit stolen"));
        }

        
    }
}
