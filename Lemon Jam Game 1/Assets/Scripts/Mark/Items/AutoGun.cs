using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGun : MonoBehaviour
{
    PlayerController p1;

    Arm arm;

    private Transform gunTip;
    
    private bool canShoot;

    private bool activated;

    [SerializeField] private GameObject popcornPrefab;

    [SerializeField] private int maxAmmo; //ammo

    private int ammoCount;

    private float powerMultiplier; //power

    private AudioSource pop;
    
    void Start()
    {
        p1 = transform.parent.parent.parent.GetComponent<PlayerController>();

        arm = transform.parent.parent.GetComponent<Arm>();

        gunTip = transform.GetChild(1).gameObject.transform;
        
        canShoot = true;

        activated = false;

        ammoCount = maxAmmo; //ammo

        powerMultiplier = 1.0f; //power

        pop = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (p1.controllerAngle < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            //transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;  //this had issues, leaving this in just in case...
        }
        else
        {
            transform.localScale = Vector3.one;
            //transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
        }

        if (canShoot && activated)
        {
            if (this.enabled)
            {
                canShoot = false;

                ammoCount--; //ammo

                GameObject popcorn = Instantiate(popcornPrefab, gunTip.position, Quaternion.Euler(0, 0, arm.angleCorrected));
                popcorn.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * arm.angleCorrected), Mathf.Sin(Mathf.Deg2Rad * arm.angleCorrected)) * 25f;
                popcorn.GetComponent<Popcorn>().powerMulitplier = powerMultiplier;

                pop.Play();

                this.Wait(0.2f, () =>
                {
                    canShoot = true;
                });
            }
        }

        if (ammoCount <= 0)
        {
            transform.parent.parent.parent.GetComponent<PlayerItemHandler>().DestroyItem(); //ammo
        }
    }

    public void StartFire()
    {
        activated = true;
    }

    public void StopFire()
    {
        activated = false;
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
