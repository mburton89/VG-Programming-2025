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

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
            //paddle is right
            if (activeBall.direction.x > 0)
            {
                //ball is moving towards right paddle
                return true;
            }
            else
            {
                //ball is moving away from paddle
                return false;
            }
        }
        else
        {
            //paddle is left
            if (activeBall.direction.x < 0)
            {
                //ball is moving towards left paddle
                return true;
            }
            else
            {
                //ball is moving away left paddle
                return false;
            }
        }
        
    }
}
