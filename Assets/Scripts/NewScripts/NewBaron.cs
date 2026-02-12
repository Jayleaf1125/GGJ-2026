using UnityEngine;

public class NewBaron : MonoBehaviour
{
   public NewScore Score;

 //  public RoundChange Round;
   
    //this start function executes all functions inside it as soon as the level is played/loaded
    void Start()
    {
        //this function Finds the Score script and attaches it to this scipt that way it can be accessed when the functions below call it
        Score = GetComponent<NewScore>();
      //  Round = GetComponent<RoundChange>();
    }

   public void Deal(GameObject Partner)
    {

        //this if statement handles the regular behavior that occurs during a deal, it checks if whether or not they made a deal with the con man 
        // So It can add fake dollars or not
        if(Partner == GameObject.Find("ConMan"))
        {
            Score.AddFake(3);
        }
        else
        {
            Score.AddMoney(3);
        }
    }
    public void NewRound()
    {
      //  Round.ConfirmEffect();
    }
}

//since the baron's ability is just to add 1 to its default add score, I just took care of it here. Nothing too crazy.
//2/11/26: So apparently, I misread the Baron's ability. This effect is gonna make my life uber miserable but fuck it we ball.