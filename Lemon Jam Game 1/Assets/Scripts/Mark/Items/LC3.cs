using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LC3 : MonoBehaviour
{
    PlayerController3 p3;

    private Transform gunTip;

    float angleCorrected;

    private LineRenderer lr;

    private Rigidbody2D rb;

    [SerializeField] private LayerMask rayignore;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        p3 = transform.parent.parent.GetComponent<PlayerController3>();

        angleCorrected = -p3.controllerAngle + 90f;

        gunTip = transform.GetChild(3).gameObject.transform;

        transform.localRotation = Quaternion.Euler(0, 0, angleCorrected);
        transform.localScale = new Vector3(1, Mathf.Abs(p3.controllerAngle) / p3.controllerAngle, 1);
    }

    public void Fire()
    {
        if (this.enabled)
        {
            RaycastHit2D ray = Physics2D.Raycast(gunTip.position, new Vector3(Mathf.Cos(angleCorrected * Mathf.Deg2Rad), Mathf.Sin(angleCorrected * Mathf.Deg2Rad)), 100, rayignore);

            lr.positionCount = 2;
            lr.SetPosition(0, gunTip.position);

            if (ray)
            {
                lr.SetPosition(1, ray.point);

                ray.collider.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * angleCorrected), Mathf.Sin(Mathf.Deg2Rad * angleCorrected)) * 25f, ForceMode2D.Impulse);
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