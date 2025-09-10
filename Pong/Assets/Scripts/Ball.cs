using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float movementSpeed;
    public float movementSpeedIncreaseMult;
    public Vector3 direction;

    public float maxYPosition;
    public float maxXPosition;

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
        movementSpeed *= movementSpeedIncreaseMult;
    }

    void Move()
    {
        transform.position += direction * movementSpeed;
    }

    void CheckBoundaries()
    {
        if (transform.position.y > maxYPosition && direction.y > 0)
        { 
            direction = new Vector3(direction.x, -direction.y, 0);
            SoundManager.Instance.PlaySound(SoundManager.SoundType.serve);
        }
        else if (transform.position.y < -maxYPosition && direction.y < 0)
        {
            direction = new Vector3(direction.x, -direction.y, 0);
            SoundManager.Instance.PlaySound(SoundManager.SoundType.serve);
        }

        if (transform.position.x > maxXPosition)
        {
            ScoreManager.Instance.GivePoint(true);
            SoundManager.Instance.PlaySound(SoundManager.SoundType.goal);
            Destroy(gameObject);
        }
        else if (transform.position.x < -maxXPosition)
        {
            ScoreManager.Instance.GivePoint(false);
            SoundManager.Instance.PlaySound(SoundManager.SoundType.goal);
            Destroy(gameObject);
        }
    }
}
