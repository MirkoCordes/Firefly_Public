using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorCameraWarner : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public Camera targetCamera;
    private LocationNetwork locationNetwork;
    private bool handActive;

    // Start is called before the first frame update
    void Start()
    {

        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        locationNetwork = LocationNetwork.FindObjectOfType<LocationNetwork>();

        
    }

    // Update is called once per frame
    void Update()
    {
        screenBounds = targetCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 - objectWidth, screenBounds.x - objectWidth);


        handActive = locationNetwork.ReturnHandActive();
        if (handActive)
        {
            viewPos.y = GameObject.Find("Hand(Clone)").transform.position.y - gameObject.transform.position.y;

            viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1, screenBounds.y);

        }

        viewPos.z = 80;
        transform.position = viewPos;
    }
}
