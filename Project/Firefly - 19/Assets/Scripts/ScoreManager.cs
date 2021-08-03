using System.Collections;
using System.Collections.Generic;
//using CloudOnce;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //public Text scoreText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        /*Cloud.OnInitializeComplete += CloudOnceInitializeComplete;
        Cloud.Initialize(false, true);
        GetScore();*/
    }

    /*public void CloudOnceInitializeComplete()
    {
        Cloud.OnInitializeComplete -= CloudOnceInitializeComplete;
        Debug.Log("Initialized");
    }*/

    /*public void GetScore()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            score = PlayerPrefs.GetInt("Highscore");
        }
        else
        {
            score = 0;
        }
        
        Leaderboards.HighScore.SubmitScore(score);
    }*/
}
