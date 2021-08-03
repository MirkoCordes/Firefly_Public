using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject normalChar;
    public GameObject redChar;
    public GameObject pinkChar;
    public GameObject yellowChar;
    public GameObject blueChar;
    
    public GameObject Summerbackground;
    public GameObject Winterbackground;

    Inventory myInventory;
    GameObject cha;
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        myInventory = Inventory.FindObjectOfType<Inventory>();

        //Für Charakterauswahl
        if (myInventory.GetRedChar() || PlayerPrefs.GetInt("redCharacterBuyedActivated") == 1)
        {
            cha = (GameObject)Instantiate(redChar, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        } else if (myInventory.GetPinkChar() || PlayerPrefs.GetInt("pinkCharacterBuyedActivated") == 1)
        {
            cha = (GameObject)Instantiate(pinkChar, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        } else if (myInventory.GetYellowChar() || PlayerPrefs.GetInt("yellowCharacterBuyedActivated") == 1)
        {
            cha = (GameObject)Instantiate(yellowChar, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        } else if (myInventory.GetBlueChar() || PlayerPrefs.GetInt("blueCharacterBuyedActivated") == 1)
        {
            cha = (GameObject)Instantiate(blueChar, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        } else if(myInventory.GetNormalChar() || PlayerPrefs.GetInt("normalCharacterActivated") == 1)
        {
            cha = (GameObject)Instantiate(normalChar, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        }

        cha.transform.SetParent(playerObject.transform, false);

        //Für richtigen Hintergrund
        if (myInventory.GetStandardBackground())
        {
            GameObject bgrnd = (GameObject)Instantiate(Summerbackground, new Vector3(0, 0, -10), Quaternion.identity) as GameObject;
        }
        else
        {
            GameObject bgrnd = (GameObject)Instantiate(Winterbackground, new Vector3(0, 0, -10), Quaternion.identity) as GameObject;
        }
    }
}
