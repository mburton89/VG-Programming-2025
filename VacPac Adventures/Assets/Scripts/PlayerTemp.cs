using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTemp : MonoBehaviour
{

    //temp
    public float currenthealth;
    public float maxHealth;
    public float currentFuel;
    public float maxFuel;

    public static PlayerTemp Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
