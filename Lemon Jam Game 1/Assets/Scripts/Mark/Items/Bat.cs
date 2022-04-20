using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    PlayerController p1;

    Arm arm;
    
    private bool isActive = false;

    [SerializeField] private int maxAmmo; //ammo

    private int ammoCount;

    void Start()
    {
        p1 = transform.parent.parent.parent.GetComponent<PlayerController>();

        arm = transform.parent.parent.GetComponent<Arm>();

        ammoCount = maxAmmo;
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
        isActive = true;

        ammoCount--;

        this.Wait(0.1f, () =>
        {
            isActive = false;
        });
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isActive && !collision.gameObject.CompareTag("Player1") && !collision.gameObject.CompareTag("Platform"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * arm.angleCorrected), Mathf.Sin(Mathf.Deg2Rad * arm.angleCorrected)) * 20f, ForceMode2D.Impulse);
        }
    }
}
