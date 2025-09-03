using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public static BallSpawner Instance;

    public Vector3 spawnDirection;
    public GameObject ballPrefab;

    public bool canSpawnBall = false;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canSpawnBall)
        { 
            SpawnBall(ScoreManager.Instance.player1Scored);
        }
    }

    public void SpawnBall(bool isP1)
    {
        Debug.Log("Spawn Ball");
        GameObject newBall = Instantiate(ballPrefab);

        float xDirection;

        if (isP1)
        {
            xDirection = 1;
        }
        else
        {
            xDirection = -1;
        }

        spawnDirection = new Vector3(xDirection, 0, 0);

        newBall.GetComponent<Ball>().direction = spawnDirection.normalized;

        canSpawnBall = false;
    }
}
