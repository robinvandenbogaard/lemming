using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{

    public delegate void HandOutReward(int amount);
    public static event HandOutReward OnHandOutReward;

    public int value = 0;

    internal void Award()
    {
        Debug.Log("Destroying a object with reward. Rewarding event for " + value);
        OnHandOutReward(value);
    }
}
