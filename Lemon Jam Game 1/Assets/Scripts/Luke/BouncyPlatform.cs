using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    public float bounceForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "Player1") || (collision.gameObject.tag == "Player2") || (collision.gameObject.tag == "Player3") || (collision.gameObject.tag == "Player4"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse); 
        }
    }
}
