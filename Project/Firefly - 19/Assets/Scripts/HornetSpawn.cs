using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetSpawn : MonoBehaviour
{
    public GameObject Enemie;
    public GameObject Spawnpoint;
    public float interval = 2f;
    public bool spawnH = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawn", interval, interval);
    }

    public void spawn()
    {
        float v = Random.value;

        if (v < .35)
        {
            GameObject g = (GameObject)Instantiate(Enemie, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

            g.transform.SetParent(Spawnpoint.transform, false);
            spawnH = true;
        }
    }
}
