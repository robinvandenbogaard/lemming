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
            AnimateDeath();
        }
    }

    void AnimateDeath()
    {
        GameObject.Destroy(gameObject);
    }
}
