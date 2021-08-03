using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Joystick joystick;
    public float speed = 10f;
    public float h;
    public float v;
    Vector2 dir;
    public PlayerCollision playerCollision;

    void Start()
    {
        joystick = Joystick.FindObjectOfType<Joystick>();
        Input.multiTouchEnabled = false;
    }

    void FixedUpdate()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            h = joystick.Horizontal;
            v = joystick.Vertical;
        }
        else if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            v = Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");
        }


        if (playerCollision.GetRunningGameAsk())
        {
            dir = new Vector2(h, v);
            
        } else
        {
            dir = new Vector2(0, 0);
        }

        GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;

        float angle = Mathf.Atan2(h, v) * -Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }
  
}
