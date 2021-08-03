using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //set player control limits to screen width
        float theScreenWidth = Screen.width;
        float theScreenHeight = Screen.height;
        float theScreenRatio = theScreenWidth / theScreenHeight; //this determines the screen ratio (3:4=iPad_Tall, 9:16=iPhone5_Tall, etc)

        //NOTES
        // The screen ratio calculations below are based on PORTRAIT mode (3:4 & 9:16 is for portrait mode). For LANDSCAPE mode you would need different numbers (4:3 & 16:9 is landscape mode).
        // The player limit numbers I needed to work with in portrait were 7 for 3:4 and 5 for 9:16. So screen ratio of .75 needed to calculate to 7 and screen ratio of .5625 needed to calculate to 5, so that's where this weird formula below comes from.

        float theXMax = 7 - (10.67f * (.75f - theScreenRatio)); //Need theXMax values for screen ratio of 4:3(.75)=7 and for 16:9(.5625)=5

        //set some min and max values regardless of screen ratio
        if (theXMax > 9.9f)
        {
            theXMax = 9.9f; //Limit on boundary is 10
        }
        if (theXMax < 1.0f)
        {
            theXMax = 1.0f;
        }

        //set the range for player movement for 3:4 from +7 to -7 and for 9:16 from +5 to -5
        float theXMin = -theXMax;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
