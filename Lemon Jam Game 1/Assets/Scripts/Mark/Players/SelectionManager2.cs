using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionManager2 : MonoBehaviour
{
    private int playerSelection;
    private int maxPlayerSelection;

    public GameObject indicator;
    public GameObject[] playerOptions;

    public GameObject player2Prefab;

    public Sprite[] playerSprites;

    void Start()
    {
        playerSelection = 1;
        maxPlayerSelection = playerOptions.Length;
    }

    void Update()
    {

    }

    public void GoLeft(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && playerSelection > 1)
        {
            playerSelection--;
            UpdateIndicator();
        }
    }

    public void GoRight(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && playerSelection < maxPlayerSelection)
        {
            playerSelection++;
            UpdateIndicator();
        }
    }

    private void UpdateIndicator()
    {
        indicator.transform.position = playerOptions[playerSelection - 1].transform.position + Vector3.forward;
    }

    public void Select(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //GameObject player2 = Instantiate(player2Prefab, Vector3.zero, Quaternion.identity);
            //player2.GetComponent<SpriteRenderer>().sprite = playerSprites[playerSelection - 1];

            //this.enabled = false;
            Destroy(gameObject);
        }
    }
}
