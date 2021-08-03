using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerNetwork : MonoBehaviour
{
    public static PlayerNetwork Instance;
    public string PlayerName { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        
#if UNITY_IOS
        //PlayerName = Social.localUser.userName;   //Spielername
#elif UNITY_EDITOR
        //PlayerName = "Player#" + Random.Range(1000, 9999); //Standart Spielername durch playernetwork festgelegt
#elif UNITY_ANDROID
        //PlayerName = Social.Active.localUser.userName;
        //PlayerName = PlayGamesController.instance.name;
#else
        //PlayerName = "Player#" + Random.Range(1000, 9999); //Standart Spielername durch playernetwork festgelegt
#endif

        //PhotonNetwork.playerName = PlayerName;
        
    }
}
