using System.Collections.Generic;
using UnityEngine;

public class NewVinter : MonoBehaviour
{

    public NewScore Score;
    //this List will keep track of the people the vinter made deals with. This will allow for the vinter to execute the Vinter effect next round
    public List<NewUQ> Victims;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   // public RoundChange Round;
    void Start()
    {
       Score = GetComponent<NewScore>(); 
      // Round = GetComponent<RoundChange>();
    }

    public void Deal (GameObject Partner)
    {
        if(Partner == GameObject.Find("ConMan"))
        {
            Score.AddFake(1);
            //this finds the new Unique script  
            NewUQ vint = gameObject.GetComponent<NewUQ>();
            //if it finds the script, which I hope it does, it will add that specific gameobject's script to the list so it will be a target for the effect next round
            if(vint != null)
            {
                Victims.Add(vint);
            }
            
        }
        else
        {
            Score.AddMoney(1);
             NewUQ vint = Partner.GetComponent<NewUQ>();
            if(vint != null)
            {
                Victims.Add(vint);
            }
        }
    }

    public void NewRound()
    {
        foreach(NewUQ VE in Victims)
        {
           VE.VinterEffect();
           Score.AddMoney(1);
        }
        Victims.Clear();
       // Round.ConfirmEffect();
    }
}
