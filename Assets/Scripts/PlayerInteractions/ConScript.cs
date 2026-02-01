using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConScript : MonoBehaviour
{
    public UniqueScript Unique;
    [SerializeField] List<GameObject> GoodDeal;

    [SerializeField] List<GameObject> BadDeal;
    public ScoreManager scoreManager;

    public void Awake()
    {
        scoreManager = GetComponent<ScoreManager>();
    }

    public void Deal(GameObject Partner) 
    {
        if (GoodDeal.Contains(Partner))
        {
            scoreManager.AddMoney(1);
        }
        else if (BadDeal.Contains(Partner))
        {
            scoreManager.LoseMoney(1);
        }
    }
}
