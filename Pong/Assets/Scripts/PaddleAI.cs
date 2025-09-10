using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    private Ball activeBall;
    public Paddle activePaddle;
    public float bufferZone;

    // Update is called once per frame
    void Update()
    {
        if(activeBall == null)
        {
            LookForBall();
        }
        else if(BallIsApproaching())
        {
            FollowBallWithPaddle();
        }

    }

    void LookForBall()
    {
        activeBall = FindObjectOfType<Ball>();
    }

    void FollowBallWithPaddle()
    {
        if(activeBall.transform.position.y > activePaddle.transform.position.y + bufferZone)
        {
            activePaddle.MoveUp();
        }        
        else if(activeBall.transform.position.y < activePaddle.transform.position.y - bufferZone)
        {
            activePaddle.MoveDown();
        }
    }

    bool BallIsApproaching()
    {
        //Our paddle is on the right and the ball is moving right
        if(activePaddle.transform.position.x > 0)
        {
            if(activeBall.direction.x > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Our paddle is on the left and the ball is moving left
        else
        {
            if(activeBall.direction.x < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
