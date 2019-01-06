using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 10;

    void Update()
    {
        if (health <= 0)
        {
            HandleRewardIfPresent();
            AnimateDeath();
        }
    }

    private void HandleRewardIfPresent()
    {
        Reward reward = gameObject.GetComponent<Reward>();
        if (reward != null)
            reward.Award();
    }

    void AnimateDeath()
    {
        GameObject.Destroy(gameObject);
    }
}
