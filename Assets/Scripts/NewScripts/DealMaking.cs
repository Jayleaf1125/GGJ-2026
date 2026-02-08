using UnityEngine;
using TMPro;
using UnityEditor.UI;
using UnityEngine.UI;
using UnityEngine.Rendering;
public class DealMaking : MonoBehaviour
{
    public TMP_Dropdown DealStart;
    public TMP_Dropdown DealEnd;

    public GameObject Giving;
    public GameObject Receiving;

    public int ConfirmNum = 0;


    
    void Start()
    {
        
    }

   public void DealGiver (GameObject DealerA)
    {
        Giving = DealerA;
    }

    public void DealTaker (GameObject DealerB)

    {
        Receiving = DealerB;
    }

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

     public void DealSwitchB (int ChoiceB)
    {
        switch(ChoiceB)
        {
            case 0: 
            {Receiving = GameObject.Find("Baron");
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
