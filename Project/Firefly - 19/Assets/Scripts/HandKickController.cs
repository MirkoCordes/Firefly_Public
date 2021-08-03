using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandKickController : MonoBehaviour
{
    public GameObject Hand;
    public GameObject Spawnpoint;
    public GameObject Player;
    public float spawnTime;
    public float spawnDelay;
    private float deleteDelay = 20f;
    private GameObject player;
    private Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartSpawning();
    }

    public void SetSpawner()
    {
        transform.position = pos;
        GameObject g = (GameObject)Instantiate(Hand, new Vector3(0, 0, 355), Quaternion.identity) as GameObject;
        g.transform.SetParent(Spawnpoint.transform, false);

        Destroy(GameObject.Find("Hand_0(Clone)"), spawnDelay);

        
    }

    public void StopSpawning()
    {
        CancelInvoke("SetSpawner");
        Destroy(GameObject.Find("Hand_0(Clone)"));
    }

    private void Update()
    {
        pos = new Vector2(player.transform.position.x - 470f, player.transform.position.y - 270f);
    }

    public void StartSpawning()
    {
        InvokeRepeating("SetSpawner", spawnTime, spawnDelay + deleteDelay);
    }
}
