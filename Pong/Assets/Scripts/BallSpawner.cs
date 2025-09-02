using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public static BallSpawner Instance;

    public Vector3 spawnDirection;
    public GameObject ballPrefab;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            SpawnBall();
        }
    }

    public void SpawnBall()
    {
        Debug.Log("Spawn Ball");
        GameObject newBall = Instantiate(ballPrefab);

        float randX = Random.Range(-1.0f, 1.0f);
        float randY = Random.Range(-1.0f, 1.0f);
        spawnDirection = new Vector3(randX, randY, 0);

        newBall.GetComponent<Ball>().direction = spawnDirection.normalized;
    }
}
