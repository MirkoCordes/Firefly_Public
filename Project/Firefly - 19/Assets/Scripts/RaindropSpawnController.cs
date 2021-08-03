using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaindropSpawnController : MonoBehaviour
{
    public GameObject Raindrop;
    public GameObject Snowflake;
    public float interval;
    Inventory myInventory;

    // Start is called before the first frame update
    void Start()
    {
        myInventory = Inventory.FindObjectOfType<Inventory>();
        InvokeRepeating("spawn", interval, interval);
    }

    void spawn()
    {
        float v = Random.value;

        if (v < .40)
        {
            if (myInventory.GetStandardBackground())
            {
                GameObject g = (GameObject)Instantiate(Raindrop, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                g.transform.SetParent(this.transform, false);
            }
            else
            {
                GameObject g = (GameObject)Instantiate(Snowflake, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                g.transform.SetParent(this.transform, false);
            }
        }
    }
}
