using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropCollider : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hornet" || collision.gameObject.tag == "GPs")
        {
            Destroy(collision.gameObject);
        }

    }
}
