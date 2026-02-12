using System.Collections.Generic;
using UnityEngine;

public class RoundChange : MonoBehaviour
{
   //this script will be in charge of all the effects or whatever goes on when the round changes. I may also extend it to when the game ends, if it seems beneficial.
   public static int RoundCount = 0;
   public NewRail Rail;
   public NewVinter Vinter;
   public NewBaron Baron;
   public NewBoss Boss;

   public int Order = 0;

    void Start()
    {
       
    }
    public void NewRound()
   {
      switch (Order)
        {
            case 0:
                {   
                   Rail.NewRound();
                    ConfirmEffect();
                    break;  
                }
                case 1:
                {
                    Vinter.NewRound();
                    ConfirmEffect();
                    break;
                }
                case 2:
                {
                    Baron.NewRound();
                    ConfirmEffect();
                    break;

                }
                case 3:
                {
                    Boss.NewRound();
                    ConfirmEffect();
                    break;
                }
        }
   }
   public void ConfirmEffect()
    {
        if(Order == 3)
        {
            Order = 0;
        }
        else
        {
            Order ++;
            NewRound();
        }
    }
}
