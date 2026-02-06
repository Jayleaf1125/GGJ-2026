using UnityEngine;

public class NewBaron : MonoBehaviour
{
   public NewScore Score;
   
    //this start function executes all functions inside it as soon as the level is played/loaded
    void Start()
    {
        //this function Finds the Score script and attaches it to this scipt that way it can be accessed when the functions below call it
        Score = GetComponent<NewScore>() ;
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
}

//since the baron's ability is just to add 1 to its default add score, I just took care of it here. Nothing too crazy.