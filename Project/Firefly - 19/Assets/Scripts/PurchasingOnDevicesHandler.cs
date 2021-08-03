using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasingOnDevicesHandler : MonoBehaviour
{
    public GameObject
        KaufenVideo,
        KaufenEins,
        KaufenZwei,
        KaufenDrei;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        KaufenVideo.SetActive(false);
        KaufenEins.SetActive(false);
        KaufenZwei.SetActive(false);
        KaufenDrei.SetActive(false);
#elif UNITY_ANDROID
        KaufenVideo.SetActive(true);
        KaufenEins.SetActive(true);
        KaufenZwei.SetActive(true);
        KaufenDrei.SetActive(true);
#elif UNITY_IOS
        KaufenVideo.SetActive(true);
        KaufenEins.SetActive(true);
        KaufenZwei.SetActive(true);
        KaufenDrei.SetActive(true);
#else
        KaufenVideo.SetActive(false);
        KaufenEins.SetActive(false);
        KaufenZwei.SetActive(false);
        KaufenDrei.SetActive(false);
#endif
    }
}
