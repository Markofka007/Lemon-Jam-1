using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerItemHandler : MonoBehaviour
{
    private Transform container;
    private bool containerFull;

    [SerializeField] private int playerID;


    private AutoGun autoGunScript; //Will need to get and set item's equiped bool state, rb, and collider.

    void Start()
    {
        container = transform.GetChild(0);
        containerFull = false;


    }
    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Equipable") && !containerFull)
        {
            EquipItem(collision.gameObject);
        }
    }

    public void EquipItem(GameObject item)
    {
        containerFull = true;

        item.transform.SetParent(container);
        item.transform.localPosition = Vector3.forward * -1;
        item.transform.localRotation = Quaternion.Euler(Vector3.zero);

        GetComponent<FistAttack>().enabled = false;

        item.GetComponent<Rigidbody2D>().isKinematic = true;
        item.GetComponent<BoxCollider2D>().isTrigger = true;

        switch (playerID)
        {
            case 1:
                item.GetComponent<AutoGun>().enabled = true;
                break;

            case 2:
                item.GetComponent<AutoGun2>().enabled = true;
                break;

            case 3:
                item.GetComponent<AutoGun3>().enabled = true;
                break;
        }
    }

    public void Dropitem(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject item = container.GetChild(0).gameObject;

            containerFull = false;

            switch (playerID)
            {
                case 1:
                    item.GetComponent<AutoGun>().enabled = false;
                    break;

                case 2:
                    item.GetComponent<AutoGun2>().enabled = false;
                    break;

                case 3:
                    item.GetComponent<AutoGun3>().enabled = false;
                    break;
            }

            item.transform.SetParent(null);

            item.GetComponent<Rigidbody2D>().isKinematic = false;
            item.GetComponent<BoxCollider2D>().isTrigger = false;
            item.GetComponent<AutoGun>().enabled = false;

            item.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity * 2;
        }
    }
}
