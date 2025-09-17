using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HandleStartButtonPressed().onClick.AddListener(HandleStartButtonPressed);
    }
    public void HandleStartButtonPressed();
    {
        SceneManager.LoadScene("Gameplay")
    }

  } 
}
