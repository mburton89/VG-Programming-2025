using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : MonoBehaviour
{

    public float slimeSpeed;
    public float fuelPower;

    public Rigidbody rigidBody;

    public Transform activeEnemy;

    bool isRelaxed;

    //public  Awareness;


    // Start is called before the first frame update
    void Start()
    {
        //Start coroutine IdleWander
        isRelaxed = true; 
        StartCoroutine(IdleWander());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IdleWander()
    {
        Debug.Log("IdleWander" + isRelaxed);
        StopCoroutine(FleeFromEnemy());

        do
        {
            int randX = Random.Range(-5, 5);
            int randY = Random.Range(8, 12);
            int randZ = Random.Range(-5, 5);

            //Pick new Direction (create a new Vector3)
            Vector3 newDirection = new Vector3(randX, randY, randZ);

            //Move in new direction (translate in newVector)
            rigidBody.AddForce(newDirection * slimeSpeed, ForceMode.Impulse);
            Debug.Log("AddForce");

            //Wait 10 seconds
            //yield on a new YieldInstruction that waits for 5 seconds
            yield return new WaitForSeconds(2);

        } while (isRelaxed);
    }

    //Detect intrusion to Awareness BY ENEMY
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //get transform of other.gameObject and store in variable
            activeEnemy = other.transform;

            if (isRelaxed)
            {
                isRelaxed = false;
                //tag offending Enemy with variable to be used in FleeFromEnemy to move away
                StartCoroutine(FleeFromEnemy());
                print("Starting Flee From Enemy");
            }
            }
    }

    IEnumerator FleeFromEnemy()
    {
        StopCoroutine(IdleWander());

        do
        {


            float randY = Random.Range(8.0f, 10.0f);
            float fleeDirectionX = transform.position.x - activeEnemy.position.x;
            float fleeDirectionZ = transform.position.z - activeEnemy.position.z;

            //hop away from enemy
            //Vector3 directionToFlee = new Vector3(activeEnemy.position.x + transform.position.x, randY, activeEnemy.position.z + transform.position.z);

            Vector3 directionToFlee = new Vector3(fleeDirectionX, randY, fleeDirectionZ);

            rigidBody.AddForce(directionToFlee * slimeSpeed, ForceMode.Impulse);
            Debug.Log("Fleeing");

            // time between hops
            yield return new WaitForSeconds(1.5f);

        } while (isRelaxed == false);


    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            StartCoroutine(FleeFromEnemyCooldown());
            print("Starting FleeFromEnemy Cooldown");
        }
    }

    public IEnumerator FleeFromEnemyCooldown()
    {
        yield return new WaitForSeconds(8);
        isRelaxed = true;
        print("isRelaxed= " + isRelaxed);
        StartCoroutine(IdleWander());
    }

    void StruggleWithVacPac()
    {
        // Slime struggles against absorption. can escape?
        //Need Vacpac Script
    }

    public void GetAbsorbed()
    {
        // Telegraph fuelPower before destroyObject
        // Need VacPac
    }

}
