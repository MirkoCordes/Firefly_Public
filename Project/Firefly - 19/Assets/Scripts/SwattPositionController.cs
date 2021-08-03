using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwattPositionController : MonoBehaviour
{
    private GameObject player;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector3(-691f, player.transform.position.y - 318f, 236);
        transform.position = pos;
    }
}
