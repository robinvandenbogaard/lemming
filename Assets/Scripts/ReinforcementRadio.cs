using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinforcementRadio : MonoBehaviour
{

    public int desiredCloneCount = 3;
    public GameObject clonePrefab;

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
        Instantiate(clonePrefab, transform);
    }

    private bool RequireMoreClones(int cloneCount)
    {
        return cloneCount < desiredCloneCount;
    }

    private int CountClones()
    {
        return GameObject.FindGameObjectsWithTag("clone").Length;
    }
}
