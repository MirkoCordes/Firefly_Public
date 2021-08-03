using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLayoutGroup : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerListingPrefab;
    private GameObject PlayerListingPrefab
    {
        get { return _playerListingPrefab; }
    }

    [SerializeField]
    private Text _roomNam;
    public Text RoomNam
    {
        get { return _roomNam; }
    }


    private List<PlayerListing> _playerListings = new List<PlayerListing>();
    private List<PlayerListing> PlayerListings
    {
        get { return _playerListings; }
    }

    private void OnMasterClientSwitched(PhotonPlayer photonPlayer)
    {
        PhotonNetwork.LeaveRoom();
    }

    private void OnJoinedRoom()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        MainCanvasManager.Instance.CurrentRoomCanvas.transform.SetAsLastSibling();

        PhotonPlayer[] photonPlayers = PhotonNetwork.playerList;
        for (int i = 0; i < photonPlayers.Length; i++)
        {
            PlayerJoinedRoom(photonPlayers[i]);
        }
        
        RoomNam.text = "Code: " + PhotonNetwork.room.Name;

    }

    private void OnPhotonPlayerConnected(PhotonPlayer photonPlayer)
    {
        PlayerJoinedRoom(photonPlayer);
    }

    private void PlayerJoinedRoom(PhotonPlayer photonPlayer)
    {
        if (photonPlayer == null)
        {
            return;
        }
        PlayerLeftRoom(photonPlayer);

        GameObject playerListingObj = Instantiate(PlayerListingPrefab);
        playerListingObj.transform.SetParent(transform, false);

        PlayerListing playerListing = playerListingObj.GetComponent<PlayerListing>();
        playerListing.ApplyPhotonPayer(photonPlayer);

        PlayerListings.Add(playerListing);
    }



    private void OnPhotonPlayerDisconnected(PhotonPlayer photonPlayer)
    {
        PlayerLeftRoom(photonPlayer);
    }

    private void PlayerLeftRoom(PhotonPlayer photonPlayer)
    {
        int index = PlayerListings.FindIndex(x => x.PhotonPlayer == photonPlayer);
        if (index != -1)
        {
            Destroy(PlayerListings[index].gameObject);
            PlayerListings.RemoveAt(index);
        }
    }

    public void OnClickRoomState()
    {
        if (PhotonNetwork.isMasterClient)
        {
            return;
        }

        PhotonNetwork.room.IsOpen = !PhotonNetwork.room.IsOpen;
        PhotonNetwork.room.IsVisible = PhotonNetwork.room.IsOpen;
    }

    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
}
