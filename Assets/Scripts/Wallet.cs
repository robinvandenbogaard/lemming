using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int value;
    public int startingValue = 1000;
    
    void Start()
    {
        value = startingValue;
    }

    void OnEnable()
    {
        Reward.OnHandOutReward += AddAward;
    }

    void OnDisable()
    {
        Reward.OnHandOutReward -= AddAward;
    }

    private void AddAward(int amount)
    {
        value += amount;
    }

    public int getValue() {
        return value;
    }
}
