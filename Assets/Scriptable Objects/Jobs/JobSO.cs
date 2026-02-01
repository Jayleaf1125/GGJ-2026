using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public enum JobTypes
{
    OilBaron,
    RailroadTycoonOwner,
    Vinter,
    Banker,
    ConMan,
    Boss,
    MineOwner,
    Inventor
}

[CreateAssetMenu(fileName = "New Job", menuName = "Job/New Job")]
public class JobSO : ScriptableObject
{
    public JobTypes jobType;
    public float currentMoney;

    [SerializeField] List<JobTypes> goodDeals;
    [SerializeField] List<JobTypes> badDeals;
    public void UseAbility() 
    {
        switch (jobType)
        {
            case JobTypes.OilBaron:
                OilBaronAbility();
                break;
            case JobTypes.RailroadTycoonOwner:
                RailroadTycoonAbility();
                break;
            case JobTypes.Vinter: 
                VinterAbility();
                break;
            case JobTypes.Banker:
                BankerAbility();
                break;
            case JobTypes.ConMan:
                ConManAbility();
                break;
            case JobTypes.Boss:
                BossAbility();
                break;
            case JobTypes.MineOwner:
                MineOwnerAbility();
                break;
            case JobTypes.Inventor:
                InventorAbility();
                break;
        }
    }

    void OilBaronAbility() { }
    void RailroadTycoonAbility() { }
    void VinterAbility() { }
    void BankerAbility() { }
    void ConManAbility() { }
    void InventorAbility() { }
    void BossAbility() { }
    void MineOwnerAbility() { }

}
