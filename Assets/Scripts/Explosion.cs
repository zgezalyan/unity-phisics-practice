using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Explosion : MonoBehaviour
{
    public float TimeToExplosion;
    public float Power;
    public float Radius;

    public void Start()
    {
        
    }

    public void Update()
    {
        TimeToExplosion -= Time.deltaTime;

        if (TimeToExplosion <= 0)
            Boom();
    }

    public void Boom()
    {
        Rigidbody[] blocks = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody B in blocks)
        {
            float distance = Vector3.Distance(transform.position, B.transform.position);
            if (distance < Radius)
            {
                Vector3 dirrection = B.transform.position - transform.position;
                B.AddForce(dirrection.normalized * Power * (Radius - distance), ForceMode.Impulse);
            }
        }

        TimeToExplosion = 3;
    }
}
