using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm3 : MonoBehaviour
{
    PlayerController3 p3;

    public float angleCorrected;

    void Start()
    {
        p3 = transform.parent.GetComponent<PlayerController3>();
    }

    void Update()
    {
        angleCorrected = -p3.controllerAngle + 90f;

        //Debug.Log(angleCorrected);

        transform.localRotation = Quaternion.Euler(0, 0, angleCorrected);
    }
}
