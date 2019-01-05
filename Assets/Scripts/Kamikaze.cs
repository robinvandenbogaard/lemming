using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour
{
    public GameObject target;
    public float speed = 1;
    public int payload = 5;

    private bool hadTarget = false;

    // Update is called once per frame
    void Update()
    {
        if (!HasTarget()) 
            if (hadTarget)
                SelfDestruct();
            else
                return;

        hadTarget = true;

        RotateToTarget();
        MoveToTarget();
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }

    public bool HasTarget()
    {
        return target != null;
    }

    private void RotateToTarget()
    {
        if (target == null)
            return;

        Vector3 vectorToTarget = target.transform.position - transform.position;
        Quaternion q = Quaternion.LookRotation(Vector3.forward, vectorToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
    }

    private void MoveToTarget()
    {
        if (target == null)
            return;

        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), target.transform.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Damage(col.gameObject, payload);
        SelfDestruct();
    }

    private void Damage(GameObject target, int damage)
    {
        Health health = target.GetComponent<Health>();
        if (health != null)
        {
            health.health -= damage;
        }
    }
}
