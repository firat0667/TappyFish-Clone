using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    int score;
    Text scoreText;
    int highscore;
  public  Text highScoreText;
  public  Text finalScore;
    public GameObject New;
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        finalScore.text = score.ToString();
        highscore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = highscore.ToString();
    }
    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        finalScore.text = score.ToString();
        if (score > highscore)
        {
            highscore = score;
            highScoreText.text = highscore.ToString();
            PlayerPrefs.SetInt("HighScore",highscore);
            New.SetActive(true);
            //json yerine bunu kullandık
        }
    }
    public int GetScore()
    {
        return score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
