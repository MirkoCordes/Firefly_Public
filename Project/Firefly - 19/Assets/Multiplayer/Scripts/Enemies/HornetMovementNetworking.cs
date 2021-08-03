using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HornetMovementNetworking : Photon.MonoBehaviour
{
    public float speed = 110;
    public float v = -500f;
    public float h = 0f;

    private PhotonView PhotonView;

    private void Awake()
    {
        PhotonView = GetComponent<PhotonView>();
    }



    void FixedUpdate()
    {
        //if (PhotonView.isMine)
        //{
            Vector2 dir = new Vector2(v, h);
            GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;
        //}
    }
}
