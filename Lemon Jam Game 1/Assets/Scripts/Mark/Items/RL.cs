using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL : MonoBehaviour
{
    PlayerController p1;

    Arm arm;

    private Transform gunTip;
    
    [SerializeField] private GameObject rocketPrefab;

    [SerializeField] private int maxAmmo; //ammo

    private int ammoCount;

    private float powerMultiplier; //power

    void Start()
    {
        p1 = transform.parent.parent.parent.GetComponent<PlayerController>();

        arm = transform.parent.parent.GetComponent<Arm>();

        gunTip = transform.GetChild(1).gameObject.transform;

        ammoCount = maxAmmo; //ammo

        powerMultiplier = 1.0f; //power
    }
    
    void Update()
    {
        if (p1.controllerAngle < 0)
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
            rocket.GetComponent<Rocket>().powerMultiplier = powerMultiplier;
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
