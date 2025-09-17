using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// MUST USE UNITYENGINE.SCENEMANAGEMENT TO GET ACCESS TO SCENEMANAGER.
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // "BUTTON STARTBUTTON" IS FOR CLICK, "KEYCODE STARTKEY" IS FOR KEY PRESS.
    public Button startButton;
    public KeyCode startKey;


    // THIS START SCRIPT IS FOR BUTTON INPUT ON CLICK.
    void Start()
    {
        startButton.onClick.AddListener(HandleStartButtonPressed);
    }

    // THIS UPDATE SCRIPT IS FOR BUTTON INPUT ON KEY PRESS.
    private void Update()
    {
        if (Input.GetKeyDown(startKey))
        {
            HandleStartButtonPressed();
        }
    }

  // THIS "HANDLESTARTBUTTONPRESSED" IS NEEDED FOR BOTH CLICK AND KEY PRESS.
    public void HandleStartButtonPressed()
    {
        SceneManager.LoadScene(1);
    }
}
