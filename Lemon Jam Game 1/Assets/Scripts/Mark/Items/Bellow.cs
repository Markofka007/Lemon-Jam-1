using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bellow : MonoBehaviour
{
    PlayerController p1;

    Arm arm;

    PolygonCollider2D wind;
    
    private bool isActive;

    [SerializeField] private float maxAmmo; //ammo

    private float ammoCount;

    private float powerMultiplier; //power

    public Animator myAnimator;

    void Start()
    {
        p1 = transform.parent.parent.parent.GetComponent<PlayerController>();

        arm = transform.parent.parent.GetComponent<Arm>();

        wind = GetComponent<PolygonCollider2D>();

        ammoCount = maxAmmo;

        powerMultiplier = 1.0f;

        myAnimator.GetComponent<Animator>();
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

        //maybe instantiate a cloud here and it rides the wind and waits and destroys??
    }

    public void StopWind()
    {
        isActive = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (isActive && !collision.CompareTag("Player1"))
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
