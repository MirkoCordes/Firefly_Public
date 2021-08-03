using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandomly : Photon.MonoBehaviour
{
    //SPÄTER ALLES KOMMENTIERTE EINFÜGEN
    public float speed;
    private float waitTime;
    public float startWaitTime;

    private bool hasWaited;
    public GameObject[] path;
    //private Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private LocationNetwork locationNetwork;
    private PhotonView PhotonView;
    //private int PlayersInGame;

    private Vector3 correctBotPos;
    private Quaternion correctBotRot;
    private DieController dieController;
    //private int areDead;
    private string[] botName = new string[] {
        "Anneliese_Brown",
        "Folker",
        "Om4_f1el_1ns_kl0",
        "Agathe_Bauer",
        "Skinnex",
        "Skat_Man",
        "Hektig",
        "Karla",
        "Doobe",
        "ZoomBee",

        "Birdbogs",
        "ColyBri523",
        "Ku3b3l_hu2",
        "Crocodile_dundee",
        "BohRap",
        "WhaasAb",
        "Siegried",
        "Günther",
        "M3inN4me",
        "C0nn3ct1ng",
    };
    int randInt;

    private void Start()
    {
        hasWaited = false;
        StartCoroutine(WaitBeforeYouGoGo());
        path = GameObject.FindGameObjectsWithTag("MoveSpot");
        locationNetwork = LocationNetwork.FindObjectOfType<LocationNetwork>();

        randInt = Random.Range(0, 19);
        
        PhotonView = GetComponent<PhotonView>();

        dieController = DieController.FindObjectOfType<DieController>();

        //moveSpot = path[locationNetwork.BotNumberReturn()].GetComponent<Transform>();

        startWaitTime = Random.Range(0f, 0.5f);
        waitTime = startWaitTime;
        //moveSpot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 60);
    }

    private void Update()
    {
        if (PhotonNetwork.isMasterClient)
        {
            if (hasWaited)
            {
            
                //Vector3 difference = moveSpot.position - transform.position;
                //float rotationZ = Mathf.Atan2(difference.x, difference.y) * -Mathf.Rad2Deg;
                //transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

                //transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
            }


            /*if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
            {
                if (waitTime <= 0)
                {

                    startWaitTime = Random.Range(0f, 0.2f);
                    moveSpot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 60);
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }*/
        }

        if (!photonView.isMine)
        {
            transform.position = Vector3.Lerp(transform.position, this.correctBotPos, Time.deltaTime * 5);
            transform.GetChild(0).transform.rotation = Quaternion.Lerp(transform.GetChild(0).transform.rotation, this.correctBotRot, Time.deltaTime * 10);
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            this.correctBotPos = (Vector3)stream.ReceiveNext();
            this.correctBotRot = (Quaternion)stream.ReceiveNext();
        }
    }

    IEnumerator WaitBeforeYouGoGo()
    {
        yield return new WaitForSeconds(4f);
        hasWaited = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemie" || collision.gameObject.tag == "Hornet" || collision.gameObject.tag == "Raindrop" || collision.gameObject.tag == "Hand")
        {
            PhotonView.RPC("RPC_PlayerDied", PhotonTargets.MasterClient);

            Vector3 particleVect = gameObject.transform.position;
            GameObject p = (GameObject)PhotonNetwork.Instantiate("DieParticle", new Vector3(particleVect.x, particleVect.y, 100), Quaternion.identity, 0) as GameObject;
            PhotonNetwork.Destroy(gameObject);
        }
    }
    
}
