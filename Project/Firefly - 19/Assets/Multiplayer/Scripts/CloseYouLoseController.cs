using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseYouLoseController : MonoBehaviour
{
    public GameObject CloseButton;
    private GameObject YouLoseInformation;

    private void Start()
    {
        YouLoseInformation = gameObject;
    }

    public void OnClickCloseYouLoseInformation()
    {
        YouLoseInformation.SetActive(false);
    }
}
