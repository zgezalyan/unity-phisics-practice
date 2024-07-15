using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBallControl : MonoBehaviour
{

    public float ForceAmount;
    public GameObject DirrectionBoard;
    public float TimeToHit;

    private bool _needToHit;

    public void Start()
    {
        _needToHit = true;        
    }

    public void Update()
    {
        TimeToHit -= Time.deltaTime;

        if (TimeToHit <= 0 && _needToHit)
        {
            Hit();
            _needToHit = false;
        }
    }

    public void Hit()
    {
        Vector3 destinationCenter = DirrectionBoard.GetComponent<BoxCollider>().bounds.center;
        Vector3 dirrection = destinationCenter - transform.position;
        GetComponent<Rigidbody>().AddForce(dirrection * ForceAmount, ForceMode.Impulse);
    }
}
