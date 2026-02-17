using UnityEngine;

public class NewMine : MonoBehaviour
{
   public NewScore Score;
   //this float tracks the chance that the miner has of striking gold. This float will be compared to whatever number rolled when it comes time to it
   // (specifically, at the end of a round)
   public float GoldProb = 0;
   
   //this bool checks if the Miner made a deal with the con man
   public bool Conned = false;

   //this number will be converted to a random number between 1 and 100, which will then be compared to the gold probability to decide if the miner strikes gold
    public float GoldDecider = 0;
    void Start()
    {
        Score = GetComponent<NewScore>();
    }

    public void Deal(GameObject Partner)
    {
        if(Partner == GameObject.Find("ConMan"))
        {
            Conned = true;
        }
        else
        {
            //this just increases the chances of striking gold by 5 percent i think
            GoldProb += 5;
            Score.AddMoney(1);
        }
    }

    //I might implement this function to all of the other characters. This function is the first time I am adding it/conceptualizing it.
    //  This may be useful since I would have to display scores at end of Round, but I can probably just do that on the score manager script instead.  
    public void EndRound()
    {
        GoldDecider = Random.Range(1, 100);
        if(GoldDecider < GoldProb)
        {
            Score.AddMoney(2);
        }
    }

    public void ScoreReset()
    {

        Score.ScoreThisRound = 0;
    }
    
}
