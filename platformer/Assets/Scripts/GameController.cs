using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int Kills = 0;
    public int requredKills;
    public Text killsText;
    public Text scoreText;
    public int score = 0;
    private int sceneIndex;
    public Text highScoreText;

    void Start()
    {
        Time.timeScale = 1;
		sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        killsText.text = "Kills:" + Kills + "/" + requredKills;
        scoreText.text = "Score:" + score;
        highScoreText.text = "High Score:" + PlayerPrefs.GetInt("HighScore" + sceneIndex);
        if (score >= PlayerPrefs.GetInt("HighScore" + sceneIndex))
        {
            PlayerPrefs.SetInt("HighScore" + sceneIndex,score);
            
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
