using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGun : MonoBehaviour
{
    PlayerController p1;

    private Transform gunTip;

    float angleCorrected;

    private LineRenderer lr;

    private Rigidbody2D rb;

    //private bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();

        rb = GetComponent<Rigidbody2D>();

        //canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        p1 = transform.parent.parent.GetComponent<PlayerController>();

        angleCorrected = -p1.controllerAngle + 90f;

        gunTip = transform.GetChild(4).gameObject.transform;

        //myRB.rotation = -p1.controllerAngle + 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angleCorrected);
        transform.localScale = new Vector3(1, Mathf.Abs(p1.controllerAngle) / p1.controllerAngle, 1);
    }

    public void Fire()
    {
        if (this.enabled)
        {
            RaycastHit2D ray = Physics2D.Raycast(gunTip.position, new Vector3(Mathf.Cos(angleCorrected * Mathf.Deg2Rad), Mathf.Sin(angleCorrected * Mathf.Deg2Rad)), 100);

            lr.positionCount = 2;
            lr.SetPosition(0, gunTip.position);

            if (ray)
            {
                lr.SetPosition(1, ray.point);

                ray.collider.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * angleCorrected), Mathf.Sin(Mathf.Deg2Rad * angleCorrected)) * 5f, ForceMode2D.Impulse);
            }
            else
            {
                lr.SetPosition(1, transform.position + new Vector3(Mathf.Cos(angleCorrected * Mathf.Deg2Rad) * 100, Mathf.Sin(angleCorrected * Mathf.Deg2Rad) * 100, 0));
            }
            

            this.Wait(0.1f, () =>
            {
                lr.positionCount = 0;
            });
        }
    }
}
