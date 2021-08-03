using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSpawner : MonoBehaviour
{
    public GameObject LightObstacle;
    public float invokeTime;
    public float invokeDelay;
    private float randNum;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SetPoints", invokeTime, invokeDelay);
    }

    public void SetPoints()
    {
        randNum = Random.Range(0.0f, 1.0f);
        if (randNum < 0.1f)
        {
            if (transform.childCount == 0)
            {
                GameObject g = (GameObject)Instantiate(LightObstacle, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                g.transform.SetParent(gameObject.transform, false);
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Update Inventory-GP´s
        }
    }
}