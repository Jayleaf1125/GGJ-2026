using UnityEngine;

public class NewUQ : MonoBehaviour
{
    
    public NewScore Score;
    
        void Start()
    {
        Score = GetComponent<NewScore>();
    }

   public void VinterEffect()
    {
       Score.TakeMoney(1);
    }
    public void BaronEffect()
    {
        GameObject Bar = GameObject.Find("Baron");
        if(Bar != null)
        {
            NewBaron NB = Bar.GetComponent<NewBaron>();
            if(NB !=  null)
            {
                NB.Effect(Score.ScoreThisRound);
            }
        }
    }

    public void BossEffect()
    {
        GameObject Bos = GameObject.Find("Boss");
        if(Bos != null)
        {
            NewBoss NB = GetComponent<NewBoss>();
            if(NB != null)
            {
            NB.Effect(Score.ScoreThisRound);
            }
        }
    }
}
