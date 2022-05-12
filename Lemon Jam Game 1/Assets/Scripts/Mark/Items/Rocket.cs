using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float powerMultiplier;
    private Vector3 rocketPos;
    public GameObject theExplosion;

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
        rocketPos = transform.position;

        this.Wait(0.1f, () =>
        {
            Instantiate(theExplosion, rocketPos, Quaternion.identity);
            Destroy(gameObject);
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 relPos = collision.transform.position - transform.position;

        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(relPos / 50f * powerMultiplier, ForceMode2D.Impulse);
    }
}
