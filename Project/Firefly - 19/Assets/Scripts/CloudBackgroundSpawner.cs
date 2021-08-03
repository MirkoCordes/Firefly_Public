using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBackgroundSpawner : MonoBehaviour
{
    public GameObject Background;
    public float spawnTime;
    public float spawnDelay;
    private float deleteDelay = 27f;
    GameObject back;
    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    public void SetClouds()
    {
        back = (GameObject)Instantiate(Background, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        back.transform.SetParent(spawnPoint.transform, false);
        Destroy(GameObject.Find("back(Clone)"), deleteDelay);
        
    }

    public void StopSpawning()
    {
        CancelInvoke("SetClouds");
        Destroy(GameObject.Find("back(Clone)"));
    }

    public void StartSpawning()
    {
        InvokeRepeating("SetClouds", spawnTime, spawnDelay + deleteDelay);
    }
}
