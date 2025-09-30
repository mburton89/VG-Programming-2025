using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButoon : MonoBehaviour
{
    public void RestartCurrentScene()
    {
        Time.timeScale = 1f;



        SceneManager.LoadScene("SpikeEnemyTesting");
    }
}
