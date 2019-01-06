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

    private bool pointerdown = false;

    public void OnMouseDown()
    {
        pointerdown = true;
    }
    public void OnMouseUp()
    {
        if (pointerdown)
        {
            Reset();
        }
    }

    public void OnMouseUpAsButton()
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
    }

    private void SendClonesToMe()
    {
        Debug.Log("Sending one clone to attack me");
        TargetAquired(gameObject, 1);
    }
}
