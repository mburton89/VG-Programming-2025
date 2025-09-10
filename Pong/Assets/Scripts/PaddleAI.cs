using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
            //paddle on the right

            if (activeBall.direction.x > 0)
            {
                // ball is moving toward right paddle
                return true;
            }
            else
            {
                // ball is moving away from right paddle
                return false;
            }
        }
        else
        {
            //paddle on the left

            if (activeBall.direction.x < 0)
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
