using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayGamesControllerHandler : MonoBehaviour
{
    public GameObject PlayGamesController;
    // Start is called before the first frame update
    void Start()
    {
        if (!GameObject.Find("PlayGamesController(Clone)") || !GameObject.Find("PlayGamesController"))
        {
            GameObject gaOb = Instantiate(PlayGamesController);
        }
    }
}
