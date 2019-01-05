using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTree : MonoBehaviour
{

    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        int sprite = (int)Mathf.Floor(Random.Range(0, sprites.Length));
        renderer.sprite = sprites[sprite];
    }
}
