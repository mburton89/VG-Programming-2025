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

  public string winMessage;

  public int whoScored = 1;

  public List<string> p1WinMsgs;
  public List<string> p2WinMsgs;

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
      whoScored = -1;
    }
    else
    {
      p2Score += 1;
      whoScored = 1;
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
    string messageToDisplay;

    if (isP1)
    {
      int rand = Random.Range(0, p1WinMsgs.Count);
      messageToDisplay = p1WinMsgs[rand];
    }
    else
    {
      int rand = Random.Range(0, p2WinMsgs.Count);
      messageToDisplay = p2WinMsgs[rand];
    }

    winText.SetText(messageToDisplay);

  }

  void ResetGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}
