using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LC4 : MonoBehaviour
{
    PlayerController4 p4;

    Arm4 arm;

    private Transform gunTip;

    private LineRenderer lr;

    [SerializeField] private LayerMask rayignore;

    [SerializeField] private int maxAmmo; //ammo

    private int ammoCount;

    private float powerMultiplier; //power

    void Start()
    {
        p4 = transform.parent.parent.parent.GetComponent<PlayerController4>();

        arm = transform.parent.parent.GetComponent<Arm4>();

        lr = GetComponent<LineRenderer>();

        ammoCount = maxAmmo; //ammo

        gunTip = transform.GetChild(1).gameObject.transform;

        powerMultiplier = 1.0f;
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
        if (this.enabled)
        {
            RaycastHit2D ray = Physics2D.Raycast(gunTip.position, new Vector3(Mathf.Cos(arm.angleCorrected * Mathf.Deg2Rad), Mathf.Sin(arm.angleCorrected * Mathf.Deg2Rad)), 100, rayignore);

            ammoCount--;

            lr.positionCount = 2;
            lr.SetPosition(0, gunTip.position);

            if (ray)
            {
                lr.SetPosition(1, ray.point);

                ray.collider.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * arm.angleCorrected), Mathf.Sin(Mathf.Deg2Rad * arm.angleCorrected)) * 25f * powerMultiplier, ForceMode2D.Impulse);
            }
            else
            {
                lr.SetPosition(1, transform.position + new Vector3(Mathf.Cos(arm.angleCorrected * Mathf.Deg2Rad) * 100, Mathf.Sin(arm.angleCorrected * Mathf.Deg2Rad) * 100, 0));
            }


            this.Wait(0.1f, () =>
            {
                lr.positionCount = 0;
            });
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
