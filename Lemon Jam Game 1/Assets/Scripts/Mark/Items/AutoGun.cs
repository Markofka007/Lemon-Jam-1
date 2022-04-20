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
    
    void Start()
    {
        p1 = transform.parent.parent.parent.GetComponent<PlayerController>();

        arm = transform.parent.parent.GetComponent<Arm>();

        gunTip = transform.GetChild(1).gameObject.transform;
        
        canShoot = true;

        activated = false;

        ammoCount = maxAmmo; //ammo
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

        if (canShoot && activated)
        {
            if (this.enabled)
            {
                canShoot = false;

                ammoCount--; //ammo

                GameObject popcorn = Instantiate(popcornPrefab, gunTip.position, Quaternion.Euler(0, 0, arm.angleCorrected));
                popcorn.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * arm.angleCorrected), Mathf.Sin(Mathf.Deg2Rad * arm.angleCorrected)) * 25f;

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
}
