using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHighscore : MonoBehaviour
{
    public Text score_text;
    public GetScore getScore;
    public int highScore;
    public int score;

    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highScore = PlayerPrefs.GetInt("Highscore");
        }
        
    }
    void Update()
    {
        
    }

    public void GetHighScore(){
        score = getScore.ReturnScore();
        getScore.GETScore();
        UnityEngine.UI.Text t = score_text.GetComponent<UnityEngine.UI.Text>();

        if (score > highScore){
            highScore = score;
        }

        PlayerPrefs.SetInt("Highscore", highScore);
        score_text.text = highScore.ToString();
    }
}
