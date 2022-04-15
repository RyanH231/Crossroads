using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject endScreen;
    public GameObject winText;
    public GameObject gameOverText;

    public static UI instance;

    private void Awake()
    {
        instance = this;
    }


    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void SetEndScreen(bool _DidWin)
    {
        endScreen.SetActive(true);
        winText.SetActive(_DidWin);
        gameOverText.SetActive(!_DidWin); 

    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
