using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PaddleAI : MonoBehaviour
{
    private Ball activeBall;
    public Paddle activePaddle;

    public float bufferZone;

    // Update is called once per frame
    void Update()
    {
        if (activeBall == null)
        {
            LookForBall();
        }
        else if (BallIsApproaching())
        {
            FollowBall();
        }
    }

    void LookForBall()
    {
        activeBall = FindObjectOfType<Ball>();
    }

    void FollowBall()
    {
        if(activeBall.transform.position.y > activePaddle.transform.position.y + bufferZone)
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
        if(activePaddle.transform.position.x > 0)
        {
            //paddle on right
            if(activeBall.direction.x  > 0)
            {
                //ball going to right
                return true;
            }
            else
            {
                //ball moving away from right
                return false;
            }
        }
        else
        {
            //paddle on left
            if(activeBall.direction.x < 0)
            {
                //ball going to left
                return true;
            }
            else
            {
                //ball moving away from left
                return false;
            }
        }
    }
}
