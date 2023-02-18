using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //reference credits obj
    private GameObject credits;
    private GameObject homePage;

    private void Start()
    {
        credits = GameObject.Find("Credits");
        credits.SetActive(false);

        homePage = GameObject.Find("MenuHomePage");
        homePage.SetActive(true);
    }


    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
        homePage.SetActive(false);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
        homePage.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
