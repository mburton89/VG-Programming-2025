using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;       // Target to follow
    public float speed = 5f; // Movement speed
    public float stoppingDistance = 1f; //Distance at which to stop
    public float maxFollowDistance;
    public float maxJumpHeight;
    public bool isBeingFed;
    public float jumpSpeed;

    private void Start()
    {
        isBeingFed = false;
    }
    void Update()
    {
        if (isBeingFed)
        {
            transform.transl
            if (transform.position.y >= maxJumpHeight)
            {
                isBeingFed = false;
            }
        }

        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);

      

            if (distance > stoppingDistance && distance < maxFollowDistance)
            {

                // Move towards the target
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

           
        }
        if (Input.GetKeyDown(KeyCode.F)) //F to feed
        {
            isBeingFed = true;
        }

    }
}


