using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int p1Score;
    public int p2Score;
    public int maxScore;
    public TextMeshProUGUI p1ScoreText;
    public TextMeshProUGUI p2ScoreText;
    public TextMeshProUGUI endGameText;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.anyKey && (p1Score >= maxScore || p2Score >= maxScore))
        { 
            ResetGame();
        }
    }

    public void GivePoint(bool isP1)
    {
        if (isP1)
        {
            p1Score += 1;
        }
        else 
        {
            p2Score += 1;
        }

        if (p1Score >= maxScore || p2Score >= maxScore)
        {
            HandleWin(isP1);
        }
        else
        {
            BallSpawner.Instance.SpawnBall();
        }

        UpdateScoreboard();
    }

    void UpdateScoreboard()
    {
        p1ScoreText.SetText(p1Score.ToString());
        p2ScoreText.SetText(p2Score.ToString());
    }

    void HandleWin(bool isP1)
    {
        if (isP1)
        {
            endGameText.SetText("Player 2 Loses \nPress any key to restart");
        }
        else
        { 
            endGameText.SetText("Player 1 Loses \nPress any key to restart");
        }
    }

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
