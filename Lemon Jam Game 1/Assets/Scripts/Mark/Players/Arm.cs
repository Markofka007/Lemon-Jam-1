using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    PlayerController p1;

    public float angleCorrected;

    void Start()
    {
        p1 = transform.parent.GetComponent<PlayerController>();
    }
    
    void Update()
    {
        angleCorrected = -p1.controllerAngle + 90f;

        //Debug.Log(angleCorrected);

        transform.localRotation = Quaternion.Euler(0, 0, angleCorrected);
    }
}
