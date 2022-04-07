using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popcorn : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(GetComponent<Rigidbody2D>().rotation * Mathf.Deg2Rad) * Mathf.Rad2Deg, Mathf.Sin(GetComponent<Rigidbody2D>().rotation * Mathf.Deg2Rad) * Mathf.Rad2Deg) * 0.10f, ForceMode2D.Impulse);

        Destroy(gameObject);
    }
}
