using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bellow4 : MonoBehaviour
{
    PlayerController4 p4;

    Arm4 arm;

    PolygonCollider2D wind;

    private bool isActive;

    [SerializeField] private float maxAmmo; //ammo

    private float ammoCount;

    void Start()
    {
        p4 = transform.parent.parent.parent.GetComponent<PlayerController4>();

        arm = transform.parent.parent.GetComponent<Arm4>();

        wind = GetComponent<PolygonCollider2D>();

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
        if (isActive && !collision.CompareTag("Player4"))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * arm.angleCorrected), Mathf.Sin(Mathf.Deg2Rad * arm.angleCorrected)) * 1.5f, ForceMode2D.Impulse);
        }
    }
}
