using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float movementSpeed;
    public Vector3 direction;

    public float maxYPosition;
    public float maxXPosition;

    public float speedIncrease;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBoundaries();
    }

    public void GetHit(Vector3 hitDirection)
    {
        direction = hitDirection;
        movementSpeed += speedIncrease;
    }

    void Move()
    {
        transform.position += direction * movementSpeed;
    }

    void CheckBoundaries()
    {
        if (transform.position.y > maxYPosition && direction.y > 0)
        {
            SoundManager.Instance.PlaySound(SoundManager.SoundType.paddle);

            direction = new Vector3(direction.x, -direction.y, 0);
        }
        else if (transform.position.y < -maxYPosition && direction.y < 0)
        {
            SoundManager.Instance.PlaySound(SoundManager.SoundType.paddle);

            direction = new Vector3(direction.x, -direction.y, 0);
        }

        if (transform.position.x > maxXPosition)
        {
            SoundManager.Instance.PlaySound(SoundManager.SoundType.goal);

            ScoreManager.Instance.GivePoint(true);
            Destroy(gameObject);
        }
        else if (transform.position.x < -maxXPosition)
        {
            SoundManager.Instance.PlaySound(SoundManager.SoundType.goal);

            ScoreManager.Instance.GivePoint(false);
            Destroy(gameObject);
        }
    }
}
