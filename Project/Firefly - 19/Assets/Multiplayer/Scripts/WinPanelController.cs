using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanelController : MonoBehaviour
{
    private GameObject Panel;
    public Text texti;
    public DieController dieController;
    public GameObject winnerParticle;
    public GameObject[] minimapObjects;
    public AudioSource boo;
    public AudioSource yeah;

    private void Start()
    {
        winnerParticle.SetActive(true);
        Panel = gameObject;
        dieController.UpToDate();
        minimapObjects[0].SetActive(false);
        minimapObjects[1].SetActive(false);



        if (PhotonNetwork.player.ID == dieController.ReturnWinnerID())
        {
            texti.text = "You won this game!";
            yeah.Play();
        }
        else
        {
            texti.text = PhotonNetwork.player.Get(dieController.ReturnWinnerID()).NickName.ToString() + " won this game!";
            boo.Play();
        }
        
        
    }
    public void OnClickCloseYouLoseInformation()
    {
        Panel.SetActive(false);
        winnerParticle.SetActive(false);
        dieController.OpenScoreBoard();
    }
}
