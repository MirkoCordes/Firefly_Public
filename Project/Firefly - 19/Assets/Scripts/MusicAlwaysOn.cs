using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicAlwaysOn : MonoBehaviour
{

    public static MusicAlwaysOn instance;
    public AudioMixer MusicMixer;
    public AudioMixer SoundMixer;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //GameObject schon vorhanden?
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (PlayerPrefs.HasKey("SoundMuted"))
        {
            if (PlayerPrefs.GetInt("SoundMuted") == 1)
            {
                SoundMixer.SetFloat("SoundVol", Mathf.Log10(0.0001f) * 20);
            }
        }
        if (PlayerPrefs.HasKey("MusicMuted"))
        {
            if (PlayerPrefs.GetInt("MusicMuted") == 1)
            {
                MusicMixer.SetFloat("MusicVol", Mathf.Log10(0.0001f) * 20);
            }
        }
    }
}
