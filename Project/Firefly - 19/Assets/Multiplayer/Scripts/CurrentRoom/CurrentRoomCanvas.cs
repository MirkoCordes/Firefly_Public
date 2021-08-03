using Photon;
using UnityEngine;
using UnityEngine.UI;

public class CurrentRoomCanvas : Photon.MonoBehaviour
{

    public GameObject startGameUi;
    public Text numberOfPlayers;
    public GameObject minimumNumberOfPlayersText;
    private Text minimumNumberOfPlayersTextText;
    private int minimumNumberOfPlayers;

    public void OnClickStartDelayed()
    {
        PhotonNetwork.room.IsOpen = false;
        PhotonNetwork.room.IsVisible = false;

        if (PhotonNetwork.isMasterClient)
        {
            PhotonNetwork.LoadLevel(3);
        }
    }

    private void Start()
    {
        minimumNumberOfPlayersTextText = minimumNumberOfPlayersText.GetComponent<Text>();
        
    }

    private void Update()
    {
        if (PhotonNetwork.isMasterClient)
        {
            if (PhotonNetwork.playerList.Length >= 3)
            {
                startGameUi.SetActive(true);
            } else
            {
                startGameUi.SetActive(false);
            }
        }
        minimumNumberOfPlayers = PhotonNetwork.playerList.Length;
        if (minimumNumberOfPlayers < 3)
        {
            minimumNumberOfPlayersText.SetActive(true);
            minimumNumberOfPlayersTextText.text = minimumNumberOfPlayers + "/3";
        } else
        {
            minimumNumberOfPlayersText.SetActive(false);
        }

        numberOfPlayers.text = PhotonNetwork.playerList.Length + "/10";
        
    }
    }
