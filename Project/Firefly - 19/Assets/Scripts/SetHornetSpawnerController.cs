using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHornetSpawnerController : MonoBehaviour
{
    public GameObject HornetSpawnerUI;
    public GameObject Spawnpoint;
    public float spawnTime;
    public float spawnDelay;
    private float deleteDelay = 27f;

    PlayerCollision playercollision;
    bool gameIsRunning;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
        playercollision = GameObject.FindObjectOfType<PlayerCollision>();
        gameIsRunning = playercollision.gameIsRunning;
    }

    void Update()
    {
        
    }

    public void SetSpawner()
    {
        GameObject g = (GameObject)Instantiate(HornetSpawnerUI, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        g.transform.SetParent(Spawnpoint.transform, false);

        Destroy(GameObject.Find("HornetSpawner(Clone)"), spawnDelay);
        
    }

    public void StopSpawning()
    {
        CancelInvoke("SetSpawner");
        Destroy(GameObject.Find("HornetSpawner(Clone)"));
    }

    public void StartSpawning()
    {
        InvokeRepeating("SetSpawner", spawnTime, spawnDelay + deleteDelay);
    }
}
