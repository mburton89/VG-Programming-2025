using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Paddle : MonoBehaviour
{
    public float maxYPosition;
    public float verticalMovementSpeed;
    public int xHitDirection;
    public int rotateSpeed;

    public KeyCode upKey;
    public KeyCode downKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotationSpeed();

        if (Input.GetKey(upKey) && transform.position.y < maxYPosition)
        { 
            MoveUp();
        }
        else if (Input.GetKey(downKey) && transform.position.y > -maxYPosition)
        {
            MoveDown();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            float yHitDirection = collision.transform.position.y - transform.position.y;
            Vector3 newHitDirection = new Vector3(xHitDirection, yHitDirection, 0);
            collision.gameObject.GetComponent<Ball>().GetHit(newHitDirection);
        }
    }

    void MoveUp()
    {
        transform.position += Vector3.up * verticalMovementSpeed;
    }

    void MoveDown()
    {
        transform.position += Vector3.down * verticalMovementSpeed;
    }
    void HitBall()
    {
    }

    private void RotationSpeed();
}
