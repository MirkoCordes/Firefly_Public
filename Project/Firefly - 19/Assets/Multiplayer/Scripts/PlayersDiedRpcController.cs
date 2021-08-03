using UnityEngine;

public class PlayersDiedRpcController : MonoBehaviour
{
    
    //public DieController dieController;

    PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        //dieController = DieController.FindObjectOfType<DieController>();
    }

    
}
