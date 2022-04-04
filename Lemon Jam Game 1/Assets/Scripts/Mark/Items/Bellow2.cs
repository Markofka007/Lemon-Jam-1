using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bellow2 : MonoBehaviour
{
    PlayerController2 p2;

    Rigidbody2D rb;

    PolygonCollider2D wind;

    float angleCorrected;

    private bool isActive;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        wind = GetComponent<PolygonCollider2D>();

        wind.enabled = false;
        this.enabled = false;
    }

    void Update()
    {
        p2 = transform.parent.parent.GetComponent<PlayerController2>();

        angleCorrected = -p2.controllerAngle + 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angleCorrected);
        transform.localScale = new Vector3(1, Mathf.Abs(p2.controllerAngle) / p2.controllerAngle, 1);

        if (isActive)
        {
            wind.enabled = true;
        }
        else
        {
            wind.enabled = false;
        }
    }

    public void StartWind()
    {
        isActive = true;
    }

    public void StopWind()
    {
        isActive = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (isActive && !collision.CompareTag("Player2"))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * angleCorrected), Mathf.Sin(Mathf.Deg2Rad * angleCorrected)) * 1f, ForceMode2D.Impulse);
        }
    }
}
