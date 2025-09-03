using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
  // Start is called before the first frame update

  public static BallSpawner Instance;

  public GameObject ballPrefab;
  public KeyCode spawnKey;
  public Vector3 spawnDirection;

  private void Awake()
  {
    Instance = this;
  }
  void Start()
  {
    SpawnBall();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void SpawnBall()
  {
    StartCoroutine(DelaySpawnBall());
  }

  private IEnumerator DelaySpawnBall()
  {
    yield return new WaitForSeconds(0.5f);

    GameObject newBall = Instantiate(ballPrefab);


    spawnDirection.x = ScoreManager.Instance.whoScored;

    newBall.GetComponent<Ball>().direction = spawnDirection;
  }
}
