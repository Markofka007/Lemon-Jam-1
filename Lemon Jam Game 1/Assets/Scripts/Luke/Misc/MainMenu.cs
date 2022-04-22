using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    private int menuSelection;
    private int maxMenuSelection;

    void Start()
    {
        menuSelection = 1;
        maxMenuSelection = 2;
    }
    
    void Update()
    {
        
    }

    public void ScrollUp(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && menuSelection > 1)
        {
            menuSelection--;
        }

        Debug.Log("Scrolled Up" + menuSelection);
    }

    public void ScrollDown(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && menuSelection < maxMenuSelection)
        {
            menuSelection++;
        }

        Debug.Log("Scrolled Down" + menuSelection);
    }

    public void LoadScene(int sceneDex)
    {
        SceneManager.LoadScene(sceneDex);
    }
}
