using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public Button button;

    public string sceneName;

    void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {

        SceneManager.LoadScene(sceneName);
    }
}
