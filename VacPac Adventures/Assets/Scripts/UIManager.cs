using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Image healthBarFill;
    public Image jetFuelBarFill;

    float minPlayerHeight;
    float maxPlayerHeight;

    //temp
    public float currenthealth;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar();
    }


    void HealthBar()
    {
        //get player health
        //
        healthBarFill.fillAmount = currenthealth / maxHealth;
    }

    private void CheckpointMarkers()
    {
        // float variableCheckpointLocation = (maxHeight - Min Height) / (checpointLocation - minHeight)
        //
    }
}
