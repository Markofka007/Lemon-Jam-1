using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public Vector3 origin;
    public GameObject yerr;

    public float hufgh;

    private void Start()
    {
        origin = yerr.transform.position;
        origin -= new Vector3(hufgh, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MainCamera")
        {
            Debug.Log("Yerr");
            yerr.transform.position = origin;
        }
    }
}
