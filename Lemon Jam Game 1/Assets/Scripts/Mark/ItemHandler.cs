using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemHandler : MonoBehaviour
{
    private AutoGun autoGunScript;
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    private Transform player1, gunContainer1;
    private Transform player2, gunContainer2;
    //private Transform player3, gunContainer3;
    //private Transform player4, gunContainer4;

    public bool equiped;

    public static bool P1_slotFull;
    public static bool P2_slotFull;
    //public static bool P3_slotFull;
    //public static bool P4_slotFull;

    private void Start()
    {
        autoGunScript = GetComponent<AutoGun>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

        player1 = GameObject.FindGameObjectWithTag("Player1").transform;
        Debug.Log(player1.name);
        player2 = GameObject.FindGameObjectWithTag("Player2").transform;
        Debug.Log(player2.name);
        //player3 = GameObject.FindGameObjectWithTag("Player3").transform;
        //player4 = GameObject.FindGameObjectWithTag("Player4").transform;

        gunContainer1 = GameObject.FindGameObjectWithTag("P1Container").transform;
        Debug.Log(gunContainer1.name);
        gunContainer2 = GameObject.FindGameObjectWithTag("P2Container").transform;
        Debug.Log(gunContainer2.name);
        //gunContainer3 = GameObject.FindGameObjectWithTag("P3Container").transform;
        //gunContainer4 = GameObject.FindGameObjectWithTag("P4Container").transform;

        P1_slotFull = false;
        P2_slotFull = false;
        //P3_slotFull = false;
        //P4_slotFull = false;

        autoGunScript.enabled = false;
        rb.isKinematic = false;
        coll.isTrigger = false;
    }

    private void Update()
    {

    }

    public void P1_PickUpItem(InputAction.CallbackContext context)
    {
        Debug.Log(context);

        if (context.performed && (player1.position - transform.position).magnitude <= 5f && !equiped && !P1_slotFull)
        {
            equiped = true;
            P1_slotFull = true;

            transform.SetParent(gunContainer1);
            transform.localPosition = Vector3.forward * -1;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localScale = Vector3.one;

            //transform.parent.parent.GetComponent<FistAttack>().enabled = false;

            rb.isKinematic = true;
            coll.isTrigger = true;

            autoGunScript.enabled = true;
        }
    }

    public void P1_DropItem(InputAction.CallbackContext context)
    {
        Debug.Log(context);

        if (context.performed && equiped)
        {
            equiped = false;
            P1_slotFull = false;

            //transform.parent.parent.GetComponent<FistAttack>().enabled = true;

            transform.SetParent(null);

            rb.isKinematic = false;
            coll.isTrigger = false;

            rb.velocity = player1.GetComponent<Rigidbody2D>().velocity;
            rb.AddForce(Vector2.up * 2f, ForceMode2D.Impulse);
            float random = Random.Range(-1f, 1f);
            rb.AddTorque(random * 5f);

            autoGunScript.enabled = false;
        }
    }

    public void P2_PickUpItem(InputAction.CallbackContext context)
    {
        Debug.Log(context);

        if (context.performed && (player2.position - transform.position).magnitude <= 5f && !equiped && !P2_slotFull)
        {
            equiped = true;
            P2_slotFull = true;

            transform.SetParent(gunContainer2);
            transform.localPosition = Vector3.forward * -1;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localScale = Vector3.one;

            //transform.parent.parent.GetComponent<FistAttack>().enabled = false;

            rb.isKinematic = true;
            coll.isTrigger = true;

            autoGunScript.enabled = true;
        }
    }

    public void P2_DropItem(InputAction.CallbackContext context)
    {
        Debug.Log(context);

        if (context.performed && equiped)
        {
            equiped = false;
            P2_slotFull = false;

            //transform.parent.parent.GetComponent<FistAttack>().enabled = true;

            transform.SetParent(null);

            rb.isKinematic = false;
            coll.isTrigger = false;

            rb.velocity = player2.GetComponent<Rigidbody2D>().velocity;
            rb.AddForce(Vector2.up * 2f, ForceMode2D.Impulse);
            float random = Random.Range(-1f, 1f);
            rb.AddTorque(random * 5f);

            autoGunScript.enabled = false;
        }
    }
}
