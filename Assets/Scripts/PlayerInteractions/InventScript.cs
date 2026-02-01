using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventScript : MonoBehaviour
{
   public ScoreManager scoreManager;
    public GameObject Fake;
    public List<GameObject> MRisk;
    public UniqueScript Unique;
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
        }
        else 
        {
            if(GoodDeal.Contains(Partner))
            {
                scoreManager.AddMoney(1);
                MRisk.Add(Partner);
            }
            else if (BadDeal.Contains(Partner))
            {
                scoreManager.LoseMoney(1);
            }

        }

   
    }
    public void EndGame()
    {
        foreach (GameObject Partner in MRisk) 
        {
            
            Unique = Partner.GetComponent<UniqueScript>();
            Unique.InventEffect();
        }
    }

}
