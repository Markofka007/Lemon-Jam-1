using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm4 : MonoBehaviour
{
    PlayerController4 p4;

    public float angleCorrected;

    void Start()
    {
        p4 = transform.parent.GetComponent<PlayerController4>();
    }

    void Update()
    {
        angleCorrected = -p4.controllerAngle + 90f;

        //Debug.Log(angleCorrected);

        transform.localRotation = Quaternion.Euler(0, 0, angleCorrected);
    }
}
