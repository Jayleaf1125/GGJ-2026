using UnityEngine;

public class ScoreManager : MonoBehaviour
{
   public float Money = 0;
   public float FakeMoney = 0;
   

   public void AddMoney(float amount)
   {
       Money += amount;
   }
    public void AddFakeMoney(float amount)
    {
         FakeMoney += amount;
    }
    public void LoseMoney(float amount)
    {
        Money -= amount;
        if (Money < 0)
        {
            Money = 0;
        }
    }
}
