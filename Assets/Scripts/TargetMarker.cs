using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TargetMarker : MonoBehaviour
{

    public delegate void OnTargetAquired(GameObject target, int cloneCount);
    public static event OnTargetAquired TargetAquired;

    private float timeDown = 0;
    private bool pointerdown = false;

    void Update()
    {
        if (pointerdown)
        {
            timeDown += Time.deltaTime;
        }
    }

    public void OnMouseDown()
    {
        pointerdown = true;
    }

    public void OnMouseUp()
    {
        if (pointerdown)
        {
            SendClonesToMe();
            Reset();
        }
    }

    private void Reset()
    {
        pointerdown = false;
        timeDown = 0;
    }

    private int CountClones()
    {
        return (int) Mathf.Floor(timeDown);
    }

    private void SendClonesToMe()
    {
        int clones = CountClones();
        if (clones > 0)
        {
            Debug.Log("Sending " + clones + " to attack me");
            TargetAquired(gameObject, clones);
        }
    }
}
