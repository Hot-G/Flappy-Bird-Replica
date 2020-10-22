using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text ScoreText;
    public GameObject HelpImage;
    public GameObject PipeSpawner;
    public GameObject EndCanvas;
    public Text EndScoreText;
    public Text EndHighScoreText;
    public Image EndMedal;
    public Sprite[] Medals;
    [HideInInspector]
    public bool isStarted;

    private int Score;
    private int HighScore;

    void Start()
    {
        Time.timeScale = 1;
        ScoreText.text = "0";

        if (PlayerPrefs.HasKey("HighScore"))
            HighScore = PlayerPrefs.GetInt("HighScore");
        else
            HighScore = 0;
    }

    public void EndGame()
    {
        EndCanvas.SetActive(true);
        ScoreText.gameObject.SetActive(false);
        EndScoreText.text = Score.ToString();

        if (Score > 10)
            EndMedal.sprite = Medals[2];
        else if (Score > 5)
            EndMedal.sprite = Medals[1];
        else
            EndMedal.sprite = Medals[0];

        if(Score > HighScore)
        {
            HighScore = Score;
            PlayerPrefs.SetInt("HighScore", HighScore);
        }
        EndHighScoreText.text = HighScore.ToString();

        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        isStarted = true;
        HelpImage.SetActive(false);
        PipeSpawner.SetActive(true);
    }

    public void AddScore()
    {
        Score++;
        ScoreText.text = Score.ToString();
    }

}
