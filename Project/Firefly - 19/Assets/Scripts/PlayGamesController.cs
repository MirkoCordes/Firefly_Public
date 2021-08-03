using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGamesController : MonoBehaviour
{
    
    /*
    // Start is called before the first frame update
    public static PlayGamesController instance;
    void Start()
    {
        
        PlayGamesPlatform.Activate();

        // authenticate user:
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => {
            // handle results
        });
    }

    

    public static void PostToLeaderboard(long newScore)
    {
        Social.ReportScore(newScore, GPGSIds.leaderboard_high_score, (bool success) => {
            if (success)
            {
                Debug.Log("Posted new score to leaderboard");
            } else
            {
                Debug.LogError("Unable to post new score to leadeerboard");
            }
        });
    }

    public static void ShowLeaderboardUI()
    {
        //Social.ShowLeaderboardUI();
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_high_score);
    }
    */
}
