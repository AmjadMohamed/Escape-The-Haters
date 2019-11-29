using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text ScoreText;
    public Text HighScoreText;

    public float Score;
    public static int highscore;
    public Transform Player;

    public GameObject HTP;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("High Score", 0);
        HighScoreText.GetComponent<Text>().text = "HIGH SCORE :" + highscore;
    }


    void Update()
    {
        //Debug.Log(Score);
        ScoreText.GetComponent<Text>().text =  Player.transform.position.x.ToString("0");
        HighScoreText.GetComponent<Text>().text = "HIGH SCORE :" + highscore;

        if(Score>highscore)
        {
            HighScoreText.GetComponent<Text>().text = "HIGH SCORE :" + Score;
        }

        int originalHighScore = PlayerPrefs.GetInt("High Score", 0);
        // compare current session's high score vs our recorded high score from prefs
        if (highscore > originalHighScore)
        {
            PlayerPrefs.SetInt("High Score", highscore);
        }

    }

    public void GameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void HTPpanel()
    {
        HTP.SetActive(true);
    }

   
}
