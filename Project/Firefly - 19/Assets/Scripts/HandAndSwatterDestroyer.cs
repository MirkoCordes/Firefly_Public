using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAndSwatterDestroyer : Photon.MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Raindrop" || collision.gameObject.tag == "Hornet")
        {
            Destroy(collision.gameObject);
        }
    }
}
