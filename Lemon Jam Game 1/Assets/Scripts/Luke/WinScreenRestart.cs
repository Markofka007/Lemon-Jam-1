using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class WinScreenRestart : MonoBehaviour
{
    public GameObject text;
    
    void Start()
    {
        this.Wait(5f, () =>
        {
            text.SetActive(true);

            this.Wait(30f, () =>
            {
                SceneManager.LoadScene("MainMenu");
            });
        });
    }

    public void GoToMainMenu(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
