using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextileScript : MonoBehaviour
{
    [SerializeField]  List<GameObject> GoodDeal;

    [SerializeField] List<GameObject> BadDeal;

    public ScoreManager scoreManager;
    public GameObject Fake;


    public void Awake()
    {
        scoreManager = GetComponent<ScoreManager>();
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

            
        }

    }
    public void EndGame()
    {

    }
}
