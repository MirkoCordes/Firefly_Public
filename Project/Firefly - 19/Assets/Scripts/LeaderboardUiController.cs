using UnityEngine;

public class LeaderboardUiController : MonoBehaviour
{
/*
    bool loginSuccessful;
    int myScore;
    string leaderboardID = "com.MirkoCordes.Firefly.Leaderboard";

    private void Start()
    {
        AuthenticateUser();
        if (PlayerPrefs.HasKey("Highscore"))
        {
            myScore = PlayerPrefs.GetInt("Highscore");
        } else
        {
            myScore = 0;
        }
    }

    void AuthenticateUser()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                loginSuccessful = true;
            }
            else
            {
                Debug.Log("Login unsuccessfull");
            }
        });
    }

    public void OnButtonPostToLeaderboard()
    {
        if (loginSuccessful)
        {
            Social.ReportScore(myScore, leaderboardID, (bool success) =>
            {
                if (success)
                {
                    Debug.Log("Successfully uploaded!");
                }
            });
        } else
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    loginSuccessful = true;
                    Social.ReportScore(myScore, leaderboardID, (bool successful) =>
                    {
                        //Handle successful or failure
                    });
                }
                else
                {
                    Debug.Log("Successfully uploaded!");
                }
            });
        }
        Social.ShowLeaderboardUI();
    }
    */

    public void PostToLeaderboard()
    {
        
        Social.ReportScore(PlayerPrefs.GetInt("Highscore"), GPGSIds.leaderboard_high_score, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Posting score to Leaderboard");
            }
        }
        );
    }

    public void ShowLeaderboard()
    {
        //PostToLeaderboard();
        Social.ShowLeaderboardUI();
        //Debug.Log("Showing leaderboard");
        //PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_high_score);
    }
}
