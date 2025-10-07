using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [Header("References")]
    public GameObject gameOverCanvas;
    public static GameOver Instance;
    public Button restartButton;
    public Button mainMenuButton;

    private void Awake()
    {
        Instance = this;
        restartButton.onClick.AddListener(RestartScene);
        mainMenuButton.onClick.AddListener(MainMenuSceneLoad);
    }

    public void Update()
    {
        if (PlayerTemp.Instance.currenthealth <= 0)
        {
            ShowGameOver();
        }

    }
    // should be moved to enemy script
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            ShowGameOver();
        }
    }
    // end should be moved

    public void ShowGameOver()
    {
        if (gameOverCanvas != null)
        {
            UIManager.Instance.AddTimeToScore();
            FPSController.Instance.moveSpeed = 0;
            FPSController.Instance.mouseSensitivity = 0;
            FPSController.Instance.jumpForce = 0;
            gameOverCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //Time.timeScale = 0f;
        }

    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        GameManager.instance.RestartScene();

    }
    public void MainMenuSceneLoad()
    {
        Time.timeScale = 1f;
        GameManager.instance.LoadMainMenu();
    }

}