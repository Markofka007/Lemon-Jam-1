using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerItemHandler : MonoBehaviour
{
    private Transform container;
    private bool containerFull;

    private GameObject item;

    [SerializeField] private int playerID;
    
    private AutoGun autoGunScript; //Will need to get and set item's equiped bool state, rb, and collider.

    void Start()
    {
        container = transform.GetChild(0).GetChild(0);
        containerFull = false;
    }

    private void LateUpdate()
    {
        if (containerFull)
        {
            item.transform.localPosition = Vector3.back;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Equipable") && !containerFull)
        {
            item = collision.gameObject;
            EquipItem();
        }
    }

    public void EquipItem()
    {
        containerFull = true;

        item.transform.SetParent(container);
        item.transform.localPosition = Vector3.back;
        item.transform.localRotation = Quaternion.Euler(Vector3.zero);

        item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        item.GetComponent<Rigidbody2D>().freezeRotation = true;

        GetComponent<FistAttack>().enabled = false;

        item.GetComponent<Rigidbody2D>().isKinematic = true;
        item.GetComponent<BoxCollider2D>().isTrigger = true;

        if (item.name.Contains("Auto Gun"))
        {
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

                case 4:
                    item.GetComponent<AutoGun4>().enabled = true;
                    break;
            }
        }
        else if (item.name.Contains("Bellow"))
        {
            switch (playerID)
            {
                case 1:
                    item.GetComponent<Bellow>().enabled = true;
                    break;

                case 2:
                    item.GetComponent<Bellow2>().enabled = true;
                    break;

                case 3:
                    item.GetComponent<Bellow3>().enabled = true;
                    break;

                case 4:
                    item.GetComponent<Bellow4>().enabled = true;
                    break;
            }
        }
        else if (item.name.Contains("LaserCannon"))
        {
            switch (playerID)
            {
                case 1:
                    item.GetComponent<LC>().enabled = true;
                    break;

                case 2:
                    item.GetComponent<LC2>().enabled = true;
                    break;

                case 3:
                    item.GetComponent<LC3>().enabled = true;
                    break;

                case 4:
                    item.GetComponent<LC4>().enabled = true;
                    break;
            }
        }
        else if (item.name.Contains("RocketLauncher"))
        {
            switch (playerID)
            {
                case 1:
                    item.GetComponent<RL>().enabled = true;
                    break;

                case 2:
                    item.GetComponent<RL2>().enabled = true;
                    break;

                case 3:
                    item.GetComponent<RL3>().enabled = true;
                    break;

                case 4:
                    item.GetComponent<RL4>().enabled = true;
                    break;
            }
        }
        else if (item.name.Contains("Bat"))
        {
            switch (playerID)
            {
                case 1:
                    item.GetComponent<Bat>().enabled = true;
                    break;

                case 2:
                    item.GetComponent<Bat2>().enabled = true;
                    break;

                case 3:
                    item.GetComponent<Bat3>().enabled = true;
                    break;

                case 4:
                    item.GetComponent<Bat4>().enabled = true;
                    break;
            }
        }
    }

    public void Dropitem(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

            containerFull = false;

            if (item.name.Contains("Auto Gun"))
            {
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

                    case 4:
                        item.GetComponent<AutoGun4>().enabled = false;
                        break;
                }
            }
            else if (item.name.Contains("Bellow"))
            {
                switch (playerID)
                {
                    case 1:
                        item.GetComponent<Bellow>().enabled = false;
                        break;

                    case 2:
                        item.GetComponent<Bellow2>().enabled = false;
                        break;

                    case 3:
                        item.GetComponent<Bellow3>().enabled = false;
                        break;

                    case 4:
                        item.GetComponent<Bellow4>().enabled = false;
                        break;
                }
            }
            else if (item.name.Contains("LaserCannon"))
            {
                switch (playerID)
                {
                    case 1:
                        item.GetComponent<LC>().enabled = false;
                        break;

                    case 2:
                        item.GetComponent<LC2>().enabled = false;
                        break;

                    case 3:
                        item.GetComponent<LC3>().enabled = false;
                        break;

                    case 4:
                        item.GetComponent<LC4>().enabled = false;
                        break;
                }
            }
            else if (item.name.Contains("RocketLauncher"))
            {
                switch (playerID)
                {
                    case 1:
                        item.GetComponent<RL>().enabled = false;
                        break;

                    case 2:
                        item.GetComponent<RL2>().enabled = false;
                        break;

                    case 3:
                        item.GetComponent<RL3>().enabled = false;
                        break;

                    case 4:
                        item.GetComponent<RL4>().enabled = false;
                        break;
                }
            }
            else if (item.name.Contains("Bat"))
            {
                switch (playerID)
                {
                    case 1:
                        item.GetComponent<Bat>().enabled = false;
                        break;

                    case 2:
                        item.GetComponent<Bat2>().enabled = false;
                        break;

                    case 3:
                        item.GetComponent<Bat3>().enabled = false;
                        break;

                    case 4:
                        item.GetComponent<Bat4>().enabled = false;
                        break;
                }
            }

            item.transform.SetParent(null);

            item.GetComponent<Rigidbody2D>().isKinematic = false;
            item.GetComponent<BoxCollider2D>().isTrigger = false;

            GetComponent<FistAttack>().enabled = true;

            item.GetComponent<Rigidbody2D>().freezeRotation = false;
            item.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity * 2;
        }
    }

    public void DestroyItem()
    {
        if (item.name.Contains("Auto Gun"))
        {
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

                case 4:
                    item.GetComponent<AutoGun4>().enabled = false;
                    break;
            }
        }
        else if (item.name.Contains("Bellow"))
        {
            switch (playerID)
            {
                case 1:
                    item.GetComponent<Bellow>().enabled = false;
                    break;

                case 2:
                    item.GetComponent<Bellow2>().enabled = false;
                    break;

                case 3:
                    item.GetComponent<Bellow3>().enabled = false;
                    break;

                case 4:
                    item.GetComponent<Bellow4>().enabled = false;
                    break;
            }
        }
        else if (item.name.Contains("LaserCannon"))
        {
            switch (playerID)
            {
                case 1:
                    item.GetComponent<LC>().enabled = false;
                    break;

                case 2:
                    item.GetComponent<LC2>().enabled = false;
                    break;

                case 3:
                    item.GetComponent<LC3>().enabled = false;
                    break;

                case 4:
                    item.GetComponent<LC4>().enabled = false;
                    break;
            }
        }
        else if (item.name.Contains("RocketLauncher"))
        {
            switch (playerID)
            {
                case 1:
                    item.GetComponent<RL>().enabled = false;
                    break;

                case 2:
                    item.GetComponent<RL2>().enabled = false;
                    break;

                case 3:
                    item.GetComponent<RL3>().enabled = false;
                    break;

                case 4:
                    item.GetComponent<RL4>().enabled = false;
                    break;
            }
        }
        else if (item.name.Contains("Bat"))
        {
            switch (playerID)
            {
                case 1:
                    item.GetComponent<Bat>().enabled = false;
                    break;

                case 2:
                    item.GetComponent<Bat2>().enabled = false;
                    break;

                case 3:
                    item.GetComponent<Bat3>().enabled = false;
                    break;

                case 4:
                    item.GetComponent<Bat4>().enabled = false;
                    break;
            }
        }

        containerFull = false;

        item.transform.SetParent(null);

        item.GetComponent<ItemRespawn>().enabled = false;

        item.GetComponent<Rigidbody2D>().isKinematic = false;
        item.GetComponent<BoxCollider2D>().isTrigger = true;

        GetComponent<FistAttack>().enabled = true;

        item.GetComponent<Rigidbody2D>().freezeRotation = false;
        item.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-4f, 4f), 15f);
        item.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-25, 25), ForceMode2D.Impulse);
    }
}