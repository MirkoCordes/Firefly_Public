using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudSpawner : MonoBehaviour
{
    public GameObject Clouds;
    public float spawnTime;
    public float spawnDelay;
    private float deleteDelay = 27f;
    GameObject clou;
    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }
   
    public void SetClouds()
    {
        clou = (GameObject)Instantiate(Clouds, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        clou.transform.SetParent(spawnPoint.transform, false);

        Destroy(GameObject.Find("DarkCloud1(Clone)"), deleteDelay);
        Destroy(GameObject.Find("DarkCloud2(Clone)"), deleteDelay);
        Destroy(GameObject.Find("DarkCloud3(Clone)"), deleteDelay);
        
    }

    public void StopSpawning()
    {
        CancelInvoke("SetClouds");
        Destroy(GameObject.Find("DarkCloud1(Clone)"));
        Destroy(GameObject.Find("DarkCloud2(Clone)"));
        Destroy(GameObject.Find("DarkCloud3(Clone)"));
    }

    public void StartSpawning()
    {
        InvokeRepeating("SetClouds", spawnTime, spawnDelay + deleteDelay);
    }

}
