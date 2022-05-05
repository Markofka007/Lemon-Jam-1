using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FistAttack2 : MonoBehaviour
{
    Arm2 arm;

    public LayerMask canPunch;

    public float punchDistance;
    public float punchPower;

    void Start()
    {
        arm = GetComponent<Arm2>();
    }

    public void Punch(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, new Vector3(Mathf.Cos(arm.angleCorrected * Mathf.Deg2Rad), Mathf.Sin(arm.angleCorrected * Mathf.Deg2Rad)), punchDistance, canPunch);

            if (ray)
            {
                ray.collider.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * arm.angleCorrected), Mathf.Sin(Mathf.Deg2Rad * arm.angleCorrected)) * punchPower, ForceMode2D.Impulse);
            }
        }
    }
}
