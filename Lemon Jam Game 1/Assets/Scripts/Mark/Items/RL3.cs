using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL3 : MonoBehaviour
{
    PlayerController3 p3;

    Arm3 arm;

    private Transform gunTip;

    [SerializeField] private GameObject rocketPrefab;

    [SerializeField] private int maxAmmo; //ammo

    private int ammoCount;

    void Start()
    {
        p3 = transform.parent.parent.parent.GetComponent<PlayerController3>();

        arm = transform.parent.parent.GetComponent<Arm3>();

        gunTip = transform.GetChild(1).gameObject.transform;

        ammoCount = maxAmmo; //ammo
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
        if (this.enabled)
        {
            ammoCount--;

            GameObject rocket = Instantiate(rocketPrefab, gunTip.position, Quaternion.Euler(0, 0, arm.angleCorrected));
            rocket.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * arm.angleCorrected), Mathf.Sin(Mathf.Deg2Rad * arm.angleCorrected)) * 20f;
        }
    }
}
