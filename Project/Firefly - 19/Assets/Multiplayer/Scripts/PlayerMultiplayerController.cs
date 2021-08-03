using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMultiplayerController : Photon.MonoBehaviour
{
    Joystick joystick;
    private float speed = 100f;
    private float h;
    private float v;
    public GameObject body;
    public GameObject body2;
    Vector2 dir;
    private DieController dieController;

    void Start()
    {
        joystick = Joystick.FindObjectOfType<Joystick>();
        dieController = DieController.FindObjectOfType<DieController>();
        Input.multiTouchEnabled = false;
        speed = 230 - (PhotonNetwork.playerList.Length * 10);
    }

    void Update()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            h = joystick.Horizontal;
            v = joystick.Vertical;
        } else if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            v = Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");
        }

       
        dir = new Vector2(h, v);

        GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;

        float angle = Mathf.Atan2(h, v) * -Mathf.Rad2Deg;
        body.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        body2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));




        /*
        h = joystick.Horizontal;
            v = joystick.Vertical;
        
            dir = new Vector2(h, v);

            GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;

            float angle = Mathf.Atan2(h, v) * -Mathf.Rad2Deg;
            body.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    */
    }
}
