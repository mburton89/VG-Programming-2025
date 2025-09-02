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

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {

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

        UpdateScoreboard();
    }

    void UpdateScoreboard()
    {
        p1ScoreText.SetText(p1Score.ToString());
        p2ScoreText.SetText(p2Score.ToString());
    }

    void HandleWin(bool isP1)
    {

    }

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
