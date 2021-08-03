using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OnClickFillAmountAnimationController : MonoBehaviour
{
    public Image[] Buttons;
    public GameObject dontTouchOverlay;
    float wait;

    bool isFilling;

    public void StartAnimation(float waitTime)
    {
        for (int i = 0; i <= 8; i++)
        {
            Buttons[i].fillAmount = 0f;
        }

        dontTouchOverlay.SetActive(true);
        StartCoroutine(CloseExtraOverlay(waitTime));
        wait = waitTime;

        isFilling = true;
        
    }

    public void Update()
    {
        if (isFilling)
        {
            for (int i = 0; i <= 8; i++)
            {
                Buttons[i].fillAmount += 1.0f / wait * Time.deltaTime;
            }
        }
        
    }

    IEnumerator CloseExtraOverlay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        dontTouchOverlay.SetActive(false);
    }
}
