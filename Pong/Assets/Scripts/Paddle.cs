using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

  public float maxYPos;
  public float verticalMoveSpeed;
  public int xHitDirection;
  public int movingDirection;

  public KeyCode upKey;
  public KeyCode downKey;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(upKey) && transform.position.y < maxYPos)
    {
      movingDirection = 1;
      MoveUp();
    }

    else if (Input.GetKey(downKey) && transform.position.y > -maxYPos)
    {
      movingDirection = -1;
      MoveDown();
    }
    else
    {
      movingDirection = 0;
    }
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.GetComponent<Ball>())
    {
      float yHitDirection = movingDirection;
      float ballY = collision.gameObject.GetComponent<Ball>().direction.y;

      Vector3 newHitDirection = new Vector3(xHitDirection, (ballY + yHitDirection) / 2, 0);
      collision.gameObject.GetComponent<Ball>().GetHit(newHitDirection);
    }

  }

  void MoveUp()
  {
    transform.position += Vector3.up * verticalMoveSpeed * Time.deltaTime;
  }
  void MoveDown()
  {
    transform.position += Vector3.down * verticalMoveSpeed * Time.deltaTime;
  }

  void HitBall()
  {

  }

}
