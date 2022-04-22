using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bellow2 : MonoBehaviour
{
    PlayerController2 p2;

    Arm2 arm;

    PolygonCollider2D wind;

    private bool isActive;

    [SerializeField] private float maxAmmo; //ammo

    private float ammoCount;

    private float powerMultiplier; //power

    void Start()
    {
        p2 = transform.parent.parent.parent.GetComponent<PlayerController2>();

        arm = transform.parent.parent.GetComponent<Arm2>();

        wind = GetComponent<PolygonCollider2D>();

        ammoCount = maxAmmo;

        powerMultiplier = 1.0f; //power
    }

    void Update()
    {
        if (p2.controllerAngle < 0)
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

        if (isActive)
        {
            wind.enabled = true;

            ammoCount -= Time.deltaTime;
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
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * arm.angleCorrected), Mathf.Sin(Mathf.Deg2Rad * arm.angleCorrected)) * 1.5f * powerMultiplier, ForceMode2D.Impulse);
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
