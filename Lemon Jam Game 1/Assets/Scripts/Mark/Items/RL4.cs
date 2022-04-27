using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL4 : MonoBehaviour
{
    PlayerController4 p4;

    Arm4 arm;

    private Transform gunTip;

    [SerializeField] private GameObject rocketPrefab;

    [SerializeField] private int maxAmmo; //ammo

    private int ammoCount;

    private float powerMultiplier; //power

    private AudioSource pop;

    void Start()
    {
        p4 = transform.parent.parent.parent.GetComponent<PlayerController4>();

        arm = transform.parent.parent.GetComponent<Arm4>();

        gunTip = transform.GetChild(1).gameObject.transform;

        ammoCount = maxAmmo; //ammo

        powerMultiplier = 1.0f; //power

        pop = GetComponent<AudioSource>();
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
            ammoCount--;

            GameObject rocket = Instantiate(rocketPrefab, gunTip.position, Quaternion.Euler(0, 0, arm.angleCorrected));
            rocket.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * arm.angleCorrected), Mathf.Sin(Mathf.Deg2Rad * arm.angleCorrected)) * 20f;
            rocket.GetComponent<Rocket>().powerMultiplier = powerMultiplier;

            pop.Play();
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
