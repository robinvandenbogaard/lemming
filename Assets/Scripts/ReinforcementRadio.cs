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
    public bool autoSummon = false;

    // Update is called once per frame
    void Update()
    {
        if (autoSummon)
        {
            SummonReinforcements();
        }
    }

    public void SummonReinforcements()
    {
        int cloneCount = CountClones();
        if (RequireMoreClones(cloneCount))
        {
            RefillClones(cloneCount);
        }
    }


    private void RefillClones(int cloneCount)
    {
        int clonesToSummon = desiredCloneCount - cloneCount;

        for (int i=0; i < clonesToSummon ; i++)
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
