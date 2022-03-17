using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bellow : MonoBehaviour
{
    PlayerController p1;

    Rigidbody2D rb;

    PolygonCollider2D wind;

    float angleCorrected;

    private bool isActive;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        wind = GetComponent<PolygonCollider2D>();
    }
    
    void Update()
    {
        p1 = transform.parent.parent.GetComponent<PlayerController>();

        angleCorrected = -p1.controllerAngle + 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angleCorrected);
        transform.localScale = new Vector3(1, Mathf.Abs(p1.controllerAngle) / p1.controllerAngle, 1);
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
        if (isActive && !collision.CompareTag("Player1"))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * angleCorrected), Mathf.Sin(Mathf.Deg2Rad * angleCorrected)) * 1f, ForceMode2D.Impulse);
        }
    }
}
