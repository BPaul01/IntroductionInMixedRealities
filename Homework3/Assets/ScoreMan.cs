using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreMan : MonoBehaviour
{
    public static ScoreMan instance;
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {
        instance = this;
        print("In ScoreMan script");
    }

    // Start is called before the first frame update
    void Start()
    {
        this.scoreText.text = "Score: "+ score.ToString();
    }

    public void AddPoints()
    {
        this.score += 10;
        this.scoreText.text = "Score: "+ score.ToString();
    }
}
