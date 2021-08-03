using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartItems : MonoBehaviour
{
    Inventory myInventory;
    int slowStart;
    public GameObject slowDownButton;

    public GameObject protectiveShield;
    GameObject proShield;
    public GameObject playerObject;

    GameObject ActivadeProtection;
    public ParticleSystem SlowStartParticles;

    void Start()
    {
        myInventory = GameObject.FindObjectOfType<Inventory>();
        slowStart = myInventory.slowDownStart;

        
        if (slowStart >= 1)
        {
            //Button anzeigen
            slowDownButton.SetActive(true);
        } else
        {
            //Button ausblenden
            slowDownButton.SetActive(false);
        }
    }

    public void StartSlow()
    {
        //Button ausblenden
        slowDownButton.SetActive(false);

        SlowStartParticles.Play();
        Time.timeScale = 0.4f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;

        playerObject.GetComponent<PlayerMovement>().speed = 1440f;
        
        //1 SlowDown abziehen
        myInventory.MinimizeSlowDownStart();
        Invoke("EndOfSlowStart", 5f);
    }

    void EndOfSlowStart()
    {
        playerObject.GetComponent<PlayerMovement>().speed = 900f;
        Time.timeScale = 1f;
    }


    void LateUpdate()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).tapCount == 2 && myInventory.protective >= 1)
            {
                switch (Input.GetTouch(0).phase)
                {
                    case TouchPhase.Ended:
                        SlowStartParticles.Play();
                        proShield = (GameObject)Instantiate(protectiveShield, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        proShield.transform.SetParent(playerObject.transform, false);
                        myInventory.MinimizeProtectiveShield();
                        ActivadeProtection = GameObject.FindGameObjectWithTag("Shield");
                        break;
                }
                
            }
        }
    }
}
