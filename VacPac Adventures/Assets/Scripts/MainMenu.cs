using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuButton.onClick.AddListener(GameManager.instance.LoadGameplay);
    }

}
