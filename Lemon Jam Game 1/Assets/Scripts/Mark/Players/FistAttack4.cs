using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistAttack4 : MonoBehaviour
{
    Arm4 arm;

    public LayerMask canPunch;

    public float punchDistance;
    public float punchPower;

    void Start()
    {
        arm = GetComponent<Arm4>();
    }

    public void Punch()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, new Vector3(Mathf.Cos(arm.angleCorrected * Mathf.Deg2Rad), Mathf.Sin(arm.angleCorrected * Mathf.Deg2Rad)), punchDistance, canPunch);

        if (ray)
        {
            ray.collider.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * arm.angleCorrected), Mathf.Sin(Mathf.Deg2Rad * arm.angleCorrected)) * punchPower, ForceMode2D.Impulse);
        }
    }
}
