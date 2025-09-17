using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public KeyCode startKey;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(HandleStartButtonPressed);
    }

    private void Update()
    {
        if (Input.GetKeyDown(startKey))
        { 
            HandleStartButtonPressed();
        }
    }

    public void HandleStartButtonPressed() 
    {
        SceneManager.LoadScene(1);
    }
}
