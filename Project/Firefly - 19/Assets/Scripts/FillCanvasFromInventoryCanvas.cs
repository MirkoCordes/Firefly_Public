using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillCanvasFromInventoryCanvas : MonoBehaviour
{
    Inventory myInventory;
    public int health;
    public int slowStart;

    //Objects from Canvas
    public Text lifesText;
    public Text highScore;
    public Text tempCoinsText;
    public Text tempCoinsText2;

    // Start is called before the first frame update
    void Start()
    {
        myInventory = GameObject.FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        health = myInventory.health;
        slowStart = myInventory.slowDownStart;
        lifesText.text = health.ToString();
        tempCoinsText.text = myInventory.coinsInGame.ToString();
        tempCoinsText2.text = myInventory.coinsInGame.ToString();
    }
}
