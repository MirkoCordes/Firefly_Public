using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelCounter : MonoBehaviour
{
    private int level;
    private int gameMemberId;
    public static LevelCounter instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int CounterHozaehlen()
    {
        level++;
        return level;
    }

    public int ReturnGameMemberId()
    {
        gameMemberId++;
        return gameMemberId;
    }

    public int ReturnCounter()
    {
        return level;
    }
}
