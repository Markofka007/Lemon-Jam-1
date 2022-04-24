using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    private int menuSelection;
    private int maxMenuSelection;

    public GameObject indicator;
    public GameObject[] menuItems;

    void Start()
    {
        menuSelection = 1;
        maxMenuSelection = menuItems.Length;

        UpdateIndicator();
    }
    
    void Update()
    {
        
    }

    public void ScrollUp(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && menuSelection > 1)
        {
            menuSelection--;
            UpdateIndicator();
        }

        
    }

    public void ScrollDown(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && menuSelection < maxMenuSelection)
        {
            menuSelection++;
            UpdateIndicator();
        }

        
    }

    private void UpdateIndicator()
    {
        indicator.transform.position = menuItems[menuSelection - 1].transform.position + Vector3.back;
    }

    public void Select(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            switch (menuSelection)
            {
                case 1:
                    LoadScene(3);
                    break;

                case 2:
                    LoadScene(4);
                    break;
            }
        }
    }

    public void LoadScene(int sceneDex)
    {
        SceneManager.LoadScene(sceneDex);
    }
}
