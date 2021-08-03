using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarnerLocateController : Photon.MonoBehaviour
{
    private bool handActive;
    private bool isHand;
    private LocationNetwork locationNetwork;

    public GameObject handGaOb;
    public GameObject warnerLeft;
    private Image imgLeft;
    public GameObject warnerDown;
    private Image imgDown;
    private Transform target;
    private Camera userCamera;

    // Start is called before the first frame update
    void Start()
    {
        locationNetwork = LocationNetwork.FindObjectOfType<LocationNetwork>();

        userCamera = gameObject.GetComponent<Camera>();
        //für linken Indikator
        imgLeft = warnerLeft.GetComponent<Image>();

        //für unteren Indikator
        imgDown = warnerDown.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        handActive = locationNetwork.ReturnHandActive();
        isHand = locationNetwork.ReturnIsHand();

        //spielerposition - Enemyobjekt = direction
        if (handActive && photonView.isMine)
        {
            handGaOb.SetActive(true);
            //für hand
            if(isHand)
            {
                target = GameObject.Find("Hand(Clone)").transform;
            } else
            {
                target = GameObject.Find("Swatter(Clone)").transform;
            }

            //für unteren indikator
            float minYDown = imgDown.GetPixelAdjustedRect().height;
            float minXDown = imgDown.GetPixelAdjustedRect().width / 2;
            float maxXDown = Screen.width - minXDown;

            //für linken indikator
            float minXLeft = imgLeft.GetPixelAdjustedRect().width;
            float minYLeft = imgLeft.GetPixelAdjustedRect().height / 2;
            float maxYLeft = Screen.height - minYLeft;

            Vector2 posLeft = userCamera.WorldToScreenPoint(target.position);
            Vector2 posDown = userCamera.WorldToScreenPoint(target.position);

            posLeft.x = minXLeft;
            posDown.y = minYDown;

            //für linken indikator
            posLeft.y = Mathf.Clamp(posLeft.y, minYLeft, maxYLeft);
            //für unteren indikator
            posDown.x = Mathf.Clamp(posDown.x, minXDown, maxXDown);

            imgLeft.transform.position = posLeft;
            imgDown.transform.position = posDown;
        } else
        {
            handGaOb.SetActive(false);
        }
    }
}
