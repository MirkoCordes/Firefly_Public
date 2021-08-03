using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public bool gameIsRunning;

    Inventory myInventory;
    int health;

    public AudioSource coinsAudio;
    public AudioSource GpsAudio;
    public AudioSource hittedSound;

    public Camera camerah;


    GameObject hornetGenerator;
    GameObject clapGenerator;
    GameObject handGenerator;
    GameObject setCoins;
    GameObject backLights1;
    GameObject backlights2;

    //Generator Controller
    public SetHornetSpawnerController setHornetSpawnerController;
    public clapSpawnerController clapSpawnController;
    public HandKickController handKickController;
    public CoinSpawner coinSpawner1;
    public CoinSpawner coinSpawner2;
    public CoinSpawner coinSpawner3;
    public CoinSpawner coinSpawner4;
    public CoinSpawner coinSpawner5;
    //CloudSpawner
    public CloudBackgroundSpawner cloudBackgroundSpawner;
    public CloudSpawner cloudSpawner1;
    public CloudSpawner cloudSpawner2;
    public CloudSpawner cloudSpawner3;
    //Joystick
    public GameObject joystick;

    DieMenueScript dieMenueScript;
    public bool playAfterDie;

    void Start()
    {
    hornetGenerator = GameObject.Find("SetHornetSpawner");
    clapGenerator = GameObject.Find("ClapGenerator");
    handGenerator = GameObject.Find("HandGenerator");
    setCoins = GameObject.Find("SetCoins");
    backLights1 = GameObject.Find("Backlights");
    backlights2 = GameObject.Find("Backlights 1");

    myInventory = GameObject.FindObjectOfType<Inventory>();
    health = myInventory.health;
    dieMenueScript = GameObject.FindObjectOfType<DieMenueScript>();
    gameIsRunning = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Shield"))
        {
            if (collision.gameObject.tag == "Enemie" || collision.gameObject.tag == "Hand" || collision.gameObject.tag == "Swatter" || collision.gameObject.tag == "Hornet" || collision.gameObject.tag == "Raindrop")
            {
                Destroy(collision.gameObject);
            }
        }
        else
        {
            if (collision.gameObject.tag == "Enemie" || collision.gameObject.tag == "Hand" || collision.gameObject.tag == "Swatter" || collision.gameObject.tag == "Hornet" || collision.gameObject.tag == "Raindrop")
            {
                hittedSound.Play();
                gameIsRunning = false;

                setHornetSpawnerController.StopSpawning();
                clapSpawnController.StopSpawning();
                handKickController.StopSpawning();
                coinSpawner1.StopSpawning();
                coinSpawner2.StopSpawning();
                coinSpawner3.StopSpawning();
                coinSpawner4.StopSpawning();
                coinSpawner5.StopSpawning();
                cloudBackgroundSpawner.StopSpawning();
                cloudSpawner1.StopSpawning();
                cloudSpawner2.StopSpawning();
                cloudSpawner3.StopSpawning();
                setCoins.SetActive(false);
                joystick.SetActive(false);
                dieMenueScript.OpenDieScreen();
            }
        }

        if (collision.gameObject.tag == "Coins")
        {
            myInventory.AddTempCoins();

            //Sound abspielen
            coinsAudio.Play();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Shield"))
        {
            if (collision.gameObject.tag == "Enemie" || collision.gameObject.tag == "Hand" || collision.gameObject.tag == "Swatter" || collision.gameObject.tag == "Hornet" || collision.gameObject.tag == "Raindrop")
            {
                Destroy(collision.gameObject);
            }
        }
        else
        {
            if (collision.gameObject.tag == "Enemie" || collision.gameObject.tag == "Hand" || collision.gameObject.tag == "Swatter" || collision.gameObject.tag == "Hornet" || collision.gameObject.tag == "Raindrop")
            {
                hittedSound.Play();
                gameIsRunning = false;
                
                setHornetSpawnerController.StopSpawning();
                clapSpawnController.StopSpawning();
                handKickController.StopSpawning();
                coinSpawner1.StopSpawning();
                coinSpawner2.StopSpawning();
                coinSpawner3.StopSpawning();
                coinSpawner4.StopSpawning();
                coinSpawner5.StopSpawning();
                cloudBackgroundSpawner.StopSpawning();
                cloudSpawner1.StopSpawning();
                cloudSpawner2.StopSpawning();
                cloudSpawner3.StopSpawning();
                setCoins.SetActive(false);
                joystick.SetActive(false);
                dieMenueScript.OpenDieScreen();
            }
        }

        if (collision.gameObject.tag == "Coins")
        {
            myInventory.AddTempCoins();

            //Sound abspielen
            coinsAudio.Play ();
        }

    }

    public void KeepPlay()
    {
        gameIsRunning = true;

        setHornetSpawnerController.StartSpawning();
        clapSpawnController.StartSpawning();
        handKickController.StartSpawning();
        
        coinSpawner1.StartSpawning();
        coinSpawner2.StartSpawning();
        coinSpawner3.StartSpawning();
        coinSpawner4.StartSpawning();
        coinSpawner5.StartSpawning();

        cloudBackgroundSpawner.StartSpawning();
        cloudSpawner1.StartSpawning();
        cloudSpawner2.StartSpawning();
        cloudSpawner3.StartSpawning();
        setCoins.SetActive(true);
        joystick.SetActive(true);
    }

    public bool GetRunningGameAsk()
    {
        return gameIsRunning;
    }

}
