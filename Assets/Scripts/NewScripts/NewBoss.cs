using System.Collections.Generic;
using UnityEngine;

public class NewBoss : MonoBehaviour
{
    public NewScore Score;

  //  public RoundChange Round;

    //this list keeps tranks of "BUsiness Partners" that the boss makes, using this to activate his ability at the start of the new round
    public List<NewUQ> BP;

    public List<NewUQ> AP;
    
    void Start()
    {
        Score = GetComponent<NewScore>();
      //  Round = GetComponent<RoundChange>();
    }

   public void Deal(GameObject Partner)
    {
        if(Partner == GameObject.Find("ConMan"))
        {
            Score.AddFake(1);
        }
        else
        {
            Score.AddMoney(1);
            //similar to the vinter, this is to add the script of the other cahracter into the Boss's list.
            NewUQ Bos = Partner.GetComponent<NewUQ>();
            BP.Add(Bos);
        }
    }

    public void NewRound()
    {
        foreach(NewUQ Cooked in BP)
        {
            AP.Add(Cooked);
        }
        BP.Clear();
    }

    public void EndRound()
    {
       foreach(NewUQ Twin in AP)
        {
            Debug.Log("pluh");
            Twin.BossEffect();
        }
        AP.Clear();
    }
    public void Effect(float Amount)
    {
        
        Score.AddMoney(Amount/2);
    }
}
