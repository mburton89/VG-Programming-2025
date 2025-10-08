using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Image healthBarFill;
    public Image jetFuelBarFill;

    public int playerHeightScore;
    private int highScore;
    public TextMeshProUGUI playerHeightScoreTMP;
    public TextMeshProUGUI playerBestScoreTMP;
    public TextMeshProUGUI timerTMP;
    public KeyCode resetScoreKey;
    public float timeLeft = 60;
    private float timeLeftRounded;
    public bool timerIsCounting;

    //debug - delete later
    public KeyCode debugGameOverKey;
    public KeyCode debugTimerAdd;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        highScore = PlayerPrefs.GetInt("highScore");
        playerBestScoreTMP.SetText("Best: " +  highScore);
        timeLeftRounded = timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
            HealthBar();
            JetFuelBar();
            HeightScoreUpdate();

        
        if (Input.GetKey(resetScoreKey))
        {
            ResetBestScore();
        }
        if (timerIsCounting == true)
        {
            RunTimer();
        }
        //Debug
        if (Input.GetKeyDown(debugGameOverKey))
        {
            GameOver.Instance.ShowGameOver();
        }
        if (Input.GetKeyDown(debugTimerAdd))
        {
            AddToTimer(10);
        }
    }


    void HealthBar()
    {
        healthBarFill.fillAmount = PlayerTemp.Instance.currenthealth / PlayerTemp.Instance.maxHealth;
    }

    void JetFuelBar()
    {
        jetFuelBarFill.fillAmount = PlayerTemp.Instance.currentFuel / PlayerTemp.Instance.maxFuel;
    }

    public void HeightScoreUpdate()
    {
        if (playerHeightScore + 1 <= PlayerTemp.Instance.transform.position.y)
        {
            playerHeightScore = (int)PlayerTemp.Instance.transform.position.y;
            playerHeightScoreTMP.SetText("Score: " + playerHeightScore);
            if (playerHeightScore > PlayerPrefs.GetInt("highScore"))
            {
                BestScoreUpdate();
            }
        }
    }

    public void AddTimeToScore()
    {
        playerHeightScore = playerHeightScore + (int)timeLeftRounded;

        playerHeightScoreTMP.SetText("Score: " + playerHeightScore);
        if (playerHeightScore > PlayerPrefs.GetInt("highScore"))
        {
            BestScoreUpdate();
        }
    }

    private void BestScoreUpdate()
    {
        PlayerPrefs.SetInt("highScore", playerHeightScore);
        highScore = PlayerPrefs.GetInt("highScore");
        playerBestScoreTMP.SetText("Best: " + highScore);
        PlayerPrefs.Save();
    }

    private void ResetBestScore()
    {
        PlayerPrefs.SetInt("highScore", 0);
        highScore = PlayerPrefs.GetInt("highScore");
        playerBestScoreTMP.SetText("Best: " + highScore);
        PlayerPrefs.Save();
    }

    //Run a Timer, when timer ends run GameOver in SceneManager
    private void RunTimer()
    {
        
        timeLeft = timeLeft - Time.deltaTime;

        if (timeLeft <= timeLeftRounded && timeLeft >= 0)
        {
            timeLeftRounded = (int)timeLeft;
            timerTMP.SetText("Time Left: " + timeLeftRounded);
        }
        if (timeLeft <= 0)
        {
            GameOver.Instance.ShowGameOver();
        }
    }

    private void AddToTimer(float timeNumAdd)
    {
        timeLeft = timeLeft + timeNumAdd;
        timeLeftRounded = (int)timeLeft;
        timerTMP.SetText("Time Left: " + timeLeftRounded);
    }
}
