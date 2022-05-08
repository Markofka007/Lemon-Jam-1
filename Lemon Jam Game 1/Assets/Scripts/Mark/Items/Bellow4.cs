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

    private float powerMultiplier; //power

    public Animator myAnimator;

    void Start()
    {
        p4 = transform.parent.parent.parent.GetComponent<PlayerController4>();

        arm = transform.parent.parent.GetComponent<Arm4>();

        wind = GetComponent<PolygonCollider2D>();

        ammoCount = maxAmmo;

        powerMultiplier = 1.0f; //power

        myAnimator.GetComponent<Animator>();
    }

    void Update()
    {
        if (p4.controllerAngle < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            //transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;  //this had issues, leaving this in just in case...
        }
        else
        {
            transform.localScale = Vector3.one;
            //transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
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
        myAnimator.Play("Kettle", -1, 0f);

    }

    public void StopWind()
    {
        isActive = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (isActive && !collision.CompareTag("Player4"))
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
