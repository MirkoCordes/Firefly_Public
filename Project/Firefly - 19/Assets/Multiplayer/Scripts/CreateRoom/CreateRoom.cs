using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviour
{
    string randomRoomName;


    [SerializeField]
    private Text _roomName;
    private Text RoomName
    {
        get { return _roomName; }
    }

    public void OnClick_CreateRoom() {
        RoomOptions roomOptions = new RoomOptions() { IsVisible = false, IsOpen = true, MaxPlayers = 10 };


        randomRoomName = Random.Range(0, 100000).ToString();
        

        if (PhotonNetwork.CreateRoom(randomRoomName, roomOptions, TypedLobby.Default))
        {
            //print("create room successfully sent.");

        } else
        {
            //print("create room failed to sent.");
        }
    }

    private void OnPhotonCreateRoomFailed(object[] codeAndMessage)
    {
        print("create room failed: " + codeAndMessage[1]);
        OnClick_CreateRoom();
    }
}
