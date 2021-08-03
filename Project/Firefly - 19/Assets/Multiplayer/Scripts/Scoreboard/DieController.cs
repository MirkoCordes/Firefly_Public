using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class DieController : Photon.MonoBehaviour
{
    private GameObject Scoreboard;
    private GameObject levelCounter;
    public RoundCounterController roundCounterController;
    public GameObject NextLevelAnzeige;
    public bool iAmDead;
    public static int areDead;
    public GameObject closeScoreBoard;
    public int playersInGame;
    private int winnerId;
    public GameObject winnerPanel;
    private int[] SpielerRundenPunkte;
    PhotonPlayer[] temppList;
    PhotonPlayer[] pList;

    //Für Scoreboard Handler
    PhotonView PV;

    // Start is called before the first frame update
    void Start()
    {
        winnerId = 0;
        Scoreboard = GameObject.Find("Canvas").transform.Find("Safe Area").transform.Find("ScoreBoard").gameObject;
        Scoreboard.SetActive(false);

        playersInGame = PhotonNetwork.playerList.Length;
        levelCounter = GameObject.Find("LevelCounter");

        //Für ScoreBoardHandler
        closeScoreBoard.SetActive(true);
        areDead = 0;
        SpielerRundenPunkte = new int[PhotonNetwork.playerList.Length+1];
        PV = gameObject.GetComponent<PhotonView>();
        PlayersInGame = PhotonNetwork.playerList.Length - 1;
    }

    private void Update()
    {
        for (int i=10; i>playersInGame;i--)
        {
            Scoreboard.transform.Find("Scroll View").transform.Find("Viewport").transform.Find("ScorePlayerListing" + i).gameObject.SetActive(false);
        }

        if (Scoreboard.activeSelf && PhotonNetwork.playerList != temppList || temppList == null)
        {
            UpdateScoreboard();
        } else if (PhotonNetwork.playerList != temppList || temppList == null)
        {
            UpToDate();
        }

    }

    public void OpenScoreBoard()
    {
        //show scoreboard
        Scoreboard.SetActive(true);
        UpdateScoreboard();
    }

    public void UpToDate()
    {
        temppList = PhotonNetwork.playerList;
        pList = PhotonNetwork.playerList;
        System.Array.Sort(pList, delegate (PhotonPlayer p1, PhotonPlayer p2) { return p1.GetScore().CompareTo(p2.GetScore()); });
        System.Array.Reverse(pList);
        SetWinnerID(pList[0].ID);
    }

    private void UpdateScoreboard()
    {
        UpToDate();

        for (int i=0; i<playersInGame; i++)
        {
            int number = i + 1;
            
            if (PhotonNetwork.player.ID == pList[i].ID)
            {
                
                Scoreboard.transform.Find("Scroll View").transform.Find("Viewport").transform.Find("ScorePlayerListing" + number.ToString()).transform.Find("Image").transform.Find("Place").transform.Find("Image").transform.Find("Name").transform.Find("Image").transform.Find("Points").gameObject.GetComponent<Text>().color = Color.green;
                Scoreboard.transform.Find("Scroll View").transform.Find("Viewport").transform.Find("ScorePlayerListing" + number.ToString()).transform.Find("Image").transform.Find("Place").transform.Find("Image").transform.Find("Name").gameObject.GetComponent<Text>().color = Color.green;
                Scoreboard.transform.Find("Scroll View").transform.Find("Viewport").transform.Find("ScorePlayerListing" + number.ToString()).gameObject.GetComponent<FillInformationsController>().points = pList[i].GetScore().ToString();
                Scoreboard.transform.Find("Scroll View").transform.Find("Viewport").transform.Find("ScorePlayerListing" + number.ToString()).gameObject.GetComponent<FillInformationsController>().Name = pList[i].NickName + " (You)";
            }
            else
            {
                Scoreboard.transform.Find("Scroll View").transform.Find("Viewport").transform.Find("ScorePlayerListing" + number.ToString()).transform.Find("Image").transform.Find("Place").transform.Find("Image").transform.Find("Name").transform.Find("Image").transform.Find("Points").gameObject.GetComponent<Text>().color = Color.white;
                Scoreboard.transform.Find("Scroll View").transform.Find("Viewport").transform.Find("ScorePlayerListing" + number.ToString()).transform.Find("Image").transform.Find("Place").transform.Find("Image").transform.Find("Name").gameObject.GetComponent<Text>().color = Color.white;
                Scoreboard.transform.Find("Scroll View").transform.Find("Viewport").transform.Find("ScorePlayerListing" + number.ToString()).gameObject.GetComponent<FillInformationsController>().points = pList[i].GetScore().ToString();
                Scoreboard.transform.Find("Scroll View").transform.Find("Viewport").transform.Find("ScorePlayerListing" + number.ToString()).gameObject.GetComponent<FillInformationsController>().Name = pList[i].NickName;
            }
        }
        
    }

    public void SetWinnerID(int Id)
    {
        winnerId = Id;
    }

    public int ReturnWinnerID()
    {
        return winnerId;
    }

    public void OpenDieCounter()
    {
        if (RoundCounterController.ReturnCounterInt() != playersInGame)
        {
            OpenScoreBoard();
            NextLevelAnzeige.SetActive(true);
            StartCoroutine(CountDownScoreBoard());
        } else
        {
            
            winnerPanel.SetActive(true);
            PhotonNetwork.DestroyAll();
            roundCounterController.SetExitGameButton();
        }
    }

    public void HideScoreBoard()
    {
        Scoreboard.SetActive(false);
    }

    public void LoadNextRound()
    {
        PhotonNetwork.LoadLevel(3);
    }

    public void ExitGameAfterRounds()
    {
        PhotonNetwork.player.SetScore(0);
        PhotonNetwork.Disconnect();
        Destroy(levelCounter);
        SceneManager.LoadScene(0);
    }

    public bool ReturnIAmDead()
    {
        return iAmDead;
    }

    public void IDied()
    {
        iAmDead = true;
    }

    IEnumerator CountDownScoreBoard()
    {
        yield return new WaitForSeconds(5.0f);
        if (PhotonNetwork.isMasterClient)
        {
            LoadNextRound();
        }

    }






    //ScoreboardHandler
    private int PlayersInGame;
   

    [PunRPC]
    void RPC_PlayerDied(int playerId)
    {
        
        PlayersInGame--;
        areDead++;
        SpielerRundenPunkte[playerId] = areDead;
        


        if (PlayersInGame <= 1)
        {
            for (int b = 1; b <=PhotonNetwork.playerList.Length; b++)
            {
                if(SpielerRundenPunkte[b] != 0)
                {
                    PhotonNetwork.player.Get(b).AddScore(SpielerRundenPunkte[b]);
                } else
                {
                    PhotonNetwork.player.Get(b).AddScore(PhotonNetwork.playerList.Length);
                }
                
            }

        LadeOeffnenScoreBoard();
        }
        
    }

    private void LadeOeffnenScoreBoard()
    {
        //Endscreen Starten
        PV.RPC("ScoreBoardOeffnen", PhotonTargets.All);
    }

    [PunRPC]
    void ScoreBoardOeffnen()
    {
        closeScoreBoard.SetActive(false);
        UpdateScoreboard();
        OpenDieCounter();
    }
}
