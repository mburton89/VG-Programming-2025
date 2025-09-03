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
        SpawnBall(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBall(bool isP1)
    {
        StartCoroutine(DelaySpawnBall(isP1));
    }

    private IEnumerator DelaySpawnBall(bool isP1)
    {
        yield return new WaitForSeconds(3);

        Debug.Log("Spawn Ball");
        GameObject newBall = Instantiate(ballPrefab);

        float xDirection;
        float randY = Random.Range(-1.0f, 1.0f);

        if (isP1)
        {
            xDirection = 1;
            
        }
        else
        {
            xDirection = -1;
        }

        spawnDirection = new Vector3(xDirection, randY, 0);

        newBall.GetComponent<Ball>().direction = spawnDirection.normalized;
    }
}
