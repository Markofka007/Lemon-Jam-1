using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDeleter : MonoBehaviour
{
    public backgroundManager BackgroundManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BackgroundManager.SummonBackground();
        Destroy(collision.transform.parent.gameObject);
        Destroy(collision.gameObject);
    }
}
