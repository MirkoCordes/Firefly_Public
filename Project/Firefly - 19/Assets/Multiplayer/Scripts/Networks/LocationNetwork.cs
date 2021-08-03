using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LocationNetwork : Photon.MonoBehaviour
{
    public GameObject[] spawnPoints;
    private int gameMemberId;
    private LevelCounter levelCounter;

    public GameObject gameMemberButtons;
    public GameObject gameMemberButtons2;
    public GameObject joyStickUi;
    public GameObject WarningSignals;
    public GameObject DieScreen;

    //minimap
    public GameObject minimapBorder;
    public GameObject minimapRender;
    public GameObject minimapBackground;

    public GameObject HornetWarner;
    public GameObject RainWarner;
    //public GameObject HandWarner;
    private bool handActive;
    private bool isHand;
    

    Inventory myInventory;
    GameObject cha;

    //public GameObject SwatterWarner;

    //private int numberOfBots;
    //public int botNumber;

    private void Start()

    {
        myInventory = Inventory.FindObjectOfType<Inventory>();

        levelCounter = LevelCounter.FindObjectOfType<LevelCounter>();
        gameMemberId = levelCounter.ReturnGameMemberId();

        //gameMemberId = PlayerPrefs.GetInt("gameMemberId");
        //print("GameMemberID = " + gameMemberId);
        //print("PlayerID = " + PhotonNetwork.player.ID);

        if (gameMemberId == 0)
        {
            gameMemberId = 1;
        }
        if (gameMemberId != PhotonNetwork.player.ID)
        {
            gameMemberButtons.SetActive(false);
            gameMemberButtons2.SetActive(false);
            Spawn(PhotonNetwork.player.ID);
        } else
        {
            //Button aktivieren
            gameMemberButtons.SetActive(true);
            gameMemberButtons2.SetActive(true);
            joyStickUi.SetActive(false);
            //numberOfBots = PlayerPrefs.GetInt("numberOfBots");
            //SpawnBot();

            //minimap deaktivieren
            minimapBackground.SetActive(false);
            minimapBorder.SetActive(false);
            minimapRender.SetActive(false);
        }
        

        HornetWarner.SetActive(false);
        RainWarner.SetActive(false);
        //HandWarner.SetActive(false);
        //SwatterWarner.SetActive(false);
    }


    
    



        void Spawn(int iD)
    {
        Vector3 spawnPoint = spawnPoints[iD - 1].GetComponent<Transform>().position;

        //Erscheinen des Prefabs
        //GameObject gaOb = (GameObject)PhotonNetwork.Instantiate("plr", spawnPoint, Quaternion.identity, 0) as GameObject;
        if (myInventory.GetRedChar() || PlayerPrefs.GetInt("redCharacterBuyedActivated") == 1)
        {
            cha = (GameObject)PhotonNetwork.Instantiate("rplr", spawnPoint, Quaternion.identity, 0) as GameObject;
        }
        else if (myInventory.GetPinkChar() || PlayerPrefs.GetInt("pinkCharacterBuyedActivated") == 1)
        {
            cha = (GameObject)PhotonNetwork.Instantiate("pplr", spawnPoint, Quaternion.identity, 0) as GameObject;
        }
        else if (myInventory.GetYellowChar() || PlayerPrefs.GetInt("yellowCharacterBuyedActivated") == 1)
        {
            cha = (GameObject)PhotonNetwork.Instantiate("yplr", spawnPoint, Quaternion.identity, 0) as GameObject;
        }
        else if (myInventory.GetBlueChar() || PlayerPrefs.GetInt("blueCharacterBuyedActivated") == 1)
        {
            cha = (GameObject)PhotonNetwork.Instantiate("bplr", spawnPoint, Quaternion.identity, 0) as GameObject;
        }
        else if (myInventory.GetNormalChar() || PlayerPrefs.GetInt("normalCharacterActivated") == 1)
        {
            cha = (GameObject)PhotonNetwork.Instantiate("plr", spawnPoint, Quaternion.identity, 0) as GameObject;
        }
    }

    /*
    void SpawnBot()
    {
        if (botNumber<numberOfBots)
        {
            Vector3 spawnPoint = spawnPoints[botNumber].GetComponent<Transform>().position;
            PhotonNetwork.Instantiate("PlayerBot", new Vector3(spawnPoint.x, spawnPoint.y, spawnPoint.z), Quaternion.identity, 0);
            StartCoroutine(WaitBeforeSpawn());
        }

        for (int i=0; i<numberOfBots; i++)
        {
            
            
        }
    }
    

    public int BotNumberReturn()
    {
        return botNumber;
    }

    IEnumerator WaitBeforeSpawn()
    {
        yield return new WaitForSeconds(0.15f);
        botNumber++;
        SpawnBot();
    }
    */

    public void OpenDieScreen()
    {
        if (levelCounter.ReturnCounter() != PhotonNetwork.playerList.Length)
        {
            DieScreen.SetActive(true);
        }
        
    }

    public void ActivateHornetWarner()
    {
        if (gameMemberId != PhotonNetwork.player.ID)
        {
            StopCoroutine(DeactivateHornetSignal());
            HornetWarner.SetActive(false);
            HornetWarner.SetActive(true);
            StartCoroutine(DeactivateHornetSignal());
        }
    }
    IEnumerator DeactivateHornetSignalshort()
    {
        yield return new WaitForSeconds(1.5f);
        HornetWarner.SetActive(false);
    }

    public void ActivateRainWarner()
    {
        if (gameMemberId != PhotonNetwork.player.ID)
        {
            StopCoroutine(DeactivateRainSignal());
            RainWarner.SetActive(false);
            RainWarner.SetActive(true);
            StartCoroutine(DeactivateRainSignal());
        }
    }
    IEnumerator DeactivateRainSignalshort()
    {
        yield return new WaitForSeconds(1.5f);
        HornetWarner.SetActive(false);
    }


    public void ActivateHandWarner()
    {
        if (gameMemberId != PhotonNetwork.player.ID)
        {
            //HandWarner.SetActive(false);
            StopCoroutine(DeactivateHandSignal());
            handActive = true;
            isHand = true;
            //HandWarner.SetActive(true);
            StartCoroutine(DeactivateHandSignal());
        }
    }

    public void ActivateSwatterWarner()
    {
        if (gameMemberId != PhotonNetwork.player.ID)
        {
            //SwatterWarner.SetActive(false);
            StopCoroutine(DeactivateSwatterSignal());
            handActive = true;
            isHand = false;
            //SwatterWarner.SetActive(true);
            StartCoroutine(DeactivateSwatterSignal());
        }
    }

    public bool ReturnHandActive()
    {
        return handActive;
    }

    public bool ReturnIsHand()
    {
        return isHand;
    }

    IEnumerator DeactivateHornetSignal()
    {
        yield return new WaitForSeconds(1.5f);
        HornetWarner.SetActive(false);
    }
    IEnumerator DeactivateRainSignal()
    {
        yield return new WaitForSeconds(1.5f);
        RainWarner.SetActive(false);
    }
    IEnumerator DeactivateHandSignal()
    {
        yield return new WaitForSeconds(1.5f);
        handActive = false;
        //HandWarner.SetActive(false);
    }
    IEnumerator DeactivateSwatterSignal()
    {
        yield return new WaitForSeconds(1.5f);
        handActive = false;
        //SwatterWarner.SetActive(false);
    }
}
