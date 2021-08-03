using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenClose : MonoBehaviour
{
    public AudioSource horn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CloseStartScreen());
    }

    IEnumerator CloseStartScreen()
    {
        yield return new WaitForSeconds(2.5f);
        horn.Play();
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}