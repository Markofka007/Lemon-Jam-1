using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public float velo;
    private float maxDistance = 87.04f;

    private float distance;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * velo * Time.deltaTime;
        distance += 1 * velo * Time.deltaTime;

        if(distance > maxDistance)
        {
            transform.localPosition = new Vector3(68, 4, 10);
            distance = 0;
        }
    }
}
