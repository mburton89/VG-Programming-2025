using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Image healthBarFill;
    public Image jetFuelBarFill;

    //float minPlayerHeight;
    //float maxPlayerHeight;
    //float currentPlayerHeight;
    private int playerHeightScore;
    private int highScore;
    public TextMeshProUGUI playerHeightScoreTMP;
    public TextMeshProUGUI playerBestScoreTMP;
    public KeyCode resetScoreKey;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        playerBestScoreTMP.SetText("Best Height: " +  highScore);
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
    }


    void HealthBar()
    {
        //get player health
        //
        healthBarFill.fillAmount = PlayerTemp.Instance.currenthealth / PlayerTemp.Instance.maxHealth;
    }

    void JetFuelBar()
    {
        //get player health
        //
        jetFuelBarFill.fillAmount = PlayerTemp.Instance.currentFuel / PlayerTemp.Instance.maxFuel;
    }

    private void CheckpointMarkers()
    {
        // float variableCheckpointLocation = (maxHeight - Min Height) / (checpointLocation - minHeight)
        //
    }

    private void HeightScoreUpdate()
    {
        if (playerHeightScore + 1 <= PlayerTemp.Instance.transform.position.y)
        {
            playerHeightScore = (int)PlayerTemp.Instance.transform.position.y;
            //print(playerHeightScore);
            playerHeightScoreTMP.SetText("Max Height: " + playerHeightScore);
            if (playerHeightScore > PlayerPrefs.GetInt("highScore"))
            {
                BestScoreUpdate();
            }
        }
    }

    private void BestScoreUpdate()
    {
        PlayerPrefs.SetInt("highScore", playerHeightScore);
        highScore = PlayerPrefs.GetInt("highScore");
        playerBestScoreTMP.SetText("Best Height: " + highScore);
        //print("UpdateBestScore");
        PlayerPrefs.Save();
    }

    private void ResetBestScore()
    {
        PlayerPrefs.SetInt("highScore", 0);
        highScore = PlayerPrefs.GetInt("highScore");
        playerBestScoreTMP.SetText("Best Height: " + highScore);
        //print("UpdateBestScore");
        PlayerPrefs.Save();
    }
}
