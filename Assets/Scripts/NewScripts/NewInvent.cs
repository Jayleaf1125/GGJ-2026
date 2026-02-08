using System.Collections.Generic;
using UnityEngine;

public class NewInvent : MonoBehaviour
{

    public NewScore Score;
    //this list will keep track of everyone who made a deal with the inventor. These "investors" will get one point added to their score script at the end of the game.
    public List<NewUQ> Investors;
    public float InventMoney = 0;
    public float InventFake = 0;
    void Start()
    {
        Score = GetComponent<NewScore>();
    }

    public void Deal(GameObject Partner)
    {
        if(Partner ==  GameObject.Find("ConMan"))
        {
            InventFake ++;
        }
        else
        {
            InventMoney ++;
        }
    }

    
}
