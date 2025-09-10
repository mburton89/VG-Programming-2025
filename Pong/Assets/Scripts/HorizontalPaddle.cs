using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPaddle : MonoBehaviour
{
    public float maxXPosition;
    public float horizontalMovementSpeed;
    public int yHitDirection;

    public KeyCode rightKey;
    public KeyCode leftKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(rightKey) && transform.position.x < maxXPosition)
        { 
            MoveRight();
        }
        else if (Input.GetKey(leftKey) && transform.position.x > -maxXPosition)
        {
            MoveLeft();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            float xHitDirection = collision.transform.position.x - transform.position.x;
            Vector3 newHitDirection = new Vector3(xHitDirection, yHitDirection, 0);
            collision.gameObject.GetComponent<Ball>().GetHit(newHitDirection);
        }
    }

    public void MoveRight()
    {
        transform.position += Vector3.right * horizontalMovementSpeed;
    }

    public void MoveLeft()
    {
        transform.position += Vector3.left * horizontalMovementSpeed;
    }

    void HitBall()
    { 
    
    }
}
