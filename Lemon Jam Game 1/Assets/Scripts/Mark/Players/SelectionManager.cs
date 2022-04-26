using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionManager : MonoBehaviour
{
    private int playerSelection;
    private int maxPlayerSelection;

    public GameObject indicator;
    public GameObject[] playerOptions;

    public GameObject player1Prefab;

    public Sprite[] playerSprites;

    void Start()
    {
        playerSelection = 1;
        maxPlayerSelection = playerOptions.Length;
    }
    
    void Update()
    {
        
    }
    
    public void MoveSelection(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx);

        if (true)
        {
            Debug.Log(ctx.ReadValue<float>());

            if (ctx.ReadValue<float>() > 0f && playerSelection < maxPlayerSelection)
            {
                playerSelection++;
                UpdateIndicator();
            }
            else if (ctx.ReadValue<float>() < 0f && playerSelection > 1)
            {
                playerSelection--;
                UpdateIndicator();
            }
        }
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
            //GameObject player1 = Instantiate(player1Prefab, Vector3.zero, Quaternion.identity);
            //player1.GetComponent<SpriteRenderer>().sprite = playerSprites[playerSelection - 1];

            //this.enabled = false;
            Destroy(gameObject);
        }
    }
}
