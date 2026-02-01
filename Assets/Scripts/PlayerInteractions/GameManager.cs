using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public  int RoundCount = 1;
   public RailScript Rail;
    public NewMonoBehaviourScript Vinter;
    public GameObject Partner;

    public DressScript Dress;

    public InventScript Invent;
    public MineScript Mine;
    public TextileScript Bank;
    public ConScript Con;

    public ScoreManager one;
    public ScoreManager two;
    public ScoreManager three;
    public ScoreManager four;
    public ScoreManager five;
    public ScoreManager six;
    public ScoreManager seven;
    public ScoreManager eight;
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
            Debug.Log("Next Round");
            Vinter.Deal(Partner);
            Vinter.NewRound();
            Dress.Deal(Partner);
            Dress.NextRound();
    }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Invent.EndGame();
            Mine.EndGame();
            Bank.EndGame();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Scores Are" + one.Money + two.Money + three.Money + four.Money + five.Money + six.Money + seven.Money + eight.Money);
            
        }
    }
  
    


}
