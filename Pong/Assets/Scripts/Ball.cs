using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
  public float moveSpeed;
  public Vector3 direction;
  public float maxXPos;
  public float maxYPos;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Move();
    CheckBoundaries();


  }

  void Move()
  {
    transform.position += direction * moveSpeed * Time.deltaTime;
  }

  public void GetHit(Vector3 hitDirection)
  {
    direction = hitDirection;
    if (hitDirection.x > 0)
    {
      MainCamera.Instance.position.z = -10.5f;
      MainCamera.Instance.rotation.y = 2f;
    }
    else
    {
      MainCamera.Instance.position.z = -10.5f;
      MainCamera.Instance.rotation.y = -2f;
    }
  }



  void CheckBoundaries()
  {
    // BOUNCE OFF WALLS!!
    if (transform.position.y > maxYPos && direction.y > 0)
    {
      direction.y = -direction.y;
      moveSpeed = moveSpeed + 0.5f;
    }
    else if (transform.position.y < -maxYPos && direction.y < 0)
    {
      direction.y = -direction.y;
      moveSpeed = moveSpeed + 0.5f;
    }

    // SCORE A POINT!!
    if (transform.position.x > maxXPos)
    {
      ScoreManager.Instance.GivePoint(true);
      print("P1 score: " + ScoreManager.Instance.p1Score);
      Destroy(gameObject);
    }
    else if (transform.position.x < -maxXPos)
    {
      ScoreManager.Instance.GivePoint(false);
      print("P2 score: " + ScoreManager.Instance.p2Score);
      Destroy(gameObject);
    }
  }

}
