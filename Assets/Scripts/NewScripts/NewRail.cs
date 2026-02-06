using System.Collections.Generic;
using UnityEngine;

public class NewRail : MonoBehaviour
{
   public NewScore Score;

   //this float will contain the total amount of deals that the Rail character makes and will add it to the score when the next round function is called 
   public float RailToken = 0;

   //This float only increases when making a deal with the con man
   public float RailFake = 0;
    void Start()
    {
        Score = GetComponent<NewScore>();
    }

   public void Deal(GameObject Partner)
    {
        if (Partner == GameObject.Find("ConMan"))
        {
            RailFake ++;
        }
        else
        {
            RailToken ++;
        }
    }

//this function gets called by a game manager whenever a new round starts. It automatially adds the score at the start of the new round but thats fine since the scores 
//are not shown till the end of the round.
    public void NewRound()
    {
        Score.AddMoney(RailToken);
        Score.AddFake(RailFake);
    }
}
