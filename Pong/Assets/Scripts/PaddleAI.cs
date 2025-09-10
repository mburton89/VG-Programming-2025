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
        float RandMove = Random.Range(0.2f, bufferZone);
        if (activeBall.transform.position.y > activePaddle.transform.position.y + RandMove && activePaddle.transform.position.y < activePaddle.maxYPosition)
        {
            activePaddle.MoveUp();
        }
        else if (activeBall.transform.position.y < activePaddle.transform.position.y - RandMove && activePaddle.transform.position.y > -activePaddle.maxYPosition)
        {
            activePaddle.MoveDown();
        }

    }

    bool BallIsApproaching()
    {
        if (activePaddle.transform.position.x > 0)
        {
            if (activeBall.direction.x > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
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
