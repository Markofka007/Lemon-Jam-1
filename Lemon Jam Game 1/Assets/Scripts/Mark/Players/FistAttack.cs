using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistAttack : MonoBehaviour
{
    Arm arm;

    public LayerMask canPunch;

    public float punchDistance;
    public float punchPower;

    private AudioSource hitsound;

    void Start()
    {
        arm = GetComponent<Arm>();

        hitsound = GetComponent<AudioSource>();
    }

    public void Punch()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, new Vector3(Mathf.Cos(arm.angleCorrected * Mathf.Deg2Rad), Mathf.Sin(arm.angleCorrected * Mathf.Deg2Rad)), punchDistance, canPunch);

        if (ray)
        {
            hitsound.Play();

            ray.collider.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * arm.angleCorrected), Mathf.Sin(Mathf.Deg2Rad * arm.angleCorrected)) * punchPower, ForceMode2D.Impulse);
        }
    }
}
