using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    public float bounceForce;
    private AudioSource boing;

    private void Start()
    {
        boing = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            boing.Play();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }  
    }
}
