using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

    //1 => verbinde mit dem Server
    public void Connect()
    {
        Debug.Log("hi");
        if(!PhotonNetwork.connected)
            PhotonNetwork.ConnectUsingSettings("2.0");

        Debug.Log("hallo");
    }
    
    //2 => nach Serververbindung
    private void OnConnectedToMaster()
    {

        //PhotonNetwork.playerName = PlayerNetwork.Instance.PlayerName;
        PhotonNetwork.JoinLobby();                    //mit standartlobby verbinden
    }

    //3 => mit standartlobby verbunden
    void OnJoinedLobby()
    {
        //LobbyObject wird nach vorn geschoben
        if (!PhotonNetwork.inRoom)
        {
            MainCanvasManager.Instance.LobbyCanvas.transform.SetAsLastSibling();
        }
        
    }
    

    //wenn disconnected -> (1)
    private void OnDisconnectedFromServer()
    {
        PhotonNetwork.Reconnect();
    }
    
    public void Start()
    {
        PhotonNetwork.automaticallySyncScene = true;                    //automatisch Scenen synchronisieren
        Connect();
    }
}
