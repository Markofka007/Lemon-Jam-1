using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat3 : MonoBehaviour
{
    PlayerController3 p3;

    Arm3 arm;

    private bool isActive = false;

    [SerializeField] private int maxAmmo; //ammo

    private int ammoCount;

    private float powerMultiplier; //power

    void Start()
    {
        p3 = transform.parent.parent.parent.GetComponent<PlayerController3>();

        arm = transform.parent.parent.GetComponent<Arm3>();

        ammoCount = maxAmmo;

        powerMultiplier = 1.0f; //power
    }

    void Update()
    {
        if (p3.controllerAngle < 0)
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
        if (isActive && !collision.gameObject.CompareTag("Player3") && !collision.gameObject.CompareTag("Platform"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * arm.angleCorrected), Mathf.Sin(Mathf.Deg2Rad * arm.angleCorrected)) * 20f * powerMultiplier, ForceMode2D.Impulse);
        }
    }

    public void MultiplyPower(float PowerM_Delta)
    {
        powerMultiplier += PowerM_Delta;

        this.Wait(5.0f, () =>
        {
            powerMultiplier -= PowerM_Delta;
        });
    }
}
