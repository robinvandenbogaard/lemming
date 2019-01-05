using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnPoints
{
    public Transform[] spawnPoints;
    public int index = 0;

    public Transform nextTransform()
    {
        Transform result;
        result = spawnPoints[index];
        index++;
        if (index >= spawnPoints.Length)
        {
            index = 0;
        }
        return result;
    }
}
