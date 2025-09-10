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
    public TextMeshProUGUI winText;

    public List<string> p1WinMessages;
    public List<string> p2WinMessages;

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

        if (p1Score >= maxScore || p2Score >= maxScore)
        {
            HandleWin(isP1);
        }
        else
        {
            BallSpawner.Instance.SpawnBall(isP1);
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
        string messageToDisplay;

        if (isP1)
        {
            int rand = Random.Range(0, p1WinMessages.Count);
            messageToDisplay = p1WinMessages[rand];
        }
        else
        {
            int rand = Random.Range(0, p2WinMessages.Count);
            messageToDisplay = p2WinMessages[rand];
        }

        winText.SetText(messageToDisplay);
        SoundManager.Instance.PlaySound(SoundManager.SoundType.win);
    }

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
