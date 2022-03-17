using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    //This is a temporary feature for the demo and testing purposes.
    //Spawning will be added in the final build and respawning will not be present.

    void Update()
    {
        if (transform.position.y < -12)
        {
            transform.position = new Vector3(Random.Range(-20, 20), 15, 0);

            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
