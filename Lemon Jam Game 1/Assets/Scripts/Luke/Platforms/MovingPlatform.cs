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
        tempOrigin = origin.position;
        movePosition = moveTo.position;
        shouldMoveTo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldMoveTo)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePosition, Time.deltaTime * speed);
            StartCoroutine("Delay");
        }

        if(!shouldMoveTo)
        {
            transform.position = Vector3.MoveTowards(transform.position, tempOrigin, Time.deltaTime * speed);
            StartCoroutine("Delay");
        }
    }
    
    IEnumerator Delay()
    {
        float spawnDelay = speed;
        yield return new WaitForSeconds(spawnDelay);
        OtherThing();
    }

    void OtherThing()
    {
        shouldMoveTo = !shouldMoveTo;
        movePosition = moveTo.position;
        tempOrigin = origin.position;
    }

}
