using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Go Back please"))
        {
            collision.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
    }
}
