using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;

public class JoinRoomHandler : Photon.MonoBehaviour
{
    public GameObject JoinRoomUi;
    public Text CodeText;
    public GameObject NotFoundServerPanel;
    public GameObject PleaseWaitPanel;
    public Button JoinCodeRoomButton;
    private string CodeTextText;
    string randomRoomName;


    // Start is called before the first frame update
    void Start()
    {
        JoinRoomUi.SetActive(false);
        PleaseWaitPanel.SetActive(false);
    }

    private void Update()
    {
        CodeTextText = CodeText.text;

        if (CodeText.text == "")//&& JoinRoomUi.activeSelf)
        {
            JoinCodeRoomButton.interactable = false;
        } else
        {
            JoinCodeRoomButton.interactable =true;
        }
    }

    public void OnClickOpenJoinRoomUi()
    {
        JoinRoomUi.SetActive(true);
    }

    public void OnClickJoinRoom()
    {
        PleaseWaitPanel.SetActive(true);

        PhotonNetwork.JoinRoom(CodeTextText);
    }

    

    private void OnJoinedRoom()
    {
        PleaseWaitPanel.SetActive(false);
        JoinRoomUi.SetActive(false);
    }


    private void OnPhotonJoinRoomFailed()
    {
        //Server nicht gefunden
        PleaseWaitPanel.SetActive(false);
        JoinRoomUi.transform.Find("Close").gameObject.SetActive(false);
        NotFoundServerPanel.SetActive(true);
    }

    public void OnClickCloseNotFoundPanel()
    {
        JoinRoomUi.transform.Find("Close").gameObject.SetActive(true);
        NotFoundServerPanel.SetActive(false);
    }

    public void OnClickCloseJoinRoomUi()
    {
        if (PhotonNetwork.inRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
        NotFoundServerPanel.SetActive(false);
        PleaseWaitPanel.SetActive(false);
        JoinRoomUi.SetActive(false);
    }


    public void OnClick_JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed(){
        CreateRandomRoom();
    }

    public void CreateRandomRoom()
    {
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 10 };


        randomRoomName = Random.Range(0, 100000).ToString();


        if (PhotonNetwork.CreateRoom(randomRoomName, roomOptions, TypedLobby.Default))
        {
            //print("create room successfully sent.");

        }
        else
        {
            //print("create room failed to sent.");
        }
    }
}
