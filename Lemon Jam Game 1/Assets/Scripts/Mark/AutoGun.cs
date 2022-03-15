using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGun : MonoBehaviour
{
    private Camera mainCam;

    private Vector3 mousePos;
    private Vector3 localMousePos;
    private float angleToMouse;

    private Transform gunTip;
    private Vector3 gunToMouse;

    private LineRenderer lr;

    private bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;

        lr = GetComponent<LineRenderer>();

        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        localMousePos = mousePos - transform.position;
        angleToMouse = Mathf.Rad2Deg * Mathf.Atan2(localMousePos.x, localMousePos.y);

        gunTip = transform.GetChild(4).gameObject.transform;
        gunToMouse = mousePos - gunTip.position;

        transform.localRotation = Quaternion.Euler(0, 0, -angleToMouse + 90f);
        transform.localScale = new Vector3(1, Mathf.Abs(angleToMouse) / angleToMouse , 1);
    }

    public void Fire()
    {
        if (this.enabled)
        {
            RaycastHit2D ray = Physics2D.Raycast(gunTip.position, mousePos, 100);

            lr.positionCount = 2;
            lr.SetPosition(0, gunTip.position);

            if (ray)
            {
                lr.SetPosition(1, ray.point);
            }
            else
            {
                lr.SetPosition(1, transform.position + (mousePos * 100));
            }

            canShoot = false;

            transform.parent.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * (-angleToMouse + 90f)) * -2f, Mathf.Sin(Mathf.Deg2Rad * (-angleToMouse + 90f)) * -2f), ForceMode2D.Impulse);

            this.Wait(0.1f, () =>
            {
                lr.positionCount = 0;
                canShoot = true;
            });
        }
    }
}
