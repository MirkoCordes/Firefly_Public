using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //Charakter
    bool normalCharacter;
    bool redCharacter;
    bool pinkCharacter;
    bool yellowCharacter;
    bool blueCharacter;

    //Items vom Shop
    public int slowDownStart;
    public int protective;
    public int health;

    DieMenueScript dieMenueScript;
    public bool playAfterDie;

    //Delete PlayerPrefs
    public bool DeletePlayerPrefs = false;
    
    public int kontostandCoins;
    public int coinsInGame;
    
    public static Inventory instance;

    //Für themes
    public bool standardBackground;



    public int highscore;

    int tmpScore;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //GameObject schon vorhanden?
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }

        //Überprüfen ob Playerprefs gelöscht werden sollen
        if (DeletePlayerPrefs)
        {
            PlayerPrefs.DeleteAll();
        }
        coinsInGame = 0;

        

        
        normalCharacter = true;
        redCharacter = false;
        pinkCharacter = false;
        yellowCharacter = false;
        blueCharacter = false;
        standardBackground = true;

        //Gespeicherte Daten laden
        LoadInventory();

        tmpScore = 0;
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscore = PlayerPrefs.GetInt("Highscore");
        }

        dieMenueScript = GameObject.FindObjectOfType<DieMenueScript>();
        
        
    }

    //Daten laden
    public void LoadInventory()
    {
        if(PlayerPrefs.HasKey("normalCharacterActivated"))
        {
            int activateNormChar = PlayerPrefs.GetInt("normalCharacterActivated");
            int activateRedChar = PlayerPrefs.GetInt("redCharacterBuyedActivated");
            int activatePinkChar = PlayerPrefs.GetInt("pinkCharacterBuyedActivated");
            int activateYellowChar = PlayerPrefs.GetInt("yellowCharacterBuyedActivated");
            int activateBlueChar = PlayerPrefs.GetInt("blueCharacterBuyedActivated");

            if (activateNormChar == 1)
            {
                ActivateNormalChar();
            } else if (activateRedChar == 1)
            {
                ActivateRedChar();
            } else if (activatePinkChar == 1)
            {
                ActivadePinkChar();
            } else if (activateYellowChar == 1)
            {
                ActivadeYellowChar();
            } else if (activateBlueChar == 1)
            {
                ActivadeBlueChar();
            }
        }

        if (PlayerPrefs.HasKey("SlowDownStart"))
        {
            slowDownStart = PlayerPrefs.GetInt("SlowDownStart");
        }
        if (PlayerPrefs.HasKey("Protective"))
        {
            protective = PlayerPrefs.GetInt("Protective");
        }
        if (PlayerPrefs.HasKey("Health"))
        {
            health = PlayerPrefs.GetInt("Health");
        }
        
        if (PlayerPrefs.HasKey("KontostandCoins"))
        {
            kontostandCoins = PlayerPrefs.GetInt("KontostandCoins");
        }

        if (PlayerPrefs.HasKey("theme"))
        {
            if(PlayerPrefs.GetInt("theme") == 0)
            {
                standardBackground = true;
            } else
            {
                standardBackground = false;
            }
        }
        

    }

    public void SaveInventoryForTheme(int themenumber)
    {
        if (themenumber == 0)
        {
            standardBackground = true;
        }
        else if(themenumber == 1)
        {
            standardBackground = false;
        }
        PlayerPrefs.SetInt("theme", themenumber);
    }

    //Daten abspeichern
    public void SaveInventoryForNormalChar()
    {
        ActivateNormalChar();
        PlayerPrefs.SetInt("normalCharacterBuyed", 1);

        PlayerPrefs.SetInt("normalCharacterActivated", 1);
        PlayerPrefs.SetInt("redCharacterBuyedActivated", 0);
        PlayerPrefs.SetInt("pinkCharacterBuyedActivated", 0);
        PlayerPrefs.SetInt("yellowCharacterBuyedActivated", 0);
        PlayerPrefs.SetInt("blueCharacterBuyedActivated", 0);
    }

    public void SaveInventoryForRedChar()
    {
        ActivateRedChar();
        PlayerPrefs.SetInt("redCharacterBuyed", 1);

        PlayerPrefs.SetInt("normalCharacterActivated", 0);
        PlayerPrefs.SetInt("redCharacterBuyedActivated", 1);
        PlayerPrefs.SetInt("pinkCharacterBuyedActivated", 0);
        PlayerPrefs.SetInt("yellowCharacterBuyedActivated", 0);
        PlayerPrefs.SetInt("blueCharacterBuyedActivated", 0);
    }

    public void SaveInventoryForPinkChar()
    {
        ActivadePinkChar();
        PlayerPrefs.SetInt("pinkCharacterBuyed", 1);

        PlayerPrefs.SetInt("normalCharacterActivated", 0);
        PlayerPrefs.SetInt("redCharacterBuyedActivated", 0);
        PlayerPrefs.SetInt("pinkCharacterBuyedActivated", 1);
        PlayerPrefs.SetInt("yellowCharacterBuyedActivated", 0);
        PlayerPrefs.SetInt("blueCharacterBuyedActivated", 0);
    }

    public void SaveInventoryForYellowChar()
    {
        ActivadeYellowChar();
        PlayerPrefs.SetInt("yellowCharacterBuyed", 1);

        PlayerPrefs.SetInt("normalCharacterActivated", 0);
        PlayerPrefs.SetInt("redCharacterBuyedActivated", 0);
        PlayerPrefs.SetInt("pinkCharacterBuyedActivated", 0);
        PlayerPrefs.SetInt("yellowCharacterBuyedActivated", 1);
        PlayerPrefs.SetInt("blueCharacterBuyedActivated", 0);
    }

    public void SaveInventoryForBlueChar()
    {
        ActivadeBlueChar();
        PlayerPrefs.SetInt("blueCharacterBuyed", 1);

        PlayerPrefs.SetInt("normalCharacterActivated", 0);
        PlayerPrefs.SetInt("redCharacterBuyedActivated", 0);
        PlayerPrefs.SetInt("pinkCharacterBuyedActivated", 0);
        PlayerPrefs.SetInt("yellowCharacterBuyedActivated", 0);
        PlayerPrefs.SetInt("blueCharacterBuyedActivated", 1);
    }

    public void SaveInventoryForSlowDown()
    {
        PlayerPrefs.SetInt("SlowDownStart", slowDownStart);
    }

    public void SaveInventoryForProtection()
    {
        PlayerPrefs.SetInt("Protective", protective);
    }

    public void SaveInventoryForHealth()
    {
        PlayerPrefs.SetInt("Health", health);
    }


    public void ChangeSlowDownStart(int number)
    {
        slowDownStart += number;
        SaveInventoryForSlowDown();
    }

    public void MinimizeSlowDownStart()
    {
        slowDownStart -= 1;
        SaveInventoryForSlowDown();
    }

    public void ChangeProtective(int number)
    {
        protective += number;
        SaveInventoryForProtection();
    }

    public void MinimizeProtectiveShield()
    {
        protective -= 1;
    }

    public void ChangeHealth(int number)
    {
        health += number;
        SaveInventoryForHealth();
    }

    public void MinimizeHealth(int number)
    {
        health -= number;
    }

    public void ActivateNormalChar()
    {
        normalCharacter = true;
        redCharacter = false;
        pinkCharacter = false;
        yellowCharacter = false;
        blueCharacter = false;
    }

    public void ActivateRedChar()
    {
        normalCharacter = false;
        redCharacter = true;
        pinkCharacter = false;
        yellowCharacter = false;
        blueCharacter = false;
    }

    public void ActivadePinkChar()
    {
        normalCharacter = false;
        redCharacter = false;
        pinkCharacter = true;
        yellowCharacter = false;
        blueCharacter = false;
    }

    public void ActivadeYellowChar()
    {
        normalCharacter = false;
        redCharacter = false;
        pinkCharacter = false;
        yellowCharacter = true;
        blueCharacter = false;
    }

    public void ActivadeBlueChar()
    {
        normalCharacter = false;
        redCharacter = false;
        pinkCharacter = false;
        yellowCharacter = false;
        blueCharacter = true;
    }


    public bool GetNormalChar()
    {
        return normalCharacter;
    }
    public bool GetRedChar()
    {
        return redCharacter;
    }
    public bool GetPinkChar()
    {
        return pinkCharacter;
    }
    public bool GetYellowChar()
    {
        return yellowCharacter;
    }
    public bool GetBlueChar()
    {
        return blueCharacter;
    }

    public void AddTempCoins()
    {
        coinsInGame += 1;
    }

    public void SaveInventoryForCoinsAndGps()
    {
        kontostandCoins += coinsInGame;

        PlayerPrefs.SetInt("KontostandCoins", kontostandCoins);

        coinsInGame = 0;

        SaveInventoryForHealth();
        SaveInventoryForProtection();
        SaveInventoryForSlowDown();
    }

    
    

    public void KontostandCoinsErrechnen(int itemPreis)
    {
        kontostandCoins -= itemPreis;
        PlayerPrefs.SetInt("KontostandCoins", kontostandCoins);
    }

    public void KontostandCoinsErhoehen(int itemPreis)
    {
        kontostandCoins += itemPreis;
        PlayerPrefs.SetInt("KontostandCoins", kontostandCoins);
    }

    public void SaveHighscoreForInventory(int score)
    {
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
        }
    }

    public void GetTempScore(int tempscore)
    {
        tmpScore = tempscore;
        PlayerPrefs.SetInt("TempScore", tmpScore);
    }

    public bool GetStandardBackground()
    {
        return standardBackground;
    }
}
