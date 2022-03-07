using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemHandler : MonoBehaviour
{
    private AutoGun autoGunScript;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Transform player, gunContainer;

    public bool equiped;
    public static bool P1_slotFull;

    private void Start()
    {
        autoGunScript = GetComponent<AutoGun>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player1").transform;
        gunContainer = GameObject.FindGameObjectWithTag("P1Container").transform;

        autoGunScript.enabled = false;
        rb.isKinematic = false;
        coll.isTrigger = false;
    }

    private void Update()
    {

    }

    public void PickUpItem(InputAction.CallbackContext context)
    {
        if (context.performed && (player.position - transform.position).magnitude <= 5f && !equiped && !P1_slotFull)
        {
            equiped = true;
            P1_slotFull = true;

            transform.SetParent(gunContainer);
            transform.localPosition = Vector3.forward * -1;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localScale = Vector3.one;

            transform.parent.parent.GetComponent<FistAttack>().enabled = false;

            rb.isKinematic = true;
            coll.isTrigger = true;

            autoGunScript.enabled = true;
        }
    }

    public void DropItem(InputAction.CallbackContext context)
    {
        if (context.performed && equiped)
        {
            equiped = false;
            P1_slotFull = false;

            transform.parent.parent.GetComponent<FistAttack>().enabled = true;

            transform.SetParent(null);

            rb.isKinematic = false;
            coll.isTrigger = false;

            rb.velocity = player.GetComponent<Rigidbody2D>().velocity;
            rb.AddForce(Vector2.up * 2f, ForceMode2D.Impulse);
            float random = Random.Range(-1f, 1f);
            rb.AddTorque(random * 5f);

            autoGunScript.enabled = false;
        }
    }
}
