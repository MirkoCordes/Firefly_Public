using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScipt : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject SettingsUI;
    public GameObject ShopUI;
    public GameObject MenuCaracter;

    public GameObject HighscoreButton;
    public GameObject FireflyTitle;



    public AudioSource startAudio;

    void Start()
    {
        Time.timeScale = 1;
        HighscoreButton.SetActive(false);
        FireflyTitle.SetActive(true);
        /*
#if UNITY_EDITOR
        HighscoreButton.SetActive(false);
        FireflyTitle.SetActive(true);
#elif UNITY_ANDROID
        HighscoreButton.SetActive(true);
        FireflyTitle.SetActive(false);
#elif UNITY_IOS
        HighscoreButton.SetActive(true);
        FireflyTitle.SetActive(false);
#else
        HighscoreButton.SetActive(false);
        FireflyTitle.SetActive(true);
#endif
*/
    }

    public void LoadGame()
    {
        startAudio.Play();
        LevelLoader levelLoader = LevelLoader.FindObjectOfType<LevelLoader>();
        levelLoader.LoadNextLevel(1);
    }

    public void StartMultiplayer()
    {
        startAudio.Play();
        LevelLoader levelLoader = LevelLoader.FindObjectOfType<LevelLoader>();
        levelLoader.LoadNextLevel(2);
    }

    public void LoadSettings()
    {
        MenuCaracter.SetActive(false);
        MainMenuUI.SetActive(false);
        SettingsUI.SetActive(true);
    }

    public void LoadHighscore()
    {
        MenuCaracter.SetActive(false);
        MainMenuUI.SetActive(false);
    }

    public void LoadShop()
    {
        MenuCaracter.SetActive(false);
        MainMenuUI.SetActive(false);
        ShopUI.SetActive(true);
    }

    public void BackToMain()
    {
        MenuCaracter.SetActive(true);
        MainMenuUI.SetActive(true);
        ShopUI.SetActive(false);
        SettingsUI.SetActive(false);
    }
}
