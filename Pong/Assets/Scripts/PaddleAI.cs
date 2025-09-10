using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    private Ball activeBall;
    public Paddle activePaddle;
    public float bufferZone;

    int sillyInt;

    string sillyString;

    public Color sillyColor;

    // Update is called once per frame
    void Update()
    {
        if (activeBall == null)
        {
            LookForBall();
        }
        else if (BallIsApproaching())
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
        if (activeBall.transform.position.y > activePaddle.transform.position.y + bufferZone)
        {
            activePaddle.MoveUp();
        }
        else if (activeBall.transform.position.y < activePaddle.transform.position.y - bufferZone)
        {
            activePaddle.MoveDown();
        }
    }

    bool BallIsApproaching()
    {
        if (activePaddle.transform.position.x > 0)
        {
            //our paddle is on the right side
            if (activeBall.direction.x > 0)
            {
                // ball is moving toward right paddle
                return true;
            }
            else
            {
                // ball is moving AWAY from right paddle
                return false;
            }
        }
        else
        {
            //our paddle is on the left side
            if (activeBall.direction.x < 0)
            {
                // ball is moving toward left paddle
                return true;
            }
            else
            {
                // ball is moving AWAY from left paddle
                return false;
            }
        }
    }
}
