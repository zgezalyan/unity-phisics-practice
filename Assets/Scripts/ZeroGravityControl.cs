using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravityControl : MonoBehaviour
{

    public GameObject StartPoint;
    public GameObject EndPoint;
    public float Speed;
    public float FreezeTime;

    private Vector3 _destination;
    private float _freezeTimeLeft;
        
    void Start()
    {
        _destination = EndPoint.transform.position;
        _freezeTimeLeft = FreezeTime;
    }
    
    void Update()
    {
        if (transform.position != _destination)
            transform.position = Vector3.MoveTowards(transform.position, _destination, Time.deltaTime * Speed);
        else
        {
            if (_freezeTimeLeft >= 0)
                _freezeTimeLeft -= Time.deltaTime;
            else
            {
                if (_destination == StartPoint.transform.position)
                    _destination = EndPoint.transform.position;
                else
                    _destination = StartPoint.transform.position;
                _freezeTimeLeft = FreezeTime;
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {        
        if (collider.gameObject.GetComponent<Rigidbody>() != null)
            collider.gameObject.GetComponent<Rigidbody>().useGravity = false;        
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<Rigidbody>() != null)
            collider.gameObject.GetComponent<Rigidbody>().useGravity = true;        
    }

}
