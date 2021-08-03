using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : Photon.MonoBehaviour
{
    private Vector3 correctPlayerPos;
    private Quaternion correctPlayerRot;

    PhotonView PV;
    LocationNetwork locationNetwork;
    public bool canDie;
    private GameObject[] minimapObjects;

    void Start()
    {
        minimapObjects = new GameObject[2];
        if (photonView.isMine)
        {
            gameObject.GetComponent<Camera>().enabled = true;
            gameObject.GetComponent<CameraFollow>().enabled = true;
            minimapObjects[0] = GameObject.Find("MinimapWindow");
            minimapObjects[1] = GameObject.Find("MinimapRenderTexture");
            locationNetwork = GameObject.Find("LocationManager").GetComponent<LocationNetwork>();
            gameObject.GetComponent<PlayerMultiplayerController>().enabled = true;
            canDie = true;
            PV = GameObject.Find("DieHandler").GetComponent<PhotonView>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.isMine)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 30);
            transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 10);
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.GetChild(1).rotation);
        }
        else
        {
            this.correctPlayerPos = (Vector3)stream.ReceiveNext();
            this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canDie)
        {
            if ((collision.gameObject.tag == "Enemie" || collision.gameObject.tag == "Hornet" || collision.gameObject.tag == "Raindrop" || collision.gameObject.tag == "Hand") && DieController.areDead < PhotonNetwork.playerList.Length - 2)
            {
                canDie = false;
                minimapObjects[0].SetActive(false);
                minimapObjects[1].SetActive(false);

                PV.RPC("RPC_PlayerDied", PhotonTargets.MasterClient, PhotonNetwork.player.ID);

                Vector3 particleVect = gameObject.transform.position;
                GameObject p = (GameObject)PhotonNetwork.Instantiate("DieParticle", new Vector3(particleVect.x, particleVect.y, 100), Quaternion.identity, 0) as GameObject;

                PhotonNetwork.Destroy(gameObject);
                locationNetwork.OpenDieScreen();
            }
        }
    }
}
