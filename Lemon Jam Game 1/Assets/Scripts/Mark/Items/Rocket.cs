using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private void Start()
    {
        this.Wait(3.0f, () =>
        {
            Destroy(gameObject);
        });
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<CircleCollider2D>().enabled = true;
        transform.GetComponentInChildren<SpriteRenderer>().enabled = false;

        this.Wait(0.1f, () =>
        {
            Destroy(gameObject);
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 relPos = collision.transform.position - transform.position;

        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(relPos / 2.5f * 20f, ForceMode2D.Impulse);
    }
}