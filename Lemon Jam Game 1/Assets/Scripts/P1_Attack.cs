using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_Attack : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    private Vector3 mouseDistance;
    private float angleToMouse;

    public int equippedWeapon; //0 = fist. 1 = AK. 2 = bat. 3 = Laser Rifle.

    public float punchDistance;
    public LayerMask ignorePlayer;


    void Start()
    {
        mainCamera = Camera.main;

        equippedWeapon = 0;
    }

    void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseDistance = mousePos - transform.position;
        angleToMouse = Mathf.Rad2Deg * Mathf.Atan2(mouseDistance.x, mouseDistance.y);
    }

    public void Fire()
    {
        switch (equippedWeapon)
        {
            case 0:

                break;

            case 1:

                break;

            case 2:

                break;

            case 3:

                break;
        }
    }
}
