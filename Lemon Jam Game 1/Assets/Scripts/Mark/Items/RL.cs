using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL : MonoBehaviour
{
    PlayerController p1;

    private Transform gunTip;

    float angleCorrected;
    
    private Rigidbody2D rb;

    [SerializeField] private GameObject rocketPrefab;

    //private bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        p1 = transform.parent.parent.GetComponent<PlayerController>();

        angleCorrected = -p1.controllerAngle + 90f;

        gunTip = transform.GetChild(1).gameObject.transform;

        //myRB.rotation = -p1.controllerAngle + 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angleCorrected);
        transform.localScale = new Vector3(1, Mathf.Abs(p1.controllerAngle) / p1.controllerAngle, 1);
    }

    public void Fire()
    {
        if (this.enabled)
        {
            GameObject rocket = Instantiate(rocketPrefab, gunTip.position, Quaternion.Euler(0, 0, angleCorrected));
            rocket.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angleCorrected), Mathf.Sin(Mathf.Deg2Rad * angleCorrected)) * 20f;
        }
    }
}