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
    [SerializeField] List<JobTypes> goodDeals;
    [SerializeField] List<JobTypes> badDeals;
    public void UseAbility() { }

}
