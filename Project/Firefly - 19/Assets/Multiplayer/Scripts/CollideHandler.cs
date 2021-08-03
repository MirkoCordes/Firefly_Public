using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideHandler : MonoBehaviour
{
    private DieController dieController;

    // Start is called before the first frame update
    void Start()
    {
        dieController = DieController.FindObjectOfType<DieController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Enemie" || collision.gameObject.tag == "Hornet" || collision.gameObject.tag == "Raindrop" || collision.gameObject.tag == "Hand"))
        {
            dieController.IDied();
        }
    }
}
