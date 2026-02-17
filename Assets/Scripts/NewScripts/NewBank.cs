using System.Collections.Generic;
using UnityEngine;

public class NewBank : MonoBehaviour
{
    public NewScore Score;
    public List<GameObject> BankVictims;

    public bool Loss = false;

    void Start()
    {
        Score = GetComponent<NewScore>();
    }

    public void Deal(GameObject Partner)
    {
        if(Partner == GameObject.Find("ConMan"))
        {
            BankVictims.Add(Partner);
            Score.AddFake(1);
        }
        else
        {
            BankVictims.Add(Partner);
            Score.AddMoney(1);
        }
    }

    public void BankEffect()
    {
        Loss = true;
    }

    public void EndRound ()
    {
        if(Loss)
        {
            foreach (GameObject Victim in BankVictims)
            {
                NewScore S = Victim.GetComponent<NewScore>();
                if(S != null)
                {
                    S.TakeMoney(1);
                }
            }
        }
        Loss = false;
        BankVictims.Clear();
    }

    public void ScoreReset()
    {

        Score.ScoreThisRound = 0;
    }
}
