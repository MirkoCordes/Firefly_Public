using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DieMenueScript : MonoBehaviour
{
    public GameObject playerObject;             //Player
    PlayerCollision playerCollision;            //playerKollision
    public bool geklickt;                         //Nochmal probieren  
    public bool dieMenuUIActive;

    //Verschiedene UIs
    public GameObject DieMenueUI;
    public GameObject UseHealthUI;
    public GameObject WatchVideoAfterDieUI;

    public GameObject Summerbackground;
    public GameObject Winterbackground;

    //Inventar für herzen
    Inventory myInventory;
    int health;
    
    //Scorecreator für den letzten Score
    public int score;
    public ScoreCreator scoreCreator;
    public GetHighscore getHighscore;
    public GetScore getScore;

    //Audio benutzen zum weiterspielen
    public AudioSource useHeartSound;

    public PauseMenue pauseMenue;
    private GameObject player;


    void Start()
    {
        playerCollision = playerObject.GetComponent<PlayerCollision>();
        myInventory = GameObject.FindObjectOfType<Inventory> ();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        health = myInventory.health;
    }

    public void KeepPlayingGame()
    {
        WatchVideoAfterDieUI.SetActive(false);
        UseHealthUI.SetActive(false);
        geklickt = true;

        if (health >= 1)
        {
            myInventory.MinimizeHealth(1);

            //Background(Clone)
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

            myInventory.SaveInventoryForHealth();
            
        } else
        {
            pauseMenue.InterfaceForRewards();
        }
        StopAllCoroutines();
        playerCollision.KeepPlay();
        dieMenuUIActive = false;


    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
        myInventory.SaveInventoryForCoinsAndGps();
        LevelLoader levelLoader = LevelLoader.FindObjectOfType<LevelLoader>();
        levelLoader.LoadNextLevel(1);
    }

    public void SaveCoins()
    {
        Time.timeScale = 1;
        myInventory.SaveInventoryForCoinsAndGps();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        myInventory.SaveInventoryForCoinsAndGps();
        LevelLoader levelLoader = LevelLoader.FindObjectOfType<LevelLoader>();
        levelLoader.LoadNextLevel(0);
    }

    public void NoThanksFunction()
    {
        dieMenuUIActive = true;
        DieMenueUI.SetActive(true);
        WatchVideoAfterDieUI.SetActive(false);
        UseHealthUI.SetActive(false);
        geklickt = true;
        StopAllCoroutines();
        getScore.GETScore();
        getHighscore.GetHighScore();
    }

    public void OpenDieScreen()
    {
        dieMenuUIActive = true;
        if (health >= 1)
        {
            UseHealthUI.SetActive(true);
        } else
        {
            #if UNITY_EDITOR
                getHighscore.GetHighScore();
                dieMenuUIActive = true;
                DieMenueUI.SetActive(true);
                WatchVideoAfterDieUI.SetActive(false);
                UseHealthUI.SetActive(false);
            #elif UNITY_ANDROID
                WatchVideoAfterDieUI.SetActive(true);
                StartCoroutine(WaitForClick());
            #elif UNITY_IOS
                WatchVideoAfterDieUI.SetActive(true);
                StartCoroutine(WaitForClick());
            #else
                getHighscore.GetHighScore();
                dieMenuUIActive = true;
                DieMenueUI.SetActive(true);
                WatchVideoAfterDieUI.SetActive(false);
                UseHealthUI.SetActive(false); 
            #endif
        }

    }

    public IEnumerator WaitForClick()
    {
        yield return new WaitForSeconds(10f);
        getHighscore.GetHighScore();
        dieMenuUIActive = true;
        DieMenueUI.SetActive(true);
        WatchVideoAfterDieUI.SetActive(false);
        UseHealthUI.SetActive(false);
    }

    public bool DieUIOpen()
    {
        return dieMenuUIActive;
    }
}
