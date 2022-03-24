using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBack : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Guh");
        collision.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
    }
}
