using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class ScoreManagement : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.scoreText.text = "Score: "+ score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
