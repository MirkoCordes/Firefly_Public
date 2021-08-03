using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clapSpawnerController : MonoBehaviour
{
    public GameObject FlySwatt;
    public GameObject Spawnpoint;
    public GameObject Player;
    public float spawnTime;
    public float spawnDelay;
    private float deleteDelay = 20f;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    public void SetSpawner()
    {
        GameObject g = (GameObject)Instantiate(FlySwatt, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        g.transform.SetParent(Spawnpoint.transform, false);

        Destroy(GameObject.Find("Flyingclap_0(Clone)"), spawnDelay);

        
    }

    public void StopSpawning()
    {
        CancelInvoke("SetSpawner");
        Destroy(GameObject.Find("Flyingclap_0(Clone)"));
    }

    public void StartSpawning()
    {
        InvokeRepeating("SetSpawner", spawnTime, spawnDelay + deleteDelay);
    }
}
