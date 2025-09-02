using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float movementSpeed;
    public Vector3 direction;

    public float maxYPosition; //WALLS

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
        }
        else if (transform.position.y < -maxYPosition && direction.y < 0)
        {
            direction = new Vector3(direction.x, -direction.y, 0);
        }
    }
}
