using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDeleter : MonoBehaviour
{
    public bool didDel = false;//bool for background management

    private void OnTriggerEnter2D(Collider2D collision)
    {
        didDel = true;
        Destroy(collision.transform.parent.gameObject);
        Destroy(collision.gameObject);
    }
}
