using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{

    public float slimeSize;
    public float slimeSpeed;
    public float fuelPower;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IdleWander()
    {
        // Slimes pick a random direction every X seconds.
        // Weighted preference to be near other Slimes?

    }

    void FleeFromEnemy()
    {
        // Slimes flee from Enemy (not player)
        // Need Enemy script 
    }

    void StruggleWithVacPac()
    {
        // Slime struggles against absorption. can escape?
    }

    public void GetAbsorbed()
    {
        // Telegraph fuelPower before destroyObject
        // Need VacPac
    }

}
