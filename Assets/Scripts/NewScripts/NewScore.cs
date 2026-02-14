using UnityEngine;

public class NewScore : MonoBehaviour
{
    //this variable keeps track of their general score, which in this case is the amount of money they have
   public float Score = 0;
   //this variable keeps track of the amount of Fake money that occurs from the effect of the con man
   public float ConScore = 0;

   public float ScoreThisRound = 0;

//this variable is responsible for associating the script with the character (for example, the banker would have the variable set to the banker game object)
   public GameObject Character;

   void Start()
    {
        //this finds the gameobject this script is attached to and changes the variable to that gameobject
        Character = gameObject;
    }

    //general function that increases the attached gameobject's score by the amount provided in the function.
    public void AddMoney (float Amount)
    {
        Score += Amount;
        ScoreThisRound += Amount;
    }

//this function takes away money instead of taking it.
    public void TakeMoney (float Amount)
    {
        Score -= Amount;
        ScoreThisRound -= Amount;
        //this checks if the gameobject this script is attached to is the banker, that way the banker's effect can activate.
        if(Character == GameObject.Find("Banker"))
        {
            NewBank B = Character.GetComponent<NewBank>();
            if(B != null)
            {
                B.BankEffect();
            }
        }
    }

//this function increases the ConScore which is unique to the conman Character.
    public void AddFake (float Amount)
    {
        ConScore += Amount;
    }
    
    //does the same shit as the other one if we keeping it a bean.
    public void TakeFake(float Amount)
    {
        ConScore -= Amount;
    }
}
