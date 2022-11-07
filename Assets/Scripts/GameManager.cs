using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    // static heryerden erisebilir;
    public static Vector2 ButtonLeft;
    public static bool GameOver;
    public GameObject GameOverPanel;
    public static bool GameStarted;
    public GameObject GetReady;
    public static int GameScore;
    public GameObject score;

    private void Awake()
    {
        ButtonLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        
    }
    // if yazıp taba basarsan dırek olusturuyor;
    void Start()
    {
        GameOver = false;
        GameStarted = false;
    }
    public void GameOverClass()
    {
        GameOver = true;
        GameOverPanel.SetActive(true);
        score.SetActive(false);
        GameScore = score.GetComponent<Score>().GetScore();
    }
    public void GameHasStarted()
    {
        GameStarted = true;
        GetReady.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartButton()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
