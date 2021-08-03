using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HornetWarner : MonoBehaviour
{
    public GameObject WarnerUI1;
    public GameObject WarnerUI2;
    public GameObject WarnerUI4;
    public GameObject WarnerUI6;

    // Start is called before the first frame update
    void Start()
    {
        WarnerUI1.SetActive(false);
        WarnerUI2.SetActive(false);
        WarnerUI4.SetActive(false);
        WarnerUI6.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("HornetEnemie 1(Clone)"))
        {
            WarnerUI1.SetActive(true);
        } else
        {
            WarnerUI1.SetActive(false);
        }

        if (GameObject.Find("HornetEnemie 2(Clone)"))
        {
            WarnerUI2.SetActive(true);
        }
        else
        {
            WarnerUI2.SetActive(false);
        }

        if (GameObject.Find("HornetEnemie 4(Clone)"))
        {
            WarnerUI4.SetActive(true);
        }
        else
        {
            WarnerUI4.SetActive(false);
        }

        if (GameObject.Find("HornetEnemie 6(Clone)"))
        {
            WarnerUI6.SetActive(true);
        }
        else
        {
            WarnerUI6.SetActive(false);

        }


        
    }
    

   
}
