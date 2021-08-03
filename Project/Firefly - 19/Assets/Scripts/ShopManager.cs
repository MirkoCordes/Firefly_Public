using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    int kontostandCoins;
    public Text kontostandCoinsText;

    public Text slowDownText;
    public Text protectionText;
    public Text healthText;

    Inventory myInventory;

    GameObject normalCharButton;
    GameObject redCharButton;
    GameObject pinkCharButton;
    GameObject yellowCharButton;
    GameObject blueCharButton;

    GameObject normalActivateButton;
    GameObject redActivateButton;
    GameObject pinkActivateButton;
    GameObject yellowActivateButton;
    GameObject blueActivateButton;

    public Text normalActivateText;
    public Text redActivateText;
    public Text pinkActivateText;
    public Text yellowActivateText;
    public Text blueActivateText;

    public Button[] interactiveButtons;
    public Button[] interactiveSkinButtons;

    int i;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        myInventory = GameObject.FindObjectOfType<Inventory>();
        myInventory.LoadInventory();
    }

    void Update()
    {
        kontostandCoins = myInventory.kontostandCoins;

        if (GameObject.Find("Shopmenu"))
        {
            KontostandCoinsAktualisieren();

            healthText.text = myInventory.health.ToString();
            protectionText.text = myInventory.protective.ToString();
            slowDownText.text = myInventory.slowDownStart.ToString();

            normalCharButton = GameObject.Find("NormalXpCosts");
            redCharButton = GameObject.Find("RedXpCosts");
            pinkCharButton = GameObject.Find("PinkXpCosts");
            yellowCharButton = GameObject.Find("YellowXpCosts");
            blueCharButton = GameObject.Find("BlueXpCosts");

            normalActivateButton = GameObject.Find("NormalActivateButton");
            redActivateButton = GameObject.Find("RedActivateButton");
            pinkActivateButton = GameObject.Find("PinkActivateButton");
            yellowActivateButton = GameObject.Find("YellowActivateButton");
            blueActivateButton = GameObject.Find("BlueActivateButton");

            while (i < 1)
            {
                LoadShop();
                i++;
            }

            for (int i = 0; i < 4; i++)
            {
                if ((i == 0 && kontostandCoins < 50) || (i == 1 && kontostandCoins < 75) || (i == 2 && kontostandCoins < 175) || (i==3 && kontostandCoins < 200))
                {
                    interactiveButtons[i].interactable = false;
                }
                else
                {
                    interactiveButtons[i].interactable = true;
                }

            }

            for (int i = 0; i<4; i++)
            {
                if ((i == 0 && kontostandCoins < 250) || (i == 1 && kontostandCoins < 800) || (i == 2 && kontostandCoins < 1700) || (i == 3 && kontostandCoins < 2250))
                {
                    interactiveSkinButtons[i].interactable = false;
                }
                else
                {
                    interactiveSkinButtons[i].interactable = true;
                }
            }

            if (PlayerPrefs.HasKey("theme"))
            {
                if (PlayerPrefs.HasKey("snowthemebuyed") && PlayerPrefs.GetInt("snowthemebuyed") == 1)
                {
                    //Button deaktivieren
                    if (themeCostButton[0].activeSelf)
                    {
                        themeCostButton[0].SetActive(false);
                    }
                }
                changeTheme(PlayerPrefs.GetInt("theme"));
            }
            else if (myInventory.GetStandardBackground())
            {
                changeTheme(0);
            }

        }
        
    }


    public void LoadShop()
    {
        normalActivateButton.SetActive(true);
        normalActivateText.text = "ACTIVATED";
        redActivateText.text = "activate";
        pinkActivateText.text = "activate";
        yellowActivateText.text = "activate";
        blueActivateText.text = "activate";

        if (PlayerPrefs.HasKey("redCharacterBuyed"))
        {
            redCharButton.SetActive(false);
            redActivateButton.SetActive(true);
        }
        if (PlayerPrefs.HasKey("pinkCharacterBuyed"))
        {
            pinkCharButton.SetActive(false);
            pinkActivateButton.SetActive(true);
        }
        if (PlayerPrefs.HasKey("yellowCharacterBuyed"))
        {
            yellowCharButton.SetActive(false);
            yellowActivateButton.SetActive(true);
        }
        if (PlayerPrefs.HasKey("blueCharacterBuyed"))
        {
            blueCharButton.SetActive(false);
            blueActivateButton.SetActive(true);
        }


        if (PlayerPrefs.HasKey("normalCharacterActivated"))
        {
            int activateNormChar = PlayerPrefs.GetInt("normalCharacterActivated");
            int activateRedChar = PlayerPrefs.GetInt("redCharacterBuyedActivated");
            int activatePinkChar = PlayerPrefs.GetInt("pinkCharacterBuyedActivated");
            int activateYellowChar = PlayerPrefs.GetInt("yellowCharacterBuyedActivated");
            int activateBlueChar = PlayerPrefs.GetInt("blueCharacterBuyedActivated");

            if (activateNormChar == 1)
            {
                normalActivateText.text = "ACTIVATED";
                redActivateText.text = "activate";
                pinkActivateText.text = "activate";
                yellowActivateText.text = "activate";
                blueActivateText.text = "activate";

                normalActivateButton.GetComponent<Button>().interactable = false;
                redActivateButton.GetComponent<Button>().interactable = true;
                pinkActivateButton.GetComponent<Button>().interactable = true;
                yellowActivateButton.GetComponent<Button>().interactable = true;
                blueActivateButton.GetComponent<Button>().interactable = true;
            }
            else if (activateRedChar == 1)
            {
                normalActivateText.text = "activate";
                redActivateText.text = "ACTIVATED";
                pinkActivateText.text = "activate";
                yellowActivateText.text = "activate";
                blueActivateText.text = "activate";

                normalActivateButton.GetComponent<Button>().interactable = true;
                redActivateButton.GetComponent<Button>().interactable = false;
                pinkActivateButton.GetComponent<Button>().interactable = true;
                yellowActivateButton.GetComponent<Button>().interactable = true;
                blueActivateButton.GetComponent<Button>().interactable = true;
            }
            else if (activatePinkChar == 1)
            {
                normalActivateText.text = "activate";
                redActivateText.text = "activate";
                pinkActivateText.text = "ACTIVATED";
                yellowActivateText.text = "activate";
                blueActivateText.text = "activate";

                normalActivateButton.GetComponent<Button>().interactable = true;
                redActivateButton.GetComponent<Button>().interactable = true;
                pinkActivateButton.GetComponent<Button>().interactable = false;
                yellowActivateButton.GetComponent<Button>().interactable = true;
                blueActivateButton.GetComponent<Button>().interactable = true;
            }
            else if (activateYellowChar == 1)
            {
                normalActivateText.text = "activate";
                redActivateText.text = "activate";
                pinkActivateText.text = "activate";
                yellowActivateText.text = "ACTIVATED";
                blueActivateText.text = "activate";

                normalActivateButton.GetComponent<Button>().interactable = true;
                redActivateButton.GetComponent<Button>().interactable = true;
                pinkActivateButton.GetComponent<Button>().interactable = true;
                yellowActivateButton.GetComponent<Button>().interactable = false;
                blueActivateButton.GetComponent<Button>().interactable = true;
            }
            else if (activateBlueChar == 1)
            {
                normalActivateText.text = "activate";
                redActivateText.text = "activate";
                pinkActivateText.text = "activate";
                yellowActivateText.text = "activate";
                blueActivateText.text = "ACTIVATED";

                normalActivateButton.GetComponent<Button>().interactable = true;
                redActivateButton.GetComponent<Button>().interactable = true;
                pinkActivateButton.GetComponent<Button>().interactable = true;
                yellowActivateButton.GetComponent<Button>().interactable = true;
                blueActivateButton.GetComponent<Button>().interactable = false;
            }
        }
    }



    public void SlowDownStartKaufen(int itemPreis)
    {
        // Kontostand Überprüfen
        if(kontostandCoins >= itemPreis)
        {
            //Item zum Inventar hinzufügen
            myInventory.ChangeSlowDownStart(1);

            //Kontostand neu berechnen
            myInventory.KontostandCoinsErrechnen(itemPreis);
            //Kontostand aktualisieren
            KontostandCoinsAktualisieren();
            //Save Inventory
            myInventory.SaveInventoryForSlowDown();
        }
    }

    public void ProtectionKaufen(int itemPreis)
    {
        // Kontostand Überprüfen
        if (kontostandCoins >= itemPreis)
        {
            //Item zum Inventar hinzufügen
            myInventory.ChangeProtective(1);

            //Kontostand neu berechnen
            myInventory.KontostandCoinsErrechnen(itemPreis);
            //Kontostand aktualisieren
            KontostandCoinsAktualisieren();
            //Save Inventory
            myInventory.SaveInventoryForProtection();
        }
    }

    public void HealthKaufen(int itemPreis)
    {
        // Kontostand Überprüfen
        if (kontostandCoins >= itemPreis)
        {
            //Item zum Inventar hinzufügen
            myInventory.ChangeHealth(1);

            //Kontostand neu berechnen
            myInventory.KontostandCoinsErrechnen(itemPreis);
            //Kontostand aktualisieren
            KontostandCoinsAktualisieren();
            //Save Inventory
            myInventory.SaveInventoryForHealth();
        }
    }

    public void NormalBodyKaufen(int itemPreis)
    {
        // Kontostand Überprüfen
        if (kontostandCoins >= itemPreis)
        {
            //Char im Inventar aktivieren
            myInventory.ActivateNormalChar();
            //Kontostand neu berechnen
            myInventory.KontostandCoinsErrechnen(itemPreis);
            //Kontostand aktualisieren
            KontostandCoinsAktualisieren();
            // Einkauf abspeichern
            myInventory.SaveInventoryForNormalChar();
            //Button deaktivieren
            if (normalCharButton)
            {
                normalCharButton.SetActive(false);
            }
            normalActivateButton.SetActive(true);
            normalActivateButton.GetComponent<Button>().interactable = false;
            redActivateButton.GetComponent<Button>().interactable = true;
            pinkActivateButton.GetComponent<Button>().interactable = true;
            yellowActivateButton.GetComponent<Button>().interactable = true;
            blueActivateButton.GetComponent<Button>().interactable = true;

            normalActivateText.text = "ACTIVATED";
            redActivateText.text = "activate";
            pinkActivateText.text = "activate";
            yellowActivateText.text = "activate";
            blueActivateText.text = "activate";
        }
    }
    public void RedBodyKaufen(int itemPreis)
    {
        // Kontostand Überprüfen
        if (kontostandCoins >= itemPreis)
        {
            //Char im Inventar aktivieren
            myInventory.ActivateRedChar();
            //Kontostand neu berechnen
            myInventory.KontostandCoinsErrechnen(itemPreis);
            //Kontostand aktualisieren
            KontostandCoinsAktualisieren();
            // Einkauf abspeichern
            myInventory.SaveInventoryForRedChar();

            //Button deaktivieren
            if (redCharButton)
            {
                redCharButton.SetActive(false);
            }
            redActivateButton.SetActive(true);
            normalActivateButton.GetComponent<Button>().interactable = true;
            redActivateButton.GetComponent<Button>().interactable = false;
            pinkActivateButton.GetComponent<Button>().interactable = true;
            yellowActivateButton.GetComponent<Button>().interactable = true;
            blueActivateButton.GetComponent<Button>().interactable = true;

            normalActivateText.text = "activate";
            redActivateText.text = "ACTIVATED";
            pinkActivateText.text = "activate";
            yellowActivateText.text = "activate";
            blueActivateText.text = "activate";
        }
    }
    public void PinkBodyKaufen(int itemPreis)
    {
        // Kontostand Überprüfen
        if (kontostandCoins >= itemPreis)
        {
            //Char im Inventar aktivieren
            myInventory.ActivadePinkChar();
            //Kontostand neu berechnen
            myInventory.KontostandCoinsErrechnen(itemPreis);
            //Kontostand aktualisieren
            KontostandCoinsAktualisieren();
            // Einkauf abspeichern
            myInventory.SaveInventoryForPinkChar();

            //Button deaktivieren
            if (pinkCharButton)
            {
                pinkCharButton.SetActive(false);
            }
            pinkActivateButton.SetActive(true);
            normalActivateButton.GetComponent<Button>().interactable = true;
            redActivateButton.GetComponent<Button>().interactable = true;
            pinkActivateButton.GetComponent<Button>().interactable = false;
            yellowActivateButton.GetComponent<Button>().interactable = true;
            blueActivateButton.GetComponent<Button>().interactable = true;

            normalActivateText.text = "activate";
            redActivateText.text = "activate";
            pinkActivateText.text = "ACTIVATED";
            yellowActivateText.text = "activate";
            blueActivateText.text = "activate";
        }
    }
    public void YellowBodyKaufen(int itemPreis)
    {
        // Kontostand Überprüfen
        if (kontostandCoins >= itemPreis)
        {
            //Char im Inventar aktivieren
            myInventory.ActivadeYellowChar();
            //Kontostand neu berechnen
            myInventory.KontostandCoinsErrechnen(itemPreis);
            //Kontostand aktualisieren
            KontostandCoinsAktualisieren();
            // Einkauf abspeichern
            myInventory.SaveInventoryForYellowChar();

            //Button deaktivieren
            if (yellowCharButton)
            {
                yellowCharButton.SetActive(false);
            }
            yellowActivateButton.SetActive(true);
            normalActivateButton.GetComponent<Button>().interactable = true;
            redActivateButton.GetComponent<Button>().interactable = true;
            pinkActivateButton.GetComponent<Button>().interactable = true;
            yellowActivateButton.GetComponent<Button>().interactable = false;
            blueActivateButton.GetComponent<Button>().interactable = true;

            normalActivateText.text = "activate";
            redActivateText.text = "activate";
            pinkActivateText.text = "activate";
            yellowActivateText.text = "ACTIVATED";
            blueActivateText.text = "activate";
        }
    }
    public void BlueBodyKaufen(int itemPreis)
    {
        // Kontostand Überprüfen
        if (kontostandCoins >= itemPreis)
        {
            //Char im Inventar aktivieren
            myInventory.ActivadeBlueChar();
            //Kontostand neu berechnen
            myInventory.KontostandCoinsErrechnen(itemPreis);
            //Kontostand aktualisieren
            KontostandCoinsAktualisieren();
            // Einkauf abspeichern
            myInventory.SaveInventoryForBlueChar();

            //Button deaktivieren
            if (blueCharButton)
            {
                blueCharButton.SetActive(false);
            }
            blueActivateButton.SetActive(true);
            normalActivateButton.GetComponent<Button>().interactable = true;
            redActivateButton.GetComponent<Button>().interactable = true;
            pinkActivateButton.GetComponent<Button>().interactable = true;
            yellowActivateButton.GetComponent<Button>().interactable = true;
            blueActivateButton.GetComponent<Button>().interactable = false;

            normalActivateText.text = "activate";
            redActivateText.text = "activate";
            pinkActivateText.text = "activate";
            yellowActivateText.text = "activate";
            blueActivateText.text = "ACTIVATED";
        }
    }

    public GameObject[] themeCostButton;
    public GameObject[] themeActiveButton;
    public Text[] themeText;


    public void themeKaufen(int itemPreis)
    {
        // Kontostand Überprüfen
        if (kontostandCoins >= itemPreis)
        {
            //Kontostand neu berechnen
            myInventory.KontostandCoinsErrechnen(itemPreis);
            //Kontostand aktualisieren
            KontostandCoinsAktualisieren();
            // Einkauf abspeichern
            myInventory.SaveInventoryForTheme(1);
            PlayerPrefs.SetInt("snowthemebuyed", 1);


            //Button deaktivieren
            if (themeCostButton[0].activeSelf)
            {

                themeCostButton[0].SetActive(false);
            }
            themeActiveButton[1].SetActive(true);
            //TODO: Schleife
            themeActiveButton[1].GetComponent<Button>().interactable = false;
            themeActiveButton[0].GetComponent<Button>().interactable = true;

            themeText[1].text = "ACTIVATED";
            themeText[0].text = "activate";
        }
    }

    public void changeTheme(int theme)
    {
        
            // Einkauf abspeichern
            myInventory.SaveInventoryForTheme(theme);

        for (int i=0; i<=1; i++)
        {
            //Button deaktivieren
            if(i == theme)
            {
                themeActiveButton[i].SetActive(true);
                themeText[i].text = "ACTIVATED";
                themeActiveButton[i].GetComponent<Button>().interactable = false;
            } else
            {
                themeActiveButton[i].GetComponent<Button>().interactable = true;
                themeText[i].text = "activate";
            }
            //TODO: Schleife
            

            
            
        }
            
    }

    public void GpsKaufenVideo(int itemPreis)
    {
        // Kontostand Überprüfen
        //if (Video gesehen)
        //{
            //Kontostand neu berechnen
            myInventory.KontostandCoinsErhoehen(itemPreis);

        //Kontostand aktualisieren
        KontostandCoinsAktualisieren();
        //}
    }

    public void GpsKaufenEuro(int itemPreis)
    {
        // Kontostand Überprüfen
        //if (geld überwiesen)
        //{
        myInventory.KontostandCoinsErhoehen(itemPreis);

        /*if(itemPreis == 200)
        {
            IAPManager.Instance.Buy200Gp();
        } else if (itemPreis == 500)
        {
            IAPManager.Instance.Buy500Gp();
        } else if (itemPreis == 1000)
        {
            IAPManager.Instance.Buy1000Gp();
        }
        */

        //Kontostand aktualisieren
        KontostandCoinsAktualisieren();
        //}
    }

    private void KontostandCoinsAktualisieren()
    {
        myInventory.LoadInventory();
        kontostandCoinsText.text = kontostandCoins.ToString();
    }
}
