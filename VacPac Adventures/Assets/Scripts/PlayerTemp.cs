using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTemp : MonoBehaviour
{
    public static PlayerTemp Instance;

    //temp
    public float currenthealth;
    public float maxHealth;
    public float currentFuel;
    public float maxFuel;

    public GameObject vacPacObject;

    public GameObject gameOverScreen;

    private void initiateGameOver()
    {
        gameObject.GetComponent<FPSController>().enabled = false;
        vacPacObject.GetComponent<VacPackAlpha>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverScreen.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameOverScreen != null && currenthealth <= 0)
        {
            initiateGameOver();
        }
    }
}
