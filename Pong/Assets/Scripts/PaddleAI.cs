using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{

    private Ball activeBall;
    public Paddle activeYPaddle;
    public HorizontalPaddle activeXPaddle;
    public float bufferZone;

    // Update is called once per frame
    void Update()
    {
        if (activeBall == null)
        {
            LookForBall();
        }
        else if (BallIsApproachingX())
        {
            FollowBallWithPaddleX();
        }
        else if (BallIsApproachingY())
        {
            FollowBallWithPaddleY();
        }
    }

    void LookForBall()
    {
        activeBall = FindObjectOfType<Ball>();
    }

    void FollowBallWithPaddleY()
    {

        if (activeBall.transform.position.y > activeYPaddle.transform.position.y + bufferZone)
        {
            activeYPaddle.MoveUp();
        }
        else if (activeBall.transform.position.y < activeYPaddle.transform.position.y + bufferZone)
        {
            activeYPaddle.MoveDown();
        }
        
    }

    void FollowBallWithPaddleX()
    {
        if (activeBall.transform.position.x > activeXPaddle.transform.position.x + bufferZone)
        {
            activeXPaddle.MoveRight();
        }
        else if (activeBall.transform.position.x < activeXPaddle.transform.position.x + bufferZone)
        {
            activeXPaddle.MoveLeft();
        }
    }

    bool BallIsApproachingX()
    {
        if (activeXPaddle.transform.position.y > 0)
        {
            //our paddle is on the right side
            if (activeBall.direction.y > 0)
            {
                //ball is moving toward the right side
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            //our paddle is on the left side
            if (activeBall.direction.y < 0)
            {
                //ball is moving toward the left side
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    bool BallIsApproachingY()
    { 
        if(activeYPaddle.transform.position.x > 0)
        {
            //our paddle is on the top side
            if (activeBall.direction.x > 0)
            {
                //ball is moving toward top side
                return true;
            }
            else
            {
                return false;
            }

        }
        else
        {
            //our paddle is on the bottom side
            if (activeBall.direction.x < 0)
            {
                //ball is moving toward bottom side
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}
