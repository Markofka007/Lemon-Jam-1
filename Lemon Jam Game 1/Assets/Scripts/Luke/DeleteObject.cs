using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Ending Platform"))
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            Destroy(collision.gameObject);
        }
    }
}

