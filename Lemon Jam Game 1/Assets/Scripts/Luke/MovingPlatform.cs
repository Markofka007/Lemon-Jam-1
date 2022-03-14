using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform moveTo;//The location to interpolate to
    public Transform origin;//The original location
    public float speed = 5;

    private Vector3 velocity = Vector3.zero;
    private Vector3 movePosition;
    private bool shouldMoveTo;
    private Vector3 tempOrigin;
    
    // Start is called before the first frame update
    void Start()
    {
        tempOrigin = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != movePosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePosition, Time.deltaTime * speed);
        }

        if(transform.position != movePosition)
        {
            //transform.position = Vector3()
        }
    }
       
}
