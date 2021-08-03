using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCanvasManager : MonoBehaviour
{
    public static MainCanvasManager Instance;

    [SerializeField]
    private LobbyCanvas _lobbyCanvas;
    public LobbyCanvas LobbyCanvas
    {
        get { return _lobbyCanvas; }
    }

    [SerializeField]
    private CurrentRoomCanvas _currentRoomCanvas;
    public CurrentRoomCanvas CurrentRoomCanvas
    {
        get { return _currentRoomCanvas; }
    }

    public GameObject NoticePanel;
    public GameObject GlobalPanel;
    public GameObject AddNickName;
    public Text namee;
    public Text randomTextField;
    private string[] botName = new string[] {
        "Anneliese_Brown",
        "Folker",
        "Om4_f1el_1ns_kl0",
        "Agathe_Bauer",
        "Skinnex",
        "Skat_Man",
        "Hektig",
        "Karla",
        "Doobe",
        "ZoomBee",
        "Birdbogs",
        "ColyBri523",
        "Ku3b3l_hu2",
        "Crocodile_dundee",
        "BohRap",
        "WhaasAb",
        "Siegried",
        "Günther",
        "M3inN4me",
        "C0nn3ct1ng",
    };
    int randInt;
    string randName;

    private void Awake()
    {
        Instance = this;
        GlobalPanel.SetActive(false);
        AddNickName.SetActive(false);
        NoticePanel.SetActive(true);
    }

    public void OnClickCloseNotice()
    {
        NoticePanel.SetActive(false);
        GlobalPanel.SetActive(false);
        AddNickName.SetActive(true);
        if (PlayerPrefs.HasKey("nickname"))
        {
            namee.text = PlayerPrefs.GetString("nickname").ToString();
        }
        
        CreateRandomName();
    }

    public void CreateRandomName()
    {
        int randInt = Random.Range(0, 19);
        randName = botName[randInt];
        randomTextField.text = randName;
    }

    public void OnClickSafeName()
    {
        NoticePanel.SetActive(false);
        GlobalPanel.SetActive(true);
        AddNickName.SetActive(false);
        
        if(randomTextField.text.ToString() == randName && namee.text.ToString() == "")
        {
            PhotonNetwork.playerName = randName;
        } else
        {
            PlayerPrefs.SetString("nickname", namee.text.ToString());
            PhotonNetwork.playerName = namee.text.ToString();
        }
        

    }

    public void BackToHome()
    {
        LevelLoader levelLoader = LevelLoader.FindObjectOfType<LevelLoader>();
        levelLoader.LoadNextLevel(0);
    }
}
