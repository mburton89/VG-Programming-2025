//using System.Collections;
//using System.Collections.Generic;
//using System.Net.NetworkInformation;
//using UnityEngine;
//using UnityEngine.AI;


//public class EnemyAI : MonoBehaviour

//{
//    [Header("References")]
//    public NavMeshAgent agent;
//    public Transform player;
//    [Header("Wandering")]
//    public float wanderRadius = 10f;
//    public float wanderInterval = 3f;

//    private float timer;
//    private bool playerDetected = false;
//    private bool lockedOnPlayer;

    
//    void Start()
//    {
//        if (agent == null)
//            agent = GetComponent<NavMeshAgent>();

//        agent = GetComponent<NavMeshAgent>();
//        timer = wanderInterval;
//    }


    
//    void Update()
//    {
//        if(lockedOnPlayer && player != null)
//        {
//            agent.SetDestination(player.position);
//            return;
//        }





//        if (playerDetected && player != null)
//        {
//            if(player != null)
//            agent.SetDestination(player.position);
//        }
//        else
//        {
//        timer -=Time.deltaTime;
//        if (timer <= 0f || agent.remainingDistance < agent.stoppingDistance + 0.1f)
//        {
//            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, NavMesh.AllAreas);
//            agent.SetDestination(newPos);
//                PickNewWanderDestination();
//                timer = wanderInterval;
//        }

//        }
//    }

//    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int areaMask)
//    {
//        Vector3 randomDirection = Random.insideUnitSphere * distance;
//        randomDirection += origin;

//        NavMeshHit navHit;
//        NavMesh.SamplePosition(randomDirection, out navHit, distance, areaMask);

//        return navHit.position;
//    }
//    public void OnPlayerEnter (Transform playerTransform)
//    {
//        playerDetected = true;
//        player = playerTransform;
        
//    }

//    public void OnPlayerExit()
//    {
//        playerDetected = false;
//        player = null;
//        timer = 0f;
//    }

//    void PickNewWanderDestination()
//    {
//        Vector3 newPos = GetRandomNavMeshPoint(transform.position, wanderRadius);
//        agent.SetDestination(newPos);
//    }

//    Vector3 GetRandomNavMeshPoint(Vector3 origin, float distance)
//    {
//        Vector3 randomDirection = Random.insideUnitSphere * distance + origin;
//        NavMeshHit navHit;
//        NavMesh.SamplePosition(randomDirection, out navHit, distance, NavMesh.AllAreas);
//        return navHit.position;
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.collider.CompareTag("Player"))
//        {
//            lockedOnPlayer = true;
//            player = collision.collider.transform;
//        }
//    }




//}
