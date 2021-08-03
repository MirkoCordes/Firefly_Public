using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHand : MonoBehaviour
{
    private SpawnEnemiesOnClick spawnEnemiesOnClick;

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemiesOnClick = SpawnEnemiesOnClick.FindObjectOfType<SpawnEnemiesOnClick>();
        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(3f);
        PhotonNetwork.Destroy(gameObject);
    }
}
