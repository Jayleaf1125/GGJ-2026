using UnityEngine;
using TMPro;
using UnityEditor.UI;
using UnityEngine.UI;
using UnityEngine.Rendering;
public class DealMaking : MonoBehaviour
{
    //This is responsible For the dropdown menu on the left, which represents the Gameobject/Character starting the deal
    public TMP_Dropdown DealStart;
    //This is responsible for the dropdown menu on the right, which represents the Gameobject/Character receiving the deal.
    public TMP_Dropdown DealEnd;

    //This is responsible for fetching the gameobject that was chosen on the DealStart Menu
    public GameObject Giving;
    //This is responsible for fetching the gameobject that was chosen on the DealEnd Menu
    public GameObject Receiving;

    //This was a major fucking key of making this work. This synchronizes the GameObject and their script, so whichever GameObject/Character was chosen on the DealEnd
    //Menu, their script was gonna receive the deal function with the input of the giving GameObject, which is the Character which started the trade.
    public int ConfirmNum = 0;


    
    void Start()
    {
        
    }

//idk what these 2 functions are. I guess they were my first attempt at trying to make this work. DO NOT touch these regardless since 
//I dont know if they are linked or not, so better safe than sorry

   public void DealGiver (GameObject DealerA)
    {
        Giving = DealerA;
    }

    public void DealTaker (GameObject DealerB)

    {
        Receiving = DealerB;
    }

    //This function activates when a selection is made on the DealStart Menu. It changes the Giving Gameobject variable to whatever Selection was made. 
    // Each selection is tied to a number (Baron is 0. RailRoad is 1 and so on..) 
    public void DealSwitchA (int ChoiceA)
    {
        switch(ChoiceA)
        {
            case 0: 
            {
                Giving = GameObject.Find("Baron");
               
                break;}
            case 1: Giving = GameObject.Find("Rail"); break;
            case 2: Giving = GameObject.Find("Vinter"); break;
            case 3: Giving = GameObject.Find("Banker"); break;
            case 4: Giving = GameObject.Find("ConMan"); break;
            case 5: Giving = GameObject.Find("Boss"); break;
            case 6: Giving = GameObject.Find("Mine"); break;
            case 7: Giving = GameObject.Find("Invent"); break;
        }
    }
    //This function activates when a selection is made on the DealEnd Menu. It changes the Receiving GameObject variable to whatever selection is made.
    //The numbering order is the same as the one above so yeah..

     public void DealSwitchB (int ChoiceB)
    {
        switch(ChoiceB)
        {
            case 0: 
            {Receiving = GameObject.Find("Baron");
            //This is VERY important in me figuring this out, it will make sense near the end of this script.
            ConfirmNum = ChoiceB;
             break;}
            case 1: 
            {
                Receiving = GameObject.Find("Rail");
                ConfirmNum = ChoiceB;
                break;
                }
            case 2:
            {
                Receiving = GameObject.Find("Vinter");
               ConfirmNum = ChoiceB;
                break;
            }
            case 3: 
            {
                Receiving = GameObject.Find("Banker");
                ConfirmNum = ChoiceB;
                //  Receiving = Receiving.GetComponent<NewBanker>();
                break;
            }
            case 4:
             {Receiving = GameObject.Find("ConMan");
             //Receiving.GetComponent<NewConMan>();
             ConfirmNum = ChoiceB;
             break;}
            case 5: 
            {
                Receiving = GameObject.Find("Boss");
                ConfirmNum = ChoiceB;
                break;
            }
            case 6: 
            {
                Receiving = GameObject.Find("Mine");
               ConfirmNum = ChoiceB;
                break;
            }
            case 7:
            {
                Receiving = GameObject.Find("Invent");
               ConfirmNum = ChoiceB;
                break;
                }
        }
    }

        //This function activates when the button is pressed, which starts the Deal Process. THIS TOOK SO FUCKING LONG TO MAKE.
        //  It takes the ConfirmNum Variable which was mentioned earlier, which allows me to find the Script to match the GameObject/Character selected. 
        //It then executes the Deal function with the input of the Giving GameObject, allowing Character Effects to go off smoothly, I am so tired but it was so worth it.
    public void DealConfirm()
    {
        switch (ConfirmNum)
        {
            case 0: 
            {
                NewBaron BaronD = Receiving.GetComponent<NewBaron>();
                if(BaronD !=null)
                    {
                        BaronD.Deal(Giving);
                    }
                return;
            }
            case 1: 
            {
                NewRail RailD = Receiving.GetComponent<NewRail>();
                if(RailD != null)
                    {
                        RailD.Deal(Giving);
                    }
                return;
            }
            case 2:
                {
                    NewVinter VinterD = Receiving.GetComponent<NewVinter>();
                    if(VinterD != null)
                    {
                        VinterD.Deal(Giving);
                    }
                    break;
                }
            case 3:
                {
                    /*NewBanker BankerD = Receiving.GetComponent<NewBanker>();
                    if(BankerD != null)
                    {
                        BankerD.Deal(Giving);
                    */
                    break;
                    
                }
                case 4:
                {
                    /*NewConMan ConManD = Receiving.GetComponent<NewConMan>();
                    if(ConManD != null)
                    {
                        ConManD.Deal(Giving);
                    }*/
                    break;
                }
                case 5:

                {
                    NewBoss BossD = Receiving.GetComponent<NewBoss>();
                    if(BossD != null)
                    {
                        BossD.Deal(Giving);
                    }
                    break;
                }
                case 6:

                {
                    NewMine MineD = Receiving.GetComponent<NewMine>();
                    if(MineD != null)
                    {
                        MineD.Deal(Giving);
                    }
                    break;
                }
                case 7:

                {
                    NewInvent InventD = Receiving.GetComponent<NewInvent>();
                    if(InventD != null)
                    {
                        InventD.Deal(Giving);
                    }
                    break;
                }
        }
      
    }
}
