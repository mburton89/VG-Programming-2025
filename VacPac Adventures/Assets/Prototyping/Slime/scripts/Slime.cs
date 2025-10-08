using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{  
    public float slimeSize;
    public float slimeSpeed;
    public float fuelPower;
    private bool obtained = false;
    public float attractionSpeed;
    public GameObject targetObject;
    public float fuelAddAmount = 5f;

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
            AudioManager.Instance.PlaySound("SlimeJump", false, transform.position);

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

            if (isRelaxed)
            {
                isRelaxed = false;
                //tag offending Enemy with variable to be used in FleeFromEnemy to move away

                StartCoroutine(FleeFromEnemy());
            }
            }
    }

    IEnumerator FleeFromEnemy()
    {
        do
        {

            //hop away from enemy
            //Vector3 directionToFlee = new Vector3(enemy.position.x + transform.position.x, randY, enemy.position.z + transform.position.z);
            //rigidBody.AddForce(directionToFlee * slimeSpeed / slimeSize, ForceMode.Impulse);

            //TEMPORARY QUICK HOPS FOR DEBUG
            int randX = Random.Range(-5, 5);
            int randY = Random.Range(5, 20);
            int randZ = Random.Range(-5, 5);

            //Pick new Direction (create a new Vector3)
            Vector3 newDirection = new Vector3(randX, randY, randZ);

            //Move in new direction (translate in newVector)
            //transform.Translate(newDirection * slimeSpeed * Time.deltaTime);
            rigidBody.AddForce(newDirection * slimeSpeed, ForceMode.Impulse);
            Debug.Log("Fleeing");

            // cooldown after enemy leaves collision?
            yield return new WaitForSeconds(1);
            //if no Enemy in trigger, set isRelaxed to True

        } while (isRelaxed == false);


        // Slimes flee from Enemy (not player)
        // Enemy triggers Awareness collider -> run FleeFromEnemy for 3 -> check Awareness -> bool isReleaxed

    }

    void StruggleWithVacPac()
    {
        // Slime struggles against absorption. can escape?
        //Need Vacpac Script
    }

    public void GetPulled()
    {
        if (targetObject != null)
        {
            Vector3 targetPosition = targetObject.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position, attractionSpeed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "VacPac")
        {
            if (VacPackAlpha.Instance.imEating)
            {
                Obtain();
                obtained = true;
            }
        }
    }

    private void Obtain()
    {
        PlayerTemp.Instance.currentFuel += fuelAddAmount;

        if (PlayerTemp.Instance.currentFuel > PlayerTemp.Instance.maxFuel)
        {
            PlayerTemp.Instance.currentFuel = PlayerTemp.Instance.maxFuel;
        }
        Destroy(this.gameObject);

        Destroy(gameObject);
    }

}
