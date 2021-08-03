
using UnityEngine;

public class DDOL : MonoBehaviour
{
    public static DDOL instance;

    // Start is called before the first frame update
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
    
}
