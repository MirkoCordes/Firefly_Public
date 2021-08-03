using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCreator : MonoBehaviour
{
    public static bool isTimerRunning;
    public static System.Diagnostics.Stopwatch stopwatch;
    public int score;
    public int scoreTime;
    GameObject player;
    public int tempScore;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("Player");
        isTimerRunning = false;
        stopwatch = new System.Diagnostics.Stopwatch();
        startTimer();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject score_text = GameObject.Find("Score");
        UnityEngine.UI.Text t = score_text.GetComponent<UnityEngine.UI.Text>();

        if (isTimerRunning)
        {
            scoreTime = (int)(stopwatch.ElapsedMilliseconds / 10f);
        }
        if (!player.GetComponent<PlayerCollision>().GetRunningGameAsk() || GameObject.Find("Play_Canvas").GetComponent<PauseMenue>().GameIsPaused)
        {
            stopTimer();
        } else if (!GameObject.Find("Play_Canvas").GetComponent<PauseMenue>().GameIsPaused)
        {
            startTimer();
        }

        if (PlayerPrefs.HasKey("TempScore"))
        {
            score = scoreTime + PlayerPrefs.GetInt("TempScore");
        } else
        {
            score = scoreTime;
        }

        t.text = score.ToString();
    }

    public static void startTimer()
    {
        isTimerRunning = true;
        stopwatch.Start() ;
    }

    public static void stopTimer()
    {
        isTimerRunning = false;
        stopwatch.Stop();

    }

    public static void resetTimer()
    {
        stopwatch.Reset();
        GameObject score_text = GameObject.Find("Score");
        UnityEngine.UI.Text t = score_text.GetComponent<UnityEngine.UI.Text>();
        t.text = "0";
    }

    public int GetScore()
    {
        return score;
    }
    


}
