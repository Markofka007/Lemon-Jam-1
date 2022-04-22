using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    private float totalTime;

    private Vector3 initialPos;

    void Start()
    {
        initialPos = transform.position;

        totalTime = Random.Range(0f, 1f);
    }
    
    void Update()
    {
        totalTime += Time.deltaTime;

        transform.position =  initialPos + new Vector3(0, Mathf.Sin(totalTime * 5f) * 0.25f, 0);
    }
}
