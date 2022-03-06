using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Vector3 distanceToPlayer = player.position - transform.position;

        if (Input.GetKeyDown(KeyCode.E) && distanceToPlayer.magnitude <= 5f && !equiped && !P1_slotFull)
        {
            PickUpItem();
        }

        if (Input.GetKeyDown(KeyCode.Q) && equiped)
        {
            DropItem();
        }
    }

    public void PickUpItem()
    {
        equiped = true;
        P1_slotFull = true;

        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.forward * -1;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        rb.isKinematic = true;
        coll.isTrigger = true;

        autoGunScript.enabled = true;
    }

    private void DropItem()
    {
        equiped = false;
        P1_slotFull = false;

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
