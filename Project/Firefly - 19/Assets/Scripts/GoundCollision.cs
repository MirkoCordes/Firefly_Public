using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoundCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Raindrop")
        {
            Destroy(collision.gameObject);
        }

    }
}
