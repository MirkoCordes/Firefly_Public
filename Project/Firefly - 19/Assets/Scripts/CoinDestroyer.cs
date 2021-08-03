using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroyer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Raindrop" || collision.gameObject.tag == "Hornet")
        {
            //Destroy(collision.gameObject);
        }
    }
}
