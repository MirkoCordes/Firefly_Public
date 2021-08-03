using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenue : MonoBehaviour
{
    public bool GameIsPaused = false;
    public int StopGame;
    public DieMenueScript dieMenueScript;
    public GameObject pauseMenuUI;
    public GameObject rewardPauseUI;
    public GameObject SettingsMenueUI;
    public GameObject controllerUI;
    Inventory myInventory;
    public GameObject Summerbackground;
    public GameObject Winterbackground;
    private GameObject player;


    void Start()
    {
        StopGame = 0;
        myInventory = GameObject.FindObjectOfType<Inventory>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !GameIsPaused)
        {
            Pause();
        }
        if (GameIsPaused)
        {
            Time.timeScale = 0;
            controllerUI.SetActive(false);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        rewardPauseUI.SetActive(false);
        GameIsPaused = false;
        controllerUI.SetActive(true);
    }

    public void ResumeForHealth()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        rewardPauseUI.SetActive(false);
        GameIsPaused = false;
        controllerUI.SetActive(true);
        //
        player.transform.position = new Vector3(0, 0);

        if (myInventory.GetStandardBackground())
        {
            Vector3 ort = new Vector3(GameObject.Find("Background(Clone)").GetComponent<Transform>().position.x, GameObject.Find("Background(Clone)").GetComponent<Transform>().position.y, GameObject.Find("Background(Clone)").GetComponent<Transform>().position.z);
            Destroy(GameObject.Find("Background(Clone)"));
            GameObject bgrnd = (GameObject)Instantiate(Summerbackground, ort, Quaternion.identity) as GameObject;
        }
        else
        {
            Vector3 ort = new Vector3(GameObject.Find("BackgroundWInter(Clone)").GetComponent<Transform>().position.x, GameObject.Find("BackgroundWInter(Clone)").GetComponent<Transform>().position.y, GameObject.Find("BackgroundWInter(Clone)").GetComponent<Transform>().position.z);
            Destroy(GameObject.Find("BackgroundWInter(Clone)"));
            GameObject bgrnd = (GameObject)Instantiate(Winterbackground, ort, Quaternion.identity) as GameObject;
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    public void InterfaceForRewards()
    {
        rewardPauseUI.SetActive(true);
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SettingsMenueUI.SetActive(true);
    }

    public void QuitGame()
    {
        GameIsPaused = false;
        
        LevelLoader levelLoader = LevelLoader.FindObjectOfType<LevelLoader>();
        levelLoader.LoadNextLevel(0);
    }

    public void BackToMain()
    {
        SettingsMenueUI.SetActive(false);
    }
    
    public void PlayerDie()
    {
        Time.timeScale = 0;
    }

    public void LoadMenuAfterDie()
    {
        Time.timeScale = 1;
    }

    void OnApplicationPause()
    {
        if (!dieMenueScript.DieUIOpen())
        {
            Pause();
        }
        
    }
}

