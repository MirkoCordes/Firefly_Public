using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
//using GoogleMobileAds.Api;

public class AdManagerScript : MonoBehaviour
{
#if UNITY_IOS
    string gameId = "3599319";
#elif UNITY_ANDROID
    string gameId = "3599318";
#endif

    bool testMode = false;

    void Start()
    {
        
#if UNITY_IOS
        Advertisement.Initialize(gameId);
        if (Advertisement.IsReady("Mainmenu"))
        {
            // Show an ad:
            Advertisement.Load("Mainmenu");
            Advertisement.Show("Mainmenu");
        }
#elif UNITY_ANDROID
        Advertisement.Initialize(gameId);
        if (Advertisement.IsReady("Mainmenu"))
        {
            // Show an ad:
            Advertisement.Load("Mainmenu");
            Advertisement.Show("Mainmenu");
        }
#endif

    }
}
