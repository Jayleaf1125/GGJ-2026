using UnityEngine;

public class NewScore : MonoBehaviour
{
    //this variable keeps track of their general score, which in this case is the amount of money they have
   public float Score = 0;
   //this variable keeps track of the amount of Fake money that occurs from the effect of the con man
   public float ConScore = 0;

//general function that increases the attached gameobject's score by the amount provided in the function.
   public void AddMoney (float Amount)
    {
        Score += Amount;
    }

//this function takes away money instead of taking it.
    public void TakeMoney (float Amount)
    {
        Score -= Amount;
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
