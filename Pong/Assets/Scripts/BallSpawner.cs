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
    //void Update()
    //{
    //if (Input.GetKeyDown(KeyCode.Space))
    // { 
    //    SpawnBall();
    // }
    //}

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

        if (isP1)
        {
            xDirection = 1;
        }
        else
        {
            xDirection = -1;
        }

        float randY = Random.Range(-0.1f, 0.1f);

        spawnDirection = new Vector3(xDirection, randY, 0);

        newBall.GetComponent<Ball>().direction = spawnDirection.normalized;

        SoundManager.Instance.PlaySound(SoundManager.SoundType.serve);
    }

}
