using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat4 : MonoBehaviour
{
    PlayerController4 p4;

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
        p4 = transform.parent.parent.GetComponent<PlayerController4>();

        angleCorrected = -p4.controllerAngle + 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angleCorrected);
        transform.localScale = new Vector3(1, Mathf.Abs(p4.controllerAngle) / p4.controllerAngle, 1);

        Debug.Log(isActive);
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
        if (isActive && !collision.gameObject.CompareTag("Player4"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * angleCorrected), Mathf.Sin(Mathf.Deg2Rad * angleCorrected)) * 20f, ForceMode2D.Impulse);
        }
    }
}
