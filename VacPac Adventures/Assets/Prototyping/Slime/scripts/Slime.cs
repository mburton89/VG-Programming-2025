using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{

    public float slimeSize;
    public float slimeSpeed;
    public float fuelPower;

    public Rigidbody rigidBody;

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

    private void OnTriggerEnter(Collider other)
    {
        
    }

    IEnumerator IdleWander()
    {
        Debug.Log("IdleWander" + isRelaxed);

        do
        {
            int randX = Random.Range(-5, 5);
            int randY = Random.Range(5, 20);
            int randZ = Random.Range(-5, 5);

            //Pick new Direction (create a new Vector3)
            Vector3 newDirection = new Vector3(randX, randY, randZ);

            //Move in new direction (translate in newVector)
            //transform.Translate(newDirection * slimeSpeed * Time.deltaTime);
            rigidBody.AddForce(newDirection * slimeSpeed, ForceMode.Impulse);
            Debug.Log("AddForce");

            //Wait 10 seconds
            //yield on a new YieldInstruction that waits for 5 seconds
            yield return new WaitForSeconds(2);

        } while (isRelaxed);
    }

    void FleeFromEnemy()
    {
        // Slimes flee from Enemy (not player)
        // Need Enemy script 
        // Need awareness field 
        // Enemy triggers Awareness collider -> run FleeFromEnemy for 3 -> check Awareness -> bool isReleaxed
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
