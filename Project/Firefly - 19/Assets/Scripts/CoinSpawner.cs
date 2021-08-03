using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    public float invokeTime;
    public float invokeDelay;
    private float randNum;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    public void SetPoints()
    {
        randNum = Random.Range(0.0f, 1.0f);
        if (randNum < 0.1f)
        {
            if (transform.childCount == 0)
            {
                GameObject g = (GameObject)Instantiate(CoinPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                g.transform.SetParent(gameObject.transform, false);
            }
        }
        
    }

    public void StopSpawning()
    {
        CancelInvoke("SetSpawner");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Update Inventory-Coin´s
        }
    }

    public void StartSpawning()
    {
        InvokeRepeating("SetPoints", invokeTime, invokeDelay);
    }
}
