using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hauptmenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject steuerung;
    [SerializeField] private GameObject einstellungen;

    [SerializeField] private Slider slider;

    public void OnSliderValueChanged()
    {
        float roundedValue = Mathf.Round(slider.value * 100f) / 100f;
        Debug.Log("Aktueller Slider-Wert: " + roundedValue);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (steuerung.activeSelf)
            {
                steuerung.SetActive(false);
                menu.SetActive(true);
            }
            else if (einstellungen.activeSelf)
            {
                einstellungen.SetActive(false);
                menu.SetActive(true);
            }
        }
    }

    public void SteuerungPanel()
    {
        steuerung.SetActive(true);
        menu.SetActive(false);
    }

    public void EinstellungenPanel()
    {
        einstellungen.SetActive(true);
        menu.SetActive(false);
    }

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
