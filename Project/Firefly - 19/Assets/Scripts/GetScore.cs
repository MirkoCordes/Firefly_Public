using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScore : MonoBehaviour
{
    public int scoreText;
    public GameObject score_text;
    public ScoreCreator scoreCreator;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    public int ReturnScore()
    {
        return scoreText;
    }

    public void GETScore()
    {
        UnityEngine.UI.Text t = score_text.GetComponent<UnityEngine.UI.Text>();
        scoreText = scoreCreator.GetScore();

        t.text = scoreText.ToString();
    }
}
