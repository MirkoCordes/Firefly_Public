using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;

public class RoundCounterController : Photon.MonoBehaviour
{
    public Text Roundtext;
    public GameObject ExitGameButton;

    private static int counter;
    
    private LevelCounter levelCounter;

    // Start is called before the first frame update
    void Start()
    {
        levelCounter = LevelCounter.FindObjectOfType<LevelCounter>();
        counter = levelCounter.CounterHozaehlen();

        switch (counter)
        {
            case 1: Roundtext.text = "1st"; break;
            case 2: Roundtext.text = "2nd"; break;
            case 3: Roundtext.text = "3rd"; break;
            case 4: Roundtext.text = "4th"; break;
            case 5: Roundtext.text = "5th"; break;
            case 6: Roundtext.text = "6th"; break;
            case 7: Roundtext.text = "7th"; break;
            case 8: Roundtext.text = "8th"; break;
            case 9: Roundtext.text = "9th"; break;
            case 10: Roundtext.text = "10th"; break;
        }

        PruefenObLetzteRunde();
    }

    public void PruefenObLetzteRunde()
    {
        if (PhotonNetwork.playerList.Length == counter)
        {
            //WinnerScene erstellen und verlinken
            Roundtext.text = "Last";
            
        }
        ExitGameButton.SetActive(false);
    }

    public void SetExitGameButton()
    {
        ExitGameButton.SetActive(true);
    }

    public static int ReturnCounterInt()
    {
        return counter;
    }
    
}
