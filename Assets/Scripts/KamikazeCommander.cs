using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeCommander : MonoBehaviour
{
    void OnEnable()
    {
        TargetMarker.TargetAquired += IssueCommand;
    }


    void OnDisable()
    {
        TargetMarker.TargetAquired -= IssueCommand;
    }

    private void IssueCommand(GameObject target, int cloneCount)
    {
        GameObject[] clones = GameObject.FindGameObjectsWithTag("clone");
        Debug.Log("Found " + clones.Length + " clones to attack with");
        int clonesAssignedTarget = 0;
        foreach (GameObject clone in clones)
        {
            if (clonesAssignedTarget == cloneCount)
                break;

            if (MarkTargetFor(clone, target))
            {
                clonesAssignedTarget++;
            }
            
        }
    }

    private bool MarkTargetFor(GameObject clone, GameObject target)
    {
        bool targetHasBeenSet = false;
        Kamikaze kamikaze = clone.GetComponent<Kamikaze>();
        if (!kamikaze.HasTarget())
        {
            kamikaze.target = target;
            targetHasBeenSet = true;
        }

        return targetHasBeenSet;
    }
}
