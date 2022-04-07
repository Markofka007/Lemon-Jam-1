using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundInfo : MonoBehaviour
{
    private float distance;
    public float velo;
    public float maxDistance;

    public Vector3 origin;

    private void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * velo * Time.deltaTime;
        distance += 1 * velo * Time.deltaTime;

        if(distance >= maxDistance)
        {
            transform.position = origin;
            distance = 0;
        }
    }
}
