using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetMovement : MonoBehaviour
{
    public float speed = 1200;
    public float v = -500f;
    public float h = 0f;
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void FixedUpdate()
    {
        Vector2 dir = new Vector2(v, h);
        transform.Translate(dir * speed * Time.deltaTime);
        //transform.position = new Vector2(transform.position.x - (Time.time * speed), transform.position.y); 
        //GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;

        if(transform.position.x < -screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GPs")
        {
            Destroy(gameObject);
        }
    }
}
