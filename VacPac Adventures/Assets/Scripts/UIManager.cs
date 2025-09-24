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
    public TextMeshProUGUI playerHeightScoreTMP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar();
        JetFuelBar();
        HeightScoreUpdate();
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
        }
    }
}
