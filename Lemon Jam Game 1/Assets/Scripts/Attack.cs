using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;

    public int equippedWeapon; //0 = fist. 1 = bat. 2 = gun;
    public float punchDistance;
    public LayerMask ignorePlayer;


    // Start is called before the first frame update
    void Start()
    {
        equippedWeapon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            switch(equippedWeapon)
            {
                case 0:
                    
                    break;

                case 1:

                    break;

                case 2:

                    break;
            }
        }
    }

    public void Fire()
    {

    }
}
