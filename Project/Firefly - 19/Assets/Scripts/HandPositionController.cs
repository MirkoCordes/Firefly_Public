using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPositionController : MonoBehaviour
{
    private GameObject player;
    private Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector3(player.transform.position.x + 836f, player.transform.position.y + 297f, -699.6f);
    }

    public void SetPosition()
    {
        transform.position = pos;
    }
}
