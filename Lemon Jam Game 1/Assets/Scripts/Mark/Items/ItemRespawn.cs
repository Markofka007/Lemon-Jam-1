using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    //sike, there is no respawn. the item will die when falling into the void.

    void Update()
    {
        if (transform.position.y < -25)
        {
            Destroy(gameObject);
        }
    }
}
