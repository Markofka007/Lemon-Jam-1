using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    public bool didDel = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ending Platform"))
        {
            Destroy(collision.transform.parent.gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
        }

        didDel = true;
    }
}

