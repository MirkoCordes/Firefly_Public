using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 10;
    public Joystick joystick;

    void FixedUpdate()
    {
        float h = joystick.Horizontal;
        float v = joystick.Vertical;

        Vector2 dir = new Vector2(h, v);

        GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;

    }

}
