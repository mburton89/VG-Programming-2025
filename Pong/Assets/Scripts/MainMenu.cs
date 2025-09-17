using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public Button startButton;


    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(HandleStartButtonPressed);
    }

    public void HandleStartButtonPressed()
    {
        SceneManager.LoadScene(1);
    }
}
