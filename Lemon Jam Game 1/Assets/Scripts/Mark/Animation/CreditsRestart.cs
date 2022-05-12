using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CreditsRestart : MonoBehaviour
{
    public void GoToMainMenu(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
