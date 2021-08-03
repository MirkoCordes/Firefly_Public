using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBlueBackSpawner : MonoBehaviour
{
    public GameObject BlueBackground;
    public float spawnTime;
    public float spawnDelay;
    private float deleteDelay = 27f;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    public void SetClouds()
    {
        Instantiate(BlueBackground, transform.position, transform.rotation);
        Destroy(GameObject.Find("BlueBackground(Clone)"), deleteDelay);
        
    }

    public void StopSpawning()
    {
        CancelInvoke("SetClouds");
        Destroy(GameObject.Find("BlueBackground(Clone)"));
    }

    public void StartSpawning()
    {
        InvokeRepeating("SetClouds", spawnTime, spawnDelay + deleteDelay);
    }
}
