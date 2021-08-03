using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRain : MonoBehaviour
{
    private SpawnEnemiesOnClick spawnEnemiesOnClick;

    private void Start()
    {
        spawnEnemiesOnClick = SpawnEnemiesOnClick.FindObjectOfType<SpawnEnemiesOnClick>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player")
        {
            PhotonNetwork.Destroy(gameObject);
        }
        
    }
}
