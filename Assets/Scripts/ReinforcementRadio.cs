using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinforcementRadio : MonoBehaviour
{

    public int desiredCloneCount = 3;
    public string spawnTag = "clone";
    public GameObject clonePrefab;
    public SpawnPoints spawnPoints;

    // Update is called once per frame
    void Update()
    {
        int cloneCount = CountClones();
        if (RequireMoreClones(cloneCount))
        {
            RefillClones(cloneCount);
        }
    }

    private void RefillClones(int cloneCount)
    {
        for (int i=0; i < desiredCloneCount - cloneCount ; i++)
        {
            Instantiate(clonePrefab, spawnPoints.nextTransform().position, new Quaternion());
        }
        
    }

    private bool RequireMoreClones(int cloneCount)
    {
        return cloneCount < desiredCloneCount;
    }

    private int CountClones()
    {
        return GameObject.FindGameObjectsWithTag(spawnTag).Length;
    }
}
