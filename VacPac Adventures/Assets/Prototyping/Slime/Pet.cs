using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public int TargetFollower;
    public float FollowSpeed;
    public float FollowDistance;
    public float maxFollowDistance = 10;
    public KeyCode CallPet;
    public Vector3 direction;
    public float movementSpeed;
    public float speedIncrease;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        {

        }
    }



    void Move()
    {
        transform.position += direction * movementSpeed;
    }

    public class FollowTarget : MonoBehaviour
    {
        public Transform target;
        public float speed = 5f;
        public int distanceFromPlayer;
        public int maxdistanceFromPlayer;

        void Update()
        {
            if (target != null)
            {
                float distance = Vector3.Distance(transform.position, target.position);

                if (distance > distanceFromPlayer && distance < maxdistanceFromPlayer)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }
            }

           
        }

    }

}
        



