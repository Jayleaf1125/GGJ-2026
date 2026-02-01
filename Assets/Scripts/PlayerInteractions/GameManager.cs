using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static int RoundCount = 1;
   public RailScript Rail;

   public void NextRound ()
    {
        RoundCount ++;
    }
    public void Update()
    {
    if(Input.GetKeyDown(KeyCode.E))
    {
        NextRound();
        Rail.NewRound();
    }    
    }
    


}
