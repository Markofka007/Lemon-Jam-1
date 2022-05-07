using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popcorn : MonoBehaviour
{
    public float powerMulitplier;

    public SpriteRenderer Kernel;
    public Sprite PoppedKernel;

    private void Start()
    {
        Kernel.GetComponent<SpriteRenderer>();

        this.Wait(0.5f, () =>
        {
            Kernel.sprite = PoppedKernel;
        });

        this.Wait(3.0f, () =>
        {
            Destroy(gameObject);
        });
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(GetComponent<Rigidbody2D>().rotation * Mathf.Deg2Rad) * Mathf.Rad2Deg, Mathf.Sin(GetComponent<Rigidbody2D>().rotation * Mathf.Deg2Rad) * Mathf.Rad2Deg) * 0.08f * powerMulitplier, ForceMode2D.Impulse);

        Destroy(gameObject);
    }
}
