using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupermanControl : MonoBehaviour
{
    
    public GameObject MovePlane;
    public float Speed;
    public float Power;
    
    private Vector3 _supermanCenter;
    private Vector3 _destination;
    private float _xFirst;
    private float _xLast;
    private float _y;
    private float _zFirst;
    private float _zLast;

    public void Start()
    {
        float xSize = MovePlane.GetComponent<Renderer>().bounds.size.x * MovePlane.transform.lossyScale.x;
        float zSize = MovePlane.GetComponent<Renderer>().bounds.size.z * MovePlane.transform.lossyScale.z;
        _supermanCenter = GetComponent<BoxCollider>().bounds.center;
        _xFirst = MovePlane.transform.position.x - (xSize / 2);
        _xLast = _xFirst + xSize;
        _y = MovePlane.transform.position.y;
        _zFirst = MovePlane.transform.position.z - (zSize / 2);
        _zLast = _zFirst + zSize;
        _destination = new Vector3(Random.Range(_xFirst, _xLast), _y, Random.Range(_zFirst, _zLast));
        transform.LookAt(_destination);        
    }
    
    public void Update()
    {
        if (transform.position != _destination)
            transform.position = Vector3.MoveTowards(transform.position, _destination, Time.deltaTime * Speed);
        else
        {
            _destination = new Vector3(Random.Range(_xFirst, _xLast), _y, Random.Range(_zFirst, _zLast));
            transform.LookAt(_destination);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.layer == 10 && collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            _supermanCenter = GetComponent<BoxCollider>().bounds.center;
            Vector3 badGuyCenter = collision.gameObject.GetComponent<BoxCollider>().bounds.center;
            Vector3 dirrection = badGuyCenter - _supermanCenter;            
            collision.gameObject.GetComponent<Rigidbody>().AddForce(dirrection * Power, ForceMode.Impulse);
        }
    }
}
