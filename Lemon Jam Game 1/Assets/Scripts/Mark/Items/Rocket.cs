using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float powerMultiplier;
    private Vector3 rocketPos;
    public GameObject theExplosion;

    public float force;

    private void Start()
    {
        this.Wait(3.0f, () =>
        {
            Destroy(gameObject);
        });
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        GetComponent<CircleCollider2D>().enabled = true;
        transform.GetComponentInChildren<SpriteRenderer>().enabled = false;
        rocketPos = transform.position;
        
        Instantiate(theExplosion, rocketPos, Quaternion.identity);

        this.Wait(0.1f, () =>
        {
            Destroy(gameObject);
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 relPos = collision.transform.position - transform.position;

        if(collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(relPos * force * powerMultiplier, ForceMode2D.Impulse);
        }
    }
}
