using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticStagePlayerDeath : MonoBehaviour
{
    public StaticStageGameManager gm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name + " Entered the trigger");
        gm.PlayerDeath(collision.gameObject);
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
