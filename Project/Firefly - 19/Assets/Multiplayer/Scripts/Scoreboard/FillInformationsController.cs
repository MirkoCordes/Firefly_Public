using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillInformationsController : MonoBehaviour
{
    public Text NameText;
    public Text PointsText;
    public int placeNumber;

    public string Name;
    public string points; //ehemalig int tostring

    private void Update()
    {
        PointsText.text = points;
        NameText.text = Name;
    }

}
