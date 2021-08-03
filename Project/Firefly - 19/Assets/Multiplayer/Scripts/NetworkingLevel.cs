using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkingLevel : Photon.MonoBehaviour
{
    private GameObject startScreen;
    private GameObject canvas;
    private GameObject waitScreen;
    private int PlayersInGame = 0;
    private PhotonView PhotonView;
    //public GameObject[] Spawnpoints;

    // Start is called before the first frame update
    void Start()
    {
        PhotonView = GetComponent<PhotonView>();
        
        canvas = GameObject.Find("Canvas");


        //Spawn(Spawnpoints);
        startScreen = canvas.transform.Find("StartScreen").gameObject;
        waitScreen = canvas.transform.Find("WaitScreen").gameObject;
        startScreen.SetActive(false);
        waitScreen.SetActive(true);

        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
    }

    [PunRPC]
    private void RPC_LoadedGameScene()
    {
        PlayersInGame++;
        if (PlayersInGame == PhotonNetwork.playerList.Length)
        {
             MasterLoadedGame();
        }
    }

    private void MasterLoadedGame()
    {
        PhotonView.RPC("RPC_StartCountdown", PhotonTargets.All);
    }

    /*void Spawn(GameObject[] Spawnpoint)
    {
       Vector3 spawnpt = Spawnpoint[PhotonNetwork.player.ID].GetComponent<Vector3>();
       PhotonNetwork.Instantiate("Player", spawnpt, Quaternion.identity);
    }
    */

    [PunRPC]
    private void RPC_StartCountdown()
    {
        startScreen.SetActive(true);
        waitScreen.SetActive(false);
    }

    public int ReturnPlayersInGame()
    {
        return PlayersInGame;
    }
}
