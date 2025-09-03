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
        float randStart = Random.Range(-1.0f, 1.0f);
        if (randStart < 1)
        {
            SpawnBall(true);
        }
        else
        {
            SpawnBall(false);
        }
    }

    // Update is called once per frame
    // Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    { 
    //        SpawnBall();
    //    }
    //
    //}

    public void SpawnBall(bool isP1)
    {
        StartCoroutine(DelaySpawnBall(isP1));
    }

    private IEnumerator DelaySpawnBall(bool isP1) 
    {

        yield return new WaitForSeconds(1.5f);

        Debug.Log("Spawn Ball");
        GameObject newBall = Instantiate(ballPrefab);

        float xDirection;
        if (isP1)
        {
            xDirection = -1;
        }
        else 
        {
            xDirection = 1;
        }
        float randY = Random.Range(-0.5f, 0.5f);
        spawnDirection = new Vector3(xDirection, randY, 0);

        newBall.GetComponent<Ball>().direction = spawnDirection.normalized;

    }


}
