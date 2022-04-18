using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBack : MonoBehaviour
{
    public float spot;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if(transform.position.x < startPos.x - spot)
        {
            transform.position = startPos;
        }
    }
}
