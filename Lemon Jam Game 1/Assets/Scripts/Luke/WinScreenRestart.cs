using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenRestart : MonoBehaviour
{
    public GameObject text;
    
    // Start is called before the first frame update
    void Start()
    {
        this.Wait(5f, () =>
        {
            text.SetActive(true);

            this.Wait(25f, () =>
            {
                SceneManager.LoadScene("MainMenu");
            });
        });
    }
}
