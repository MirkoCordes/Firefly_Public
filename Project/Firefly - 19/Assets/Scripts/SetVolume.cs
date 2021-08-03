using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public string mixerName;
    public string mutedName;
    public Toggle toggleSound;
    public Image checkImage;

    public void Start()
    {
        if (!PlayerPrefs.HasKey(mutedName))
        {
            PlayerPrefs.SetInt(mutedName, 0);
            checkImage.enabled = true;
        }

        if (PlayerPrefs.GetInt(mutedName) == 1)
        {
            checkImage.enabled = false;
            mixer.SetFloat(mixerName, Mathf.Log10(0.0001f) * 20);
        }
    }

    public void MuteSound()
    {
        //if bedingung ob enabled 
        if (PlayerPrefs.GetInt(mutedName) == 0)
        {
            mixer.SetFloat(mixerName, Mathf.Log10(0.0001f) * 20);
            PlayerPrefs.SetInt(mutedName, 1);
        }
        else if (PlayerPrefs.GetInt(mutedName) == 1)
        {
            checkImage.enabled = true;
            toggleSound.GetComponent<Toggle>().isOn = true;
            mixer.SetFloat(mixerName, Mathf.Log10(1f) * 20);
            PlayerPrefs.SetInt(mutedName, 0);
        }
        
    }
}