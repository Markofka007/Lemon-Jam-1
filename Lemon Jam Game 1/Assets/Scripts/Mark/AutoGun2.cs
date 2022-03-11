using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGun2 : MonoBehaviour
{
    private Transform gunTip;

    private LineRenderer lr;

    private bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();

        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        gunTip = transform.GetChild(4).gameObject.transform;
    }

    public void Fire(float angle)
    {
        if (this.enabled)
        {
            lr.positionCount = 2;
            lr.SetPosition(0, gunTip.position);
            lr.SetPosition(1, transform.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * 10, Mathf.Sin(angle * Mathf.Deg2Rad) * 10, 0));

            canShoot = false;

            transform.parent.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * (-angle + 90f)) * -2f, Mathf.Sin(Mathf.Deg2Rad * (-angle + 90f)) * -2f), ForceMode2D.Impulse);

            this.Wait(0.1f, () =>
            {
                lr.positionCount = 0;
                canShoot = true;
            });
        }
    }
}
