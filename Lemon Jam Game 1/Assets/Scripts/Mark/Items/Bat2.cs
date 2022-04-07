using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat2 : MonoBehaviour
{
    PlayerController2 p2;

    float angleCorrected;

    private Rigidbody2D rb;

    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        p2 = transform.parent.parent.GetComponent<PlayerController2>();

        angleCorrected = -p2.controllerAngle + 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angleCorrected);
        transform.localScale = new Vector3(1, Mathf.Abs(p2.controllerAngle) / p2.controllerAngle, 1);
    }

    public void Fire()
    {
        isActive = true;

        this.Wait(0.1f, () =>
        {
            isActive = false;
        });
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isActive && !collision.gameObject.CompareTag("Player2"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * angleCorrected), Mathf.Sin(Mathf.Deg2Rad * angleCorrected)) * 20f, ForceMode2D.Impulse);
        }
    }
}
