using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat3 : MonoBehaviour
{
    PlayerController3 p3;

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
        p3 = transform.parent.parent.GetComponent<PlayerController3>();

        angleCorrected = -p3.controllerAngle + 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angleCorrected);
        transform.localScale = new Vector3(1, Mathf.Abs(p3.controllerAngle) / p3.controllerAngle, 1);
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
        if (isActive && !collision.gameObject.CompareTag("Player3"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * angleCorrected), Mathf.Sin(Mathf.Deg2Rad * angleCorrected)) * 20f, ForceMode2D.Impulse);
        }
    }
}
