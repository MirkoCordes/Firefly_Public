using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] public Vector2 parallaxEffectMultiplier;
    private Transform playerTransform;
    private Vector3 lastPlayerPosition;
    public GameObject player;
    


    void Start()
    {
        player = GameObject.Find("Player");
            playerTransform = player.transform;
            lastPlayerPosition = playerTransform.position;
    }

    
    // Update is called once per frame
    void LateUpdate()
    {
            Vector3 deltaMovement = playerTransform.position - lastPlayerPosition;
            transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
            lastPlayerPosition = playerTransform.position;
    }
}
