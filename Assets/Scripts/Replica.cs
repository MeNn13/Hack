using System;
using System.Collections.Generic;
using UnityEngine;

public class Replica : MonoBehaviour
{
    public Sprite Avatar;
    public byte Index = 0;
    public List<Job> Jobs;
}

[Serializable]
public class Job
{
    public string Description;
    public TypeJob JobType;
    public TypeUnit Unit;
    public int Count;
}
