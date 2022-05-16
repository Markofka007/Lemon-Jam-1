using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LC2 : MonoBehaviour
{
    PlayerController2 p2;

    Arm2 arm;

    private Transform gunTip;
    
    private LineRenderer lr;
    
    [SerializeField] private LayerMask rayignore;

    [SerializeField] private int maxAmmo; //ammo

    private int ammoCount;

    public float power;

    private float powerMultiplier; //power

    public Animator myAnimator;

    private AudioSource fireSound;

    void Start()
    {
        p2 = transform.parent.parent.parent.GetComponent<PlayerController2>();

        arm = transform.parent.parent.GetComponent<Arm2>();

        lr = GetComponent<LineRenderer>();

        ammoCount = maxAmmo; //ammo

        gunTip = transform.GetChild(1).gameObject.transform;

        powerMultiplier = 1.0f; //power

        myAnimator.GetComponent<Animator>();

        fireSound = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (p2.controllerAngle < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            myAnimator.SetBool("sodaShake", true);
            //transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;  //this had issues, leaving this in just in case...
        }
        else
        {
            transform.localScale = Vector3.one;
            myAnimator.SetBool("sodaShake", false);
            //transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
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

            myAnimator.Play("Soda Blast", -1, 0f);

            fireSound.Play();

            if (ray)
            {
                lr.SetPosition(1, ray.point);

                ray.collider.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * arm.angleCorrected), Mathf.Sin(Mathf.Deg2Rad * arm.angleCorrected)) * power * powerMultiplier, ForceMode2D.Impulse);
            }
            else
            {
                lr.SetPosition(1, transform.position + new Vector3(Mathf.Cos(arm.angleCorrected * Mathf.Deg2Rad) * 100, Mathf.Sin(arm.angleCorrected * Mathf.Deg2Rad) * 100, 0));
            }


            this.Wait(0.1f, () =>
            {
                lr.positionCount = 0;
                fireSound.Stop();
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
