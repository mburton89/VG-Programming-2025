using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SL_PlayerTemp : MonoBehaviour
{

    //temp
    public float currenthealth;
    public float maxHealth;
    public float currentFuel;
    public float maxFuel;

    public bool refuelling;

    public static SL_PlayerTemp Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        if (refuelling == true)
        { 
            RefuelJetFuel(0);
        }
    }

    //ADDED BY KIAN vvvv
    public void RefuelJetFuel(float transmitFuel)
    {
        print("oldFuel: " + currentFuel);
        transmitFuel += currentFuel;
        print("transmitFuel: " + transmitFuel);
        print("currentFuel: " + currentFuel);
        refuelling = false;
    }
    //ADDED BY KIAN ^^^^

}
