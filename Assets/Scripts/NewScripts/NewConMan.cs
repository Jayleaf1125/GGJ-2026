using UnityEngine;

public class NewConMan : MonoBehaviour
{
   
   public NewScore Score;

    void Start()
    {
        Score = GetComponent<NewScore>();
    }


    public void Deal(GameObject Partner)
    {
        Score.AddMoney(1);
    }
    
}
