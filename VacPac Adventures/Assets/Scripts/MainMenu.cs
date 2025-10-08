using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button mainMenuButton;
    public KeyCode startKey;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuButton.onClick.AddListener(HandleStartButtonPressed);
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
