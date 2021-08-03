using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShake : MonoBehaviour
{
    public CameraShake cameraShake;
    public float verzoegerung;

    public AudioSource SwattHitAudio;
    bool isGet;

    private void Start()
    {
        isGet = false;
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Hand"))
        {
            if (GameObject.FindGameObjectWithTag("Hand").GetComponent<BoxCollider2D>().enabled)
            {
                if (!isGet)
                {
                    SwattHitAudio.Play();
                    isGet = true;
                }
                StartCoroutine(cameraShake.Shake(0.15f, 15f));
            }
        }
        else if (GameObject.FindGameObjectWithTag("Swatter")) {
            if (GameObject.FindGameObjectWithTag("Swatter").GetComponent<BoxCollider2D>().enabled)
            {
                if (!isGet)
                {
                    SwattHitAudio.Play();
                    isGet = true;
                }
                StartCoroutine(cameraShake.Shake(0.15f, 15f));
            }
        } else
        {
            isGet = false;
        }
    }
    
}
