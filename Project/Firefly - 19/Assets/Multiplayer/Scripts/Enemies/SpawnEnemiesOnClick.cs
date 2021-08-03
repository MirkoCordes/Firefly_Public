using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemiesOnClick : MonoBehaviour
{
    //Buttons and Spawnpoints
    public GameObject[] HornetButtons;
    public GameObject[] RainButtons;
    public GameObject[] HornetSpawnPoints;
    public GameObject[] HornetSpawnPoint0;
    public GameObject[] HornetSpawnPoint1;
    public GameObject[] HornetSpawnPoint2;
    public GameObject[] HornetSpawnPoint3;

    public GameObject[] RainSpawnPoints;
    public GameObject[] RainSpawnPoint0;
    public GameObject[] RainSpawnPoint1;
    public GameObject[] RainSpawnPoint2;
    public GameObject HandButton;
    public GameObject SwatterButton;

    public GameObject HornetPrefab;
    public GameObject RainPrefab;

    private PhotonView PhotonView;
    public LocationNetwork locationNetwork;

    public GameObject DragHereOverlay;
    private bool spawnedHand;
    private bool spawnedSwatter;

    private OnClickFillAmountAnimationController onClickFillAmountAnimationController;

    private void Start()
    {
        PhotonView = GetComponent<PhotonView>();
        onClickFillAmountAnimationController = GetComponent<OnClickFillAmountAnimationController>();
    }

    public void OnClickSpawnHornet(int spawnId)
    {
        for (int i=0; i<3; i++)
        {
            RainButtons[i].GetComponent<Button>().interactable = false;
            HornetButtons[i].GetComponent<Button>().interactable = false;
        }
        for (int i = 0; i < 4; i++)
        {
            HornetButtons[i].GetComponent<Button>().interactable = false;
        }
        HandButton.GetComponent<Button>().interactable = false;
        SwatterButton.GetComponent<Button>().interactable = false;

        onClickFillAmountAnimationController.StartAnimation(1.5f);
        StartCoroutine(ActivateAllButtons(1.5f));
        GetComponent<PhotonView>().RPC("RPC_HornetSpawn", PhotonTargets.All);
        SpawnHornet(spawnId);
    }

    public void SpawnHornet(int spawnId)
    {
        
        if (spawnId == 0)
        {
            StartCoroutine(WiederholeSpawnHornet(HornetSpawnPoint0));
        }
        else if (spawnId == 1)
        {
            StartCoroutine(WiederholeSpawnHornet(HornetSpawnPoint1));
        }
        else if (spawnId == 2)
        {
            StartCoroutine(WiederholeSpawnHornet(HornetSpawnPoint2));
        } else
        {
            StartCoroutine(WiederholeSpawnHornet(HornetSpawnPoint3));
        }
    }

    IEnumerator WiederholeSpawnHornet(GameObject[] spawnAtThesePoint)
    {
        Vector3 spawnVect0 = spawnAtThesePoint[0].transform.position;
        GameObject g0 = (GameObject)PhotonNetwork.Instantiate("HornetEnemie", new Vector3(spawnVect0.x, spawnVect0.y, 100), Quaternion.identity, 0) as GameObject;
        yield return new WaitForSeconds(0.1f);

        for (int i = 1; i <= 2; i++)
        {
            Vector3 spawnVect = spawnAtThesePoint[i].transform.position;
            GameObject g = (GameObject)PhotonNetwork.Instantiate("HornetEnemie", new Vector3(spawnVect.x, spawnVect.y, 100), Quaternion.identity, 0) as GameObject; 
        }
        yield return new WaitForSeconds(0.1f);

        for (int b = 3; b <= 4; b++)
        {
            Vector3 spawnVect = spawnAtThesePoint[b].transform.position;
            GameObject g = (GameObject)PhotonNetwork.Instantiate("HornetEnemie", new Vector3(spawnVect.x, spawnVect.y, 100), Quaternion.identity, 0) as GameObject;
        }
        yield return new WaitForSeconds(0.1f);
        Vector3 spawnVect1 = spawnAtThesePoint[0].transform.position;
        GameObject g1 = (GameObject)PhotonNetwork.Instantiate("HornetEnemie", new Vector3(spawnVect1.x, spawnVect1.y, 100), Quaternion.identity, 0) as GameObject;
    }
    
    IEnumerator ActivateAllButtons(float wait)
    {
        yield return new WaitForSeconds(wait);
            for (int i = 0; i < 3; i++)
            {
                RainButtons[i].GetComponent<Button>().interactable = true;
                HornetButtons[i].GetComponent<Button>().interactable = true;
            }
            for (int i = 0; i < 4; i++)
            {
                HornetButtons[i].GetComponent<Button>().interactable = true;
            }
            HandButton.GetComponent<Button>().interactable = true;
            SwatterButton.GetComponent<Button>().interactable = true;
    }

    [PunRPC]
    private void RPC_HornetSpawn()
    {
        //Warner aktivieren (LocationNetwork aufrufen)
        locationNetwork.ActivateHornetWarner();
    }



    public void OnClickSpawnRain(int spawnId)
    {
        for (int i = 0; i < 3; i++)
        {
            RainButtons[i].GetComponent<Button>().interactable = false;
            HornetButtons[i].GetComponent<Button>().interactable = false;
        }
        for (int i = 0; i < 4; i++)
        {
            HornetButtons[i].GetComponent<Button>().interactable = false;
        }

        HandButton.GetComponent<Button>().interactable = false;
        SwatterButton.GetComponent<Button>().interactable = false;

        onClickFillAmountAnimationController.StartAnimation(2f);
        StartCoroutine(ActivateAllButtons(2f));
        GetComponent<PhotonView>().RPC("RPC_RainSpawn", PhotonTargets.All);
        SpawnRain(spawnId);
    }

    public void SpawnRain(int spawnId)
    {
        if (spawnId == 0)
        {
            StartCoroutine(WiederholeSpawnRain(RainSpawnPoint0));
        } else if (spawnId == 1)
        {
            StartCoroutine(WiederholeSpawnRain(RainSpawnPoint1));
        } else
        {
            StartCoroutine(WiederholeSpawnRain(RainSpawnPoint2));
        } 
    }

    IEnumerator WiederholeSpawnRain(GameObject[] spawnAtThesePoint)
    {
        for (int b = 0; b < 2; b++)
        {
            Vector3 spawnVect = spawnAtThesePoint[0].transform.position;
            GameObject g = (GameObject)PhotonNetwork.Instantiate("Raindrop", new Vector3(spawnVect.x, spawnVect.y, 100), Quaternion.identity, 0) as GameObject; //RainSpawnPoints[spawnId].GetComponent<Transform>().position
            yield return new WaitForSeconds(0.25f);
        }
        for (int i = 0; i < 2; i++)
        {
            for (int b = 0; b <= 2; b++)
            {
                Vector3 spawnVect = spawnAtThesePoint[b].transform.position;
                GameObject g = (GameObject)PhotonNetwork.Instantiate("Raindrop", new Vector3(spawnVect.x, spawnVect.y, 100), Quaternion.identity, 0) as GameObject; //RainSpawnPoints[spawnId].GetComponent<Transform>().position
            }
            yield return new WaitForSeconds(0.25f);
        }
        for (int b = 0; b <= 4; b++)
        {
            Vector3 spawnVect = spawnAtThesePoint[b].transform.position;
            GameObject g = (GameObject)PhotonNetwork.Instantiate("Raindrop", new Vector3(spawnVect.x, spawnVect.y, 100), Quaternion.identity, 0) as GameObject; //RainSpawnPoints[spawnId].GetComponent<Transform>().position
        }
        yield return new WaitForSeconds(0.25f);
    }

    

    [PunRPC]
    private void RPC_RainSpawn()
    {
        //Warner aktivieren (LocationNetwork aufrufen)
        locationNetwork.ActivateRainWarner();
    }










    public void OnClickSpawnHand(Vector3 spawnVect)
    {
        DragHereOverlay.SetActive(false);
        spawnedHand = true;

        for (int i = 0; i < 4; i++)
        {
            HornetButtons[i].GetComponent<Button>().interactable = false;
        }
        for (int i = 0; i < 3; i++)
        {
            RainButtons[i].GetComponent<Button>().interactable = false;
        }
        HandButton.GetComponent<Button>().interactable = false;
        SwatterButton.GetComponent<Button>().interactable = false;

        onClickFillAmountAnimationController.StartAnimation(3f);
        StartCoroutine(ActivateAllButtons(3f));
        GetComponent<PhotonView>().RPC("RPC_HandSpawn", PhotonTargets.All);
        StartCoroutine(SpawnHand(spawnVect));
    }

    IEnumerator SpawnHand(Vector3 spawnVect)
    {
        yield return new WaitForSeconds(0f);
        GameObject g = (GameObject)PhotonNetwork.Instantiate("Hand", new Vector3(spawnVect.x, spawnVect.y, 100), Quaternion.identity, 0) as GameObject;
        //g.transform.SetParent(RainSpawnPoints[spawnId].transform, false);
    }

    

    [PunRPC]
    private void RPC_HandSpawn()
    {
        //Warner aktivieren (LocationNetwork aufrufen)
        locationNetwork.ActivateHandWarner();
    }









    public void OnClickSpawnSwatter(Vector3 spawnVect)
    {
        spawnedSwatter = true;
        DragHereOverlay.SetActive(false);
        for (int i = 0; i < 4; i++)
        {
            HornetButtons[i].GetComponent<Button>().interactable = false;
        }
        for (int i = 0; i < 3; i++)
        {
            RainButtons[i].GetComponent<Button>().interactable = false;
        }
        HandButton.GetComponent<Button>().interactable = false;
        SwatterButton.GetComponent<Button>().interactable = false;

        onClickFillAmountAnimationController.StartAnimation(3f);
        StartCoroutine(ActivateAllButtons(3f));
        GetComponent<PhotonView>().RPC("RPC_SwatterSpawn", PhotonTargets.All);
        StartCoroutine(SpawnSwatter(spawnVect));
    }

    IEnumerator SpawnSwatter(Vector3 spawnVect)
    {
        yield return new WaitForSeconds(0f);
        GameObject g = (GameObject)PhotonNetwork.Instantiate("Swatter", new Vector3(spawnVect.x, spawnVect.y, 100), Quaternion.identity, 0) as GameObject;
        //g.transform.SetParent(RainSpawnPoints[spawnId].transform, false);
    }
    
    [PunRPC]
    private void RPC_SwatterSpawn()
    {
        //Warner aktivieren (LocationNetwork aufrufen)
        locationNetwork.ActivateSwatterWarner();
    }


    public void OnClickOpenDragOverlay()
    {
        DragHereOverlay.SetActive(true);
        StartCoroutine(CloseDragOverlay());
    }

    IEnumerator CloseDragOverlay()
    {
        yield return new WaitForSeconds(3f);
        DragHereOverlay.SetActive(false);
    }
}
