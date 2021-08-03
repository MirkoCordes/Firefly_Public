using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetDestroyer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hornet")
        {
            Destroy(collision.gameObject);
        }
    }
}
