using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hauptmenu : MonoBehaviour
{
    public void NeuesSpiel()
    {
        PlayerPrefs.SetInt("NeuesGame", 1);
        PlayerPrefs.SetInt("GameLaden", 0);
        PlayerPrefs.SetInt("BrowserGame", 0);
        SceneManager.LoadScene(1);
    }

    public void SpielLaden()
    {
        PlayerPrefs.SetInt("NeuesGame", 0);
        PlayerPrefs.SetInt("GameLaden", 1);
        PlayerPrefs.SetInt("BrowserGame", 0);
        SceneManager.LoadScene(1);
    }

    public void BrowserGame()
    {
        PlayerPrefs.SetInt("NeuesGame", 0);
        PlayerPrefs.SetInt("GameLaden", 0);
        PlayerPrefs.SetInt("BrowserGame", 1);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
