using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] creditsSequence;

    void Start()
    {
        CreditLogo();
    }

    private void CreditLogo()
    {
        creditsSequence[0].SetActive(true);
        this.Wait(9f, () =>
        {
            creditsSequence[0].SetActive(false);
            Credit1();
        });
    }

    private void Credit1()
    {
        creditsSequence[1].SetActive(true);
        this.Wait(9f, () =>
        {
            creditsSequence[1].SetActive(false);
            Credit2();
        });
    }

    private void Credit2()
    {
        creditsSequence[2].SetActive(true);
        this.Wait(9f, () =>
        {
            creditsSequence[2].SetActive(false);
            Credit3();
        });
    }

    private void Credit3()
    {
        creditsSequence[3].SetActive(true);
        this.Wait(9f, () =>
        {
            creditsSequence[3].SetActive(false);
            Credit4();
        });
    }

    private void Credit4()
    {
        creditsSequence[4].SetActive(true);
        this.Wait(9f, () =>
        {
            creditsSequence[4].SetActive(false);
            Credit5();
        });
    }

    private void Credit5()
    {
        creditsSequence[5].SetActive(true);
        this.Wait(9f, () =>
        {
            creditsSequence[5].SetActive(false);
            GoToMainMenu();
        });
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
