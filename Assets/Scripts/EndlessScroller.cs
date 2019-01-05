using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessScroller : MonoBehaviour
{

    public float lowerBound;
    public float upperBound;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        lowerBound = -8;
        upperBound = 8;
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform)
        {
            Vector3 newPosition = child.position - new Vector3(0, Time.deltaTime * speed, 0);
            if (newPosition.y < lowerBound)
            {
                newPosition.y = upperBound; 
            }
            child.position = newPosition;
        }
    }
}
