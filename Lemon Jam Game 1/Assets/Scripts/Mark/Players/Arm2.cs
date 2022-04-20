using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm2 : MonoBehaviour
{
    PlayerController2 p2;

    public float angleCorrected;

    void Start()
    {
        p2 = transform.parent.GetComponent<PlayerController2>();
    }

    void Update()
    {
        angleCorrected = -p2.controllerAngle + 90f;

        //Debug.Log(angleCorrected);

        transform.localRotation = Quaternion.Euler(0, 0, angleCorrected);
    }
}
