using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat4 : MonoBehaviour
{
    PlayerController4 p4;

    Arm4 arm;

    private bool isActive = false;

    [SerializeField] private int maxAmmo; //ammo

    private int ammoCount;

    void Start()
    {
        p4 = transform.parent.parent.parent.GetComponent<PlayerController4>();

        arm = transform.parent.parent.GetComponent<Arm4>();

        ammoCount = maxAmmo;
    }

    void Update()
    {
        if (p4.controllerAngle < 0)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
        }

        if (ammoCount <= 0)
        {
            transform.parent.parent.parent.GetComponent<PlayerItemHandler>().DestroyItem(); //ammo
        }
    }

    public void Fire()
    {
        isActive = true;

        ammoCount--;

        this.Wait(0.1f, () =>
        {
            isActive = false;
        });
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isActive && !collision.gameObject.CompareTag("Player4") && !collision.gameObject.CompareTag("Platform"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * arm.angleCorrected), Mathf.Sin(Mathf.Deg2Rad * arm.angleCorrected)) * 20f, ForceMode2D.Impulse);
        }
    }
}
